using ExitScope;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestTool;
using System;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestTimeMeasureScope
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            MSTestLog.Initialize();
        }

        [TestMethod]
        public void TestMethod()
        {
            void exitTimeMeasure_(long t, string x)
            {
                MSTestLog.WriteLine($"{x} 執行 {t} ms");
            }

            using (var tms = new TimeMeasureScope("for loop", exitTimeMeasure_))
            {
                for (int i = 0; i < 10; ++i)
                {
                    Thread.Sleep(200);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class TMS : TimeMeasureScope
        {
            public TMS(string title, Action<long, string> action = null) : base
                (   title,
                    (t, x) => 
                    {
                        MSTestLog.WriteLine($"{x} 執行 {t} ms");
                    })
            {
            }
        }


        [TestMethod]
        public void TestMethod2()
        {
            using (var tms = new TMS("for loop 2"))
            {
                for (int i = 0; i < 10; ++i)
                {
                    Thread.Sleep(200);
                }
            }
        }
    }
}
