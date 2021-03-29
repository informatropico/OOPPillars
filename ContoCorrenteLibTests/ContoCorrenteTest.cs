using System.Collections.Generic;
using ContoCorrenteLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContoCorrenteLibTests
{
    [TestClass]
    public class ContoCorrenteTest
    {
        private ContoRisparmio contoRisparmioUnderTest;
        private ContoMutuo contoMutuoUnderTest;
        private ICollection<Intestatario> intestatari;

        [TestInitialize]
        public void Init()
        {
            this.intestatari = this.UnIntestatario();
        }
        
        [TestMethod]
        public void CreaContoRisparmioConImportoIniziale()
        {
            // Arrange          

            // Act
            this.contoRisparmioUnderTest = this.contoSogliaZeroImportoIniziale();

            // Assert
            Assert.AreEqual(1000.00M, this.contoRisparmioUnderTest.Saldo);
            Assert.AreEqual(1, this.contoRisparmioUnderTest.ElencoOperazioni.Count);
        }

        [TestMethod]
        public void CreaContoRisparmioConSogliaNegativa()
        {
            // Arrange
            this.intestatari = this.UnIntestatario();

            // Act
            this.contoRisparmioUnderTest = this.contoSogliaNegativaImportoInizialeZero();

            // Assert
            Assert.AreEqual(0.00M, this.contoRisparmioUnderTest.Saldo);
            Assert.AreEqual(0, this.contoRisparmioUnderTest.ElencoOperazioni.Count);
        }

        [TestMethod]
        public void CreaContoMutuoConIBANEsterno()
        {
            // Arrange

            // Act
            this.contoMutuoUnderTest = this.mutuoIBANEsterno();

            // Assert
            Assert.AreEqual(-100000.00M, this.contoMutuoUnderTest.Saldo);
            Assert.AreEqual(0, this.contoMutuoUnderTest.ElencoOperazioni.Count);
        }

        [TestMethod]
        public void CreaContoRisparmioConIBANInterno()
        {
            // Arrange
            var contoRisparmio = this.contoSogliaNegativaImportoInizialeZero();

            // Act
            this.contoMutuoUnderTest = this.mutuoIBANInterno(contoRisparmio);

            // Assert
            Assert.AreEqual(-100000.00M, this.contoMutuoUnderTest.Saldo);
            Assert.AreEqual(0, this.contoMutuoUnderTest.ElencoOperazioni.Count);
            Assert.AreEqual(contoRisparmio.IBAN.CodiceIBAN, this.contoMutuoUnderTest.IBANAssociato.CodiceIBAN);
        }

        private List<Intestatario> UnIntestatario()
        {
            return new List<Intestatario>()
            {
                new Intestatario("AAABBB92A19G888W", "Aaa", "Bbb")
            };
        }

        private ContoRisparmio contoSogliaZeroImportoIniziale()
        {
            return new ContoRisparmio(
                intestatari: this.intestatari,
                soglia: 0.00M,
                importoIniziale: 1000.00M
            );
        }

        private ContoRisparmio contoSogliaNegativaImportoInizialeZero()
        {
            return new ContoRisparmio(
                intestatari: this.intestatari,
                soglia: -1000.00M,
                importoIniziale: 0.00M
            );
        }

        private ContoMutuo mutuoIBANEsterno()
        {
            return new ContoMutuo(
                intestatari: this.intestatari,
                importoMutuo: 100000.00M,
                IBANAssociato: "IT02L1234500000200000000011"
            );
        }

        private ContoMutuo mutuoIBANInterno(ContoRisparmio contoRisparmio)
        {
            return new ContoMutuo(
                intestatari: this.intestatari,
                importoMutuo: 100000.00M,
                contoRisparmioAssociato: contoRisparmio
            );
        }
    }
}