using RuleEngineCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RuleEngineCore.Impl
{
    public class RuleServiceProviderDefaultImpl : IRuleServiceProvider, IRuleSetConfiguration
    {
        private readonly Dictionary<object,List<Type>> _cache = new Dictionary<object, List<Type>>(); 
        private List<Type> _current;
        private Func<Type, object> _dependencyResolverCallback;

        public RuleServiceProviderDefaultImpl(params IRuleSet[] ruleSets)
        {
            foreach (var ruleSet in ruleSets)
            {
                ruleSet.Configure(this);
            }
        }

        private void Add(object key)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache.Add(key, new List<Type>());
            }
            _current = _cache[key];
        }

        public IRuleSetConfiguration For<T,TResult>(Expression<Func<T, TResult>> expression) where T : class
        {
            var methodInfo = (expression.Body as MethodCallExpression).Method;
            Add(methodInfo);
            return this;
        }
        public IRuleSetConfiguration For<T>(Expression<Action<T>> expression) where T : class
        {
            var methodInfo = (expression.Body as MethodCallExpression).Method;
            Add(methodInfo);
            return this;
        }

        public IRuleSetConfiguration AddRule<TRule>() where TRule : class, IRule
        {
            _current.Add(typeof(TRule));
            return this;
        }

        public IRuleCollection ApplyRules(object key, object[] args)
        {
            var result = new ResultCollection();

            if (!_cache.ContainsKey(key))
            {
                return result;
            }

            var ctorArgs = new List<object>();
            var rules = _cache[key];
            var cancelRuleExecution = false;
            
            rules.ForEach(ruleType => {

                if (cancelRuleExecution) 
                {
                    return;
                }

                var ctor = ruleType.GetConstructors().FirstOrDefault();
                if (ctor == null)
                {
                    return;
                }

                var ctorArgTypes = ctor.GetParameters().ToList();
                var orderedArgs = new List<object>();

                if (ctorArgTypes.Count > 0 && _dependencyResolverCallback != null)
                {
                    ctorArgTypes.ForEach(parameterInfo =>
                    {
                        var argInstance = ctorArgs.SingleOrDefault(arg => arg.GetType() == parameterInfo.ParameterType);
                        if(argInstance == null)
                        {
                            argInstance = _dependencyResolverCallback(parameterInfo.ParameterType);
                            ctorArgs.Add(argInstance);
                        }
                        orderedArgs.Add(argInstance);
                    });
                }

                var instance = ctor.Invoke(orderedArgs.ToArray()) as Rule;

                try
                {
                    instance.Apply(args);

                }
                catch (Exception ex)
                {
                    throw new RuleEngineException(ex, instance.GetType(), args);
                }

                cancelRuleExecution = instance.CancelRuleExecution;
                result.Add(instance);
            });
            return result;
        }
        public void SetDependencyResolver(Func<Type, object> func) => _dependencyResolverCallback = func;
    }
}
