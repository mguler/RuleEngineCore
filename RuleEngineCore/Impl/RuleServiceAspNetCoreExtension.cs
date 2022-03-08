using Microsoft.Extensions.DependencyInjection;
using RuleEngineCore.Abstract;
using System;
using System.Linq;

namespace RuleEngineCore.Impl
{
    public static class RuleServiceAspNetCoreExtension
    {
        public static void AddRuleService(this IServiceCollection services, params Type[] ruleConfigurationTypes) 
        {
            services.AddSingleton<IRuleServiceProvider>((serviceProvider) =>
            {
                var instances = ruleConfigurationTypes.Select(type => type.GetConstructor(Type.EmptyTypes).Invoke(null) as IRuleSet).ToArray();
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
    }
}
