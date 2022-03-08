namespace RuleEngineCore.Abstract
{
    public interface IRule
    {
        void Apply(params object[] args);
    }
}
