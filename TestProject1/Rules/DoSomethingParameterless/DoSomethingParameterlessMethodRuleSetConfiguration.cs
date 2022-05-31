using RuleEngineCore.Abstract;

namespace TestProject1.Rules.DoSomethingParameterless
{
    public class DoSomethingParameterlessMethodRuleSetConfiguration : IRuleSet
    {
        public void Configure(IRuleSetConfiguration ruleSetConfiguration)
        {
            ruleSetConfiguration
                .For<TestController1>(t => t.DoSomething())
                .AddRule<DoSomethingParameterlessMethodRule>();              
        }
    }
}
