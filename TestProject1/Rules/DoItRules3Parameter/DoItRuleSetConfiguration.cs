using RuleEngineCore.Abstract;

namespace TestProject1.Rules.DoItRules
{
    public class DoItRuleSetConfiguration : IRuleSet
    {
        public void Configure(IRuleSetConfiguration ruleSetConfiguration)
        {
            ruleSetConfiguration
                .For<TestController1>(t => t.DoSomething(default(string), default(int), default(bool)))
                .AddRule<DoItDateTimeCheckRule>()
                .AddRule<DoItParameterlessMethodRule>()
                .AddRule<AnotherRuleForDoItDateTimeCheck>()
                .AddRule<ThirdRuleForDoItDateTimeCheck>();
              
        }
    }
}
