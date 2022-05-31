using RuleEngineCore.Abstract;
using TestProject1.Dependencies;

namespace TestProject1.Rules.DoSomethingWithInputParameters
{
    public class DoSomethingWithInputParametersRuleSetConfiguration : IRuleSet
    {
        public void Configure(IRuleSetConfiguration ruleSetConfiguration)
        {
            ruleSetConfiguration
                .For<TestController1>(t => t.DoSomething(default(string), default(int), default(Parameter1), default(Parameter2)))
                .AddRule<DoSomethingWithInputParametersRule>();
        }
    }
}
