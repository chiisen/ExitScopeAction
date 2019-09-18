using ExitScope;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestTool;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            MSTestLog.Initialize();
        }

        [TestMethod]
        public void TestMethod()
        {
            void exitCall_(long t, string x)
            {
                MSTestLog.WriteLine($"{x} °õ¦æ {t} ms");
            }

            using (var tms = new TimeMeasureScope(exitCall_, "for loop"))
            {

                Thread.Sleep(2000);
            }
        }
    }
}
