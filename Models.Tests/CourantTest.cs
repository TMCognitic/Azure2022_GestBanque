namespace Models.Tests
{
    [TestClass]
    public class CourantTest
    {
        [TestMethod]
        public void TestInstaciation()
        {
            Personne personne = new Personne()
            {
                Nom = "Doe",
                Prenom = "John",
                DateNaiss = new DateTime(1970, 1, 1)
            };

            Courant courant = new Courant()
            {
                Numero = "001",
                LigneDeCredit = 500,
                Titulaire = personne
            };

            Assert.IsNotNull(courant);
        }

        [TestMethod]
        public void TestLigneDeCredit()
        {
            Courant courant = new Courant()
            {
                Numero = "001",
                LigneDeCredit = -500,
                Titulaire = null
            };

            Assert.AreEqual(0D, courant.LigneDeCredit);
        }

        [TestMethod]
        public void TestDepot1()
        {
            Courant courant = new Courant()
            {
                Numero = "001",
                LigneDeCredit = -500,
                Titulaire = null
            };

            courant.Depot(-500);

            Assert.AreEqual(0D, courant.Solde);
        }

        [TestMethod]
        public void TestDepot2()
        {
            Courant courant = new Courant()
            {
                Numero = "001",
                LigneDeCredit = -500,
                Titulaire = null
            };

            courant.Depot(500);

            Assert.AreEqual(500D, courant.Solde);
        }

        [TestMethod]
        public void TestRetrait1()
        {
            //Assignation
            Courant courant = new Courant()
            {
                Numero = "001",
                LigneDeCredit = 0,
                Titulaire = null
            };

            //Acte
            courant.Retrait(-500);

            //Asserts
            Assert.AreEqual(0D, courant.Solde);
        }

        [TestMethod]
        public void TestRetrait2()
        {//Assignation
            Courant courant = new Courant()
            {
                Numero = "001",
                LigneDeCredit = 0,
                Titulaire = null
            };

            //Acte
            courant.Retrait(500);

            //Asserts
            Assert.AreEqual(0D, courant.Solde);
        }

        [TestMethod]
        public void TestRetrait3()
        {
            //Assignation
            Courant courant = new Courant()
            {
                Numero = "001",
                LigneDeCredit = 1000,
                Titulaire = null
            };

            //Acte
            courant.Retrait(500);

            //Asserts
            Assert.AreEqual(-500D, courant.Solde);
        }
    }
}