using System.Reflection;

namespace RuleEngineCore.Abstract
{
    public interface IRuleServiceProvider
    {
        IRuleCollection ApplyRules(object key, object[] args);
    }
}
