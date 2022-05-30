using System;

namespace TestProject1.Dependencies
{
    public class Dependency6
    {
        private readonly Action _action;
        public Dependency6(Action action)
        {
            _action = action;
        }
        public void invoke() => _action();
    }
}
