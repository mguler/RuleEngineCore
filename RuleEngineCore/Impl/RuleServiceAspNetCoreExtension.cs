using Microsoft.Extensions.DependencyInjection;
using RuleEngineCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngineCore.Impl
{
    public static class RuleServiceAspNetCoreExtension
    {
        public static void AddRuleService(this IServiceCollection services, params Type[] ruleConfigurationTypes)
        {
            var containsNull = ruleConfigurationTypes.Any(type => type == null);
            if (containsNull)
            {
                throw new ArgumentException("Method does not allow nulls");
            }

            services.AddSingleton<IRuleServiceProvider>((serviceProvider) =>
            {
                var instances = CreateInstances(ruleConfigurationTypes).ToArray();

                var ruleService = new RuleServiceProviderDefaultImpl(instances);
                ruleService.SetDependencyResolver(type => serviceProvider.CreateScope().ServiceProvider.GetRequiredService(type));
                return ruleService;
            });
        }

        public static void AddRuleService(this IServiceCollection services, params IRuleSet[] ruleConfigurations)
        {
            services.AddTransient<IRuleServiceProvider>((serviceProvider) =>
            {
                var ruleService = new RuleServiceProviderDefaultImpl(ruleConfigurations);
                return ruleService;
            });
        }
        private static IEnumerable<IRuleSet> CreateInstances(Type[] types)
        {
            foreach (var type in types)
            {
                var instance = type.GetConstructor(Type.EmptyTypes).Invoke(null) as IRuleSet;
                if (instance is null)
                {
                    throw new Exception($"the type {type} does not implement {nameof(IRuleSet)}");
                }
                yield return instance;
            }
        }
    }
}
