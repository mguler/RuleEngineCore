using RuleEngineCore.Abstract;
using System;
using TestProject1.Dependencies;

namespace TestProject1.Rules.DoSomethingParameterlessWithConstructorInjection
{
    public class DoSomethingParameterlessMethodRuleWCI : Rule
    {
        public DoSomethingParameterlessMethodRuleWCI( Dependency1 dependency1,Dependency2 dependency2 ,Dependency3 dependency3)
        {
            Define(() => {
                throw new NotImplementedException();
            });   
        }
    }
}
