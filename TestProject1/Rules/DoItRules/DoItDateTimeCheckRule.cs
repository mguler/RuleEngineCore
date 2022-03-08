using RuleEngineCore.Abstract;
using TestProject1.Dependencies;

namespace TestProject1.Rules.DoItRules
{
    public class DoItDateTimeCheckRule : Rule
    {
        private readonly Dependency1 _dependency1;
        private readonly Dependency2 _dependency2;
        private readonly Dependency3 _dependency3;

        public DoItDateTimeCheckRule(Dependency1 dependency1, Dependency2 dependency2 , Dependency3 dependency3)
        {
            _dependency1 = dependency1;
            _dependency2 = dependency2;
            _dependency3 = dependency3;

            Define<string, int, bool>((a, b, c) => {
                if (c) 
                {
                    AddMessage("İşlem patates oldu!!!");
                }
            });   
        }
    }
}
