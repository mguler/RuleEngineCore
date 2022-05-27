using System;

namespace RuleEngineCore.Impl
{
    public class RuleEngineException:Exception 
    {
        public Type RuleType { get; private set; }
        public object[] InputArguments { get; private set; }
        public RuleEngineException(Exception inner, Type ruleType) : base("Rule engine exception", inner)
        {
            RuleType = ruleType;
        }
        public RuleEngineException(Exception inner, Type ruleType,object[] inputArguments) : base("Rule engine exception", inner)
        {
            RuleType = ruleType;
            InputArguments = inputArguments;
        }
    }
}
