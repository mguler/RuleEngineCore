using RuleEngineCore.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngineCore.Impl
{
    public class ResultCollection : IRuleCollection
    {
        private readonly List<Rule> _inner = new List<Rule>();
        public bool HasErrors => _inner.Any(rule => rule.HasErrors);
        public bool HasMessages => _inner.Any(rule=> rule.HasMessages);
        public IEnumerable<Message> GetMessages() => _inner.SelectMany(rule => rule.GetMessages());
        internal void Add(Rule rule) => _inner.Add(rule);
        internal void AddRange(IEnumerable<Rule> rules) => _inner.AddRange(rules);
        internal  ResultCollection()
        {

        }
    }
}
