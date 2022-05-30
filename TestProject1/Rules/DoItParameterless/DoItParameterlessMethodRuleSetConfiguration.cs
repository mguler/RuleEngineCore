using RuleEngineCore.Abstract;

namespace TestProject1.Rules.DoItRules
{
    public class DoItParameterlessMethodRuleSetConfiguration : IRuleSet
    {
        public void Configure(IRuleSetConfiguration ruleSetConfiguration)
        {
            ruleSetConfiguration
                .For<TestController1>(t => t.DoSomething())
                .AddRule<DoItParameterlessMethodRule>();              
        }
    }
}
