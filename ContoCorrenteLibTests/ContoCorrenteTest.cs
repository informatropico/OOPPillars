using System.Collections.Generic;
using ContoCorrenteLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContoCorrenteLibTests
{
    [TestClass]
    public class ContoCorrenteTest
    {
        private ContoCorrente contoRisparmioUnderTest;
        private ContoCorrente contoMutuoUnderTest;
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
            this.contoMutuoUnderTest = this.mutuoIBANInterno(contoRisparmio) as ContoMutuo;

            // Assert
            Assert.AreEqual(-100000.00M, this.contoMutuoUnderTest.Saldo);
            Assert.AreEqual(0, this.contoMutuoUnderTest.ElencoOperazioni.Count);
        }

        [TestMethod]
        public void ContoRisparmioDeposita()
        {
            // Arrange
            this.contoRisparmioUnderTest = this.contoSogliaZeroImportoIniziale();

            // Act
            this.contoRisparmioUnderTest.Deposita(1000.00M, "Prova deposito");

            // Assert
            Assert.AreEqual(2, this.contoRisparmioUnderTest.ElencoOperazioni.Count);
            Assert.AreEqual(2000.00M, this.contoRisparmioUnderTest.Saldo);
        }

        [TestMethod]
        public void ContoRisparmioPreleva()
        {
            // Arrange
            this.contoRisparmioUnderTest = this.contoSogliaZeroImportoIniziale();

            // Act
            this.contoRisparmioUnderTest.Preleva(900.00M, "Prova deposito");

            // Assert
            Assert.AreEqual(2, this.contoRisparmioUnderTest.ElencoOperazioni.Count);
            Assert.AreEqual(100.00M, this.contoRisparmioUnderTest.Saldo);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), "Operazione non concessa")]
        public void ContoRisparmioPrelevaEccezione()
        {
            // Arrange
            this.contoRisparmioUnderTest = this.contoSogliaZeroImportoIniziale();

            // Act
            this.contoRisparmioUnderTest.Preleva(10000.00M, "Prova deposito");

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(System.Exception), "Mutuo estinto")]
        public void ContoMutuoEstintoDepositoEccezione()
        {
            // Arrange
            var contoRisparmio = this.contoSogliaZeroImportoIniziale();
            this.contoMutuoUnderTest = this.mutuoIBANInternoEstinto(contoRisparmio);

            // Act
            this.contoMutuoUnderTest.Deposita(100.00M, "Rata mutuo");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), "Saldo non sufficiente per pagare la rata")]
        public void ContoMutuoDepositoNonCoperto()
        {
            // Arrange
            var contoRisparmio = this.contoSogliaZeroImportoIniziale();
            this.contoMutuoUnderTest = this.mutuoIBANInterno(contoRisparmio);

            // Act
            this.contoMutuoUnderTest.Deposita(1001.00M, "Rata mutuo");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), "Operazione non concessa")]
        public void ContoMutuoPrelievoEccezione()
        {
            // Arrange
            var contoRisparmio = this.contoSogliaZeroImportoIniziale();
            this.contoMutuoUnderTest = this.mutuoIBANInterno(contoRisparmio);

            // Act
            this.contoMutuoUnderTest.Preleva(100.00M, "Rata mutuo");
        }

        [TestMethod]
        public void ContoMutuoEsternoDeposito()
        {
            // Arrange
            this.contoMutuoUnderTest = this.mutuoIBANEsterno();

            // Act
            this.contoMutuoUnderTest.Deposita(100.00M, "Rata mutuo");

            // Assert
            Assert.AreEqual(-99900.00M, this.contoMutuoUnderTest.Saldo);
            Assert.AreEqual(1, this.contoMutuoUnderTest.ElencoOperazioni.Count);
        }

        [TestMethod]
        public void ContoMutuoInternoDeposito()
        {
            // Arrange
            var contoRisparmio = this.contoSogliaZeroImportoIniziale();
            this.contoMutuoUnderTest = this.mutuoIBANInterno(contoRisparmio);

            // Act
            this.contoMutuoUnderTest.Deposita(100.00M, "Rata mutuo");

            // Assert
            Assert.AreEqual(-99900.00M, this.contoMutuoUnderTest.Saldo);
            Assert.AreEqual(900.00M, contoRisparmio.Saldo);
            Assert.AreEqual(1, this.contoMutuoUnderTest.ElencoOperazioni.Count);
            Assert.AreEqual(2, contoRisparmio.ElencoOperazioni.Count);
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

        private ContoMutuo mutuoIBANInternoEstinto(ContoRisparmio contoRisparmio)
        {
            return new ContoMutuo(
                intestatari: this.intestatari,
                importoMutuo: 0.00M,
                contoRisparmioAssociato: contoRisparmio
            );
        }
    }
}