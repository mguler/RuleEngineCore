using RuleEngineCore.Abstract;
using TestProject1.Dependencies;

namespace TestProject1.Rules.DoItRules
{
    public class AnotherRuleForDoItDateTimeCheck : Rule
    {
        private readonly Dependency1 _dependency1;
        private readonly Dependency2 _dependency2;
        private readonly Dependency3 _dependency3;
        private readonly Dependency4 _dependency4;
        private readonly Dependency5 _dependency5;
        public AnotherRuleForDoItDateTimeCheck(Dependency2 dependency2, Dependency3 dependency3, Dependency1 dependency1,Dependency5 dependency5,Dependency4 dependency4)
        {
            _dependency1 = dependency1;
            _dependency2 = dependency2;
            _dependency3 = dependency3;
            _dependency4 = dependency4;
            _dependency5 = dependency5;

            Define<string, int, bool>((a, b, c) => {
                if (c) 
                {
                    AddMessage("İşlem patates oldu!!!");
                }
            });   
        }
    }
}
