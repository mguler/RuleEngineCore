using System;
using System.Linq.Expressions;

namespace RuleEngineCore.Abstract
{
    public interface IRuleSetConfiguration
    {
        IRuleSetConfiguration For<T, TResult>(Expression<Func<T, TResult>> expression) where T : class;
        IRuleSetConfiguration For<T>(Expression<Action<T>> expression) where T : class;
        IRuleSetConfiguration AddRule<TRule>() where TRule : class, IRule;
    }
}
