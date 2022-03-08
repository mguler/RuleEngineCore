using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngineCore.Abstract
{
    public interface IRuleCollection
    {
        bool HasErrors { get; }
        bool HasMessages { get; }
        IEnumerable<Message> GetMessages();
    }
}
