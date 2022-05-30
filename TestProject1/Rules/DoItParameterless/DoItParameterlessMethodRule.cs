using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngineCore.Abstract;
using TestProject1.Dependencies;

namespace TestProject1.Rules.DoItRules
{
    public class DoItParameterlessMethodRule : Rule
    {
        private readonly Dependency6 _dependency6;

        public DoItParameterlessMethodRule(Dependency6 dependency6)
        {
            _dependency6 = dependency6;

            Define(() => {
                _dependency6.invoke();
            });   
        }
    }
}
