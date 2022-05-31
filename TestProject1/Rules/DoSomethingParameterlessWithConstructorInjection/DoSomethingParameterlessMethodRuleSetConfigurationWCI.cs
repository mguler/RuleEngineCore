using RuleEngineCore.Abstract;

namespace TestProject1.Rules.DoSomethingParameterlessWithConstructorInjection
{
    public class DoSomethingParameterlessMethodRuleSetConfigurationWCI : IRuleSet
    {
        public void Configure(IRuleSetConfiguration ruleSetConfiguration)
        {
            ruleSetConfiguration
                .For<TestController1>(t => t.DoSomething())
                .AddRule<DoSomethingParameterlessMethodRuleWCI>();              
        }
    }
}
