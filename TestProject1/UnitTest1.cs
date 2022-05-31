using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngineCore.Impl;
using System;
using TestProject1.Dependencies;
using TestProject1.Rules.DoSomethingParameterless;
using TestProject1.Rules.DoSomethingParameterlessWithConstructorInjection;
using TestProject1.Rules.DoSomethingWithInputParameters;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod("Parameterless method rule")]
        public void ParameterlessMethodTest()
        {
            var service = new RuleServiceProviderDefaultImpl(new DoSomethingParameterlessMethodRuleSetConfiguration());
            var methodInfo = typeof(TestController1).GetMethod("DoSomething", Type.EmptyTypes);
            try
            {
                service.ApplyRules(methodInfo, null);
            }
            catch (Exception ex)
            {
               Assert.IsTrue(ex.InnerException is NotImplementedException);
            }
        }

        [TestMethod("Rule withouth constructor parameter injection test")]
        public void RuleWithouthConstructorParameterInjectionTest()
        {
            var service = new RuleServiceProviderDefaultImpl(new DoSomethingParameterlessMethodRuleSetConfiguration());
            var methodInfo = typeof(TestController1).GetMethod("DoSomething", Type.EmptyTypes);
            try
            {
                service.ApplyRules(methodInfo, null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.InnerException is NotImplementedException);
            }
        }

        [TestMethod("Rule with constructor parameter injection test")]
        public void RuleWithConstructorParameterInjectionTest()
        {
            var service = new RuleServiceProviderDefaultImpl(new DoSomethingParameterlessMethodRuleSetConfigurationWCI());
            service.SetDependencyResolver((type) => {
                var instance = type.GetConstructor(Type.EmptyTypes).Invoke(null);
                return instance;
            });

            var methodInfo = typeof(TestController1).GetMethod("DoSomething", Type.EmptyTypes);
            try
            {
                service.ApplyRules(methodInfo, null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.InnerException is NotImplementedException);
            }
        }

        [TestMethod("Method with parameters test")]
        public void MethodWithParametersTest()
        {
            var service = new RuleServiceProviderDefaultImpl(new DoSomethingWithInputParametersRuleSetConfiguration());
            var methodInfo = typeof(TestController1).GetMethod("DoSomething", new Type[] { typeof(string), typeof(int), typeof(Parameter1), typeof(Parameter2) });
            var inputArgs = new object[] { "", 1, new Parameter1(), new Parameter2() };
            try
            {

                service.ApplyRules(methodInfo, inputArgs);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.InnerException is NotImplementedException);
            }
        }
    }
}