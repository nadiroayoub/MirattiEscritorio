using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MirattiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Initialize()
        {

        }
        [TestMethod]
        public void TestPagoVerificado()
        {
            string test = "HomePage";
            Assert.IsTrue(string.Equals(test, "HomePage") || string.Equals(test, string.Empty));


        }
    }
}
