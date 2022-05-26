using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngineCore.Impl;
using System.Linq;
using TestProject1.Rules.DoItRules;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var service = new RuleServiceProviderDefaultImpl(new DoItRuleSetConfiguration());
            service.SetDependencyResolver(type => {

                var ctor = type.GetConstructors().FirstOrDefault();
                var instance = ctor.Invoke(null);
                return instance;
            });
            
            var methodInfo = typeof(TestController1).GetMethods().SingleOrDefault(methodInfo => methodInfo.GetParameters().Length == 3);

            var args = new object[] { "...", 110, true };

            var result = service.ApplyRules(methodInfo, args.ToArray());

        }
    }
}
