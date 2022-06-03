using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tests
{
    [TestClass]
    public class PersonneTests
    {
        [TestMethod]
        public void TestInstanciation()
        {
            //Affectation
            Personne personne = new Personne("Doe", "John",new DateTime(1970, 1, 1));

            //Acte

            //Asserts
            Assert.IsNotNull(personne);
        }
    }
}
