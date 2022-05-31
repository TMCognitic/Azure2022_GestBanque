using Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tests
{
    [TestClass]
    public class TemperatureTest
    {
        [TestMethod]
        public void CelsiusToFahrenheitTest()
        {
            Celsius celsius = new Celsius() { Temperature = 30D };

            Fahrenheit fahrenheit = celsius;

            Assert.AreEqual(86D, fahrenheit.Temperature);
        }

        [TestMethod]
        public void FahrenheitToCelsiusTest()
        {
            Fahrenheit fahrenheit = new Fahrenheit() { Temperature = 86D };

            Celsius celsius = (Celsius)fahrenheit;

            Assert.AreEqual(30D, celsius.Temperature);
        }

    }
}
