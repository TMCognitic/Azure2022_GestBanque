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
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestLigneDeCredit()
        {
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("001", -500, personne);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDepot1()
        {
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("001", 500, personne);

            courant.Depot(-500);
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRetrait1()
        {
            //Assignation
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("001", 0, personne);

            //Acte
            courant.Retrait(-500);
        }

        [TestMethod]
        [ExpectedException(typeof(SoldeInsuffisantException))]
        public void TestRetrait2()
        {
            //Assignation
            Personne personne = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("001", 0, personne);


            //Acte
            courant.Retrait(500);
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