using RuleEngineCore.Abstract;
using TestProject1.Dependencies;

namespace TestProject1.Rules.DoItRules
{
    public class ThirdRuleForDoItDateTimeCheck : Rule
    {
        private readonly Dependency1 _dependency1;
        private readonly Dependency4 _dependency4;
        public ThirdRuleForDoItDateTimeCheck(Dependency4 dependency4, Dependency1 dependency1)
        {
            _dependency1 = dependency1;
            _dependency4 = dependency4;

            Define<string, int, bool>((a, b, c) => {
                if (c) 
                {
                    AddMessage("İşlem patates oldu!!!");
                }
            });   
        }
    }
}
