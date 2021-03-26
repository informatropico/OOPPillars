using ContoCorrenteLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContoCorrenteLibTests
{
    [TestClass]
    public class IBANTest
    {
        [TestMethod]
        public void CreaIBAN()
        {
            IBAN ibanUnderTest = new IBAN();
            Assert.AreEqual("IT02L1234500000100000000001",ibanUnderTest.CodiceIBAN);
        }
    }
}
