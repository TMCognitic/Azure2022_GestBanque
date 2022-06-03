namespace Models.Tests
{
    [TestClass]
    public class CourantTests
    {
        [TestMethod]
        public void TestInstaciation()
        {
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));

            Courant courant = new Courant("001", 500, personne);

            Assert.IsNotNull(courant);
        }

        [TestMethod]
        public void TestLigneDeCredit()
        {
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("001", -500, personne);

            Assert.AreEqual(0D, courant.LigneDeCredit);
        }

        [TestMethod]
        public void TestDepot1()
        {
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("001", 500, personne);

            courant.Depot(-500);

            Assert.AreEqual(0D, courant.Solde);
        }

        [TestMethod]
        public void TestDepot2()
        {
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("001", 500, personne);

            courant.Depot(500);

            Assert.AreEqual(500D, courant.Solde);
        }

        [TestMethod]
        public void TestRetrait1()
        {
            //Assignation
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("001", 0, personne);

            //Acte
            courant.Retrait(-500);

            //Asserts
            Assert.AreEqual(0D, courant.Solde);
        }

        [TestMethod]
        public void TestRetrait2()
        {
            //Assignation
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("001", 0, personne);


            //Acte
            courant.Retrait(500);

            //Asserts
            Assert.AreEqual(0D, courant.Solde);
        }

        [TestMethod]
        public void TestRetrait3()
        {
            //Assignation
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("001", 1000, personne);

            //Acte
            courant.Retrait(500);

            //Asserts
            Assert.AreEqual(-500D, courant.Solde);
        }
    }
}