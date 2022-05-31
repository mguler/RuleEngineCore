using RuleEngineCore.Abstract;
using System;
using TestProject1.Dependencies;

namespace TestProject1.Rules.DoSomethingWithInputParameters
{
    public class DoSomethingWithInputParametersRule : Rule
    {
        public DoSomethingWithInputParametersRule()
        {
            Define<string, int, Parameter1,Parameter2>((parameter1, parameter2, parameter3, parameter4) => {
                throw new NotImplementedException();
            });   
        }
    }
}
