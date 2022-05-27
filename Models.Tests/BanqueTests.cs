using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tests
{
    [TestClass]
    public class BanqueTests
    {
        [TestMethod]
        public void TestInstaciation()
        {
            Banque banque = new Banque()
            {
                Nom = "TFTIC Banking"
            };


            Assert.IsNotNull(banque);            
        }

        [TestMethod]
        public void TestAddAccount()
        {
            Banque banque = new Banque()
            {
                Nom = "TFTIC Banking"
            };

            Courant courant = new Courant() { Numero = "0001" };

            banque.Ajouter(courant);

            Assert.AreEqual(1, banque.Count);
        }

        [TestMethod]
        public void TestRemoveAccount1()
        {
            Banque banque = new Banque()
            {
                Nom = "TFTIC Banking"
            };

            Courant courant = new Courant() { Numero = "0001" };

            banque.Ajouter(courant);
            bool result = banque.Supprimer(courant.Numero);

            Assert.AreEqual(0, banque.Count);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRemoveAccount2()
        {
            Banque banque = new Banque()
            {
                Nom = "TFTIC Banking"
            };

            Courant courant = new Courant() { Numero = "0001" };

            banque.Ajouter(courant);
            bool result = banque.Supprimer("0002");

            Assert.AreEqual(1, banque.Count);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIndexer()
        {
            Banque banque = new Banque()
            {
                Nom = "TFTIC Banking"
            };

            Courant courant = new Courant() { Numero = "0001" };
            banque.Ajouter(courant);

            courant = banque["0001"];

            Assert.IsNotNull(courant);
        }
    }
}
