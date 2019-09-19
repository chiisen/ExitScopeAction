using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestTool;

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
            MSTestLog.WriteLine("³æ¤¸´ú¸Õ");
        }
    }
}
