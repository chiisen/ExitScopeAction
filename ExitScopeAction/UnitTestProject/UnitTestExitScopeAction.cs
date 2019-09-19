using ExitScope;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestTool;
using System;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestExitScopeAction
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            MSTestLog.Initialize();
        }

        [TestMethod]
        public void TestMethod()
        {
            void exitCallback_()
            {
                MSTestLog.WriteLine("離開 Scope 執行完畢！");
            }

            using (var tms = new ExitScopeAction("離開 Scope 執行", exitCallback_))
            {

                Thread.Sleep(2000);
            }
        }


        public class ESA : ExitScopeAction
        {
            public ESA(Action action, string title) : base
                (title,
                () =>
                {
                    MSTestLog.WriteLine("離開 Scope 2 執行完畢！");
                })
            {
            }
        }


        [TestMethod]
        public void TestMethod2()
        {
            using (var tms = new ESA(null, "離開 Scope 2 執行"))
            {
                Thread.Sleep(2000);
            }
        }
    }
}
