using RuleEngineCore.Abstract;
using System;

namespace TestProject1.Rules.DoSomethingParameterless
{
    public class DoSomethingParameterlessMethodRule : Rule
    {
        public DoSomethingParameterlessMethodRule()
        {
            Define(() => {
                throw new NotImplementedException();
            });   
        }
    }
}
