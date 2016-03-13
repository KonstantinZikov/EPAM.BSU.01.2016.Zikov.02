using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;
using System.Globalization;
namespace Task4Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void ToString_FormatWithoutProvider_FormattedView()
        {
            //arrange
            var customer = new Customer()
            {
                Name = "Konstantin Zikov",
                ContactPhone = "+375 (29) 9999999",
                Revenue = 1000.000m
            };
            string expected = "Record: Konstantin Zikov, +375 (29) 9999999, 1000.000.";
            //act
            string actual = customer.ToString("Record: $N, $P, $R.");

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_FormatWithGermanProvider_GermanFormattedRevenueView()
        {
            //arrange
            var customer = new Customer()
            {
                Name = "Konstantin Zikov",
                ContactPhone = "+375 (29) 9999999",
                Revenue = 1000.000m
            };
            string expected = "Revenue: 1000,000.";
            var ci = new CultureInfo("de-DE");
            //act
            string actual = customer.ToString("Revenue: $R.", ci);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_FormatWithDoubleDollarSymbol_OneDollarSymbolInView()
        {
            //arrange
            var customer = new Customer()
            {
                Name = "Konstantin Zikov",
                ContactPhone = "+375 (29) 9999999",
                Revenue = 1000.000m
            };
            string expected = "$";
            //act
            string actual = customer.ToString("$$");

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_FormatWithUnsupportedSymbolAfterDollar_DollarAndSymbolInView()
        {
            //arrange
            var customer = new Customer()
            {
                Name = "Konstantin Zikov",
                ContactPhone = "+375 (29) 9999999",
                Revenue = 1000.000m
            };
            string expected = "$Y";
            //act
            string actual = customer.ToString("$Y");

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_WithGermanProvider_GermanFormattedRevenueView()
        {
            //arrange
            var customer = new Customer()
            {
                Name = "Konstantin Zikov",
                ContactPhone = "+375 (29) 9999999",
                Revenue = 1000.000m
            };
            string expected = "Customer record: Konstantin Zikov, +375 (29) 9999999, 1000,000";
            var ci = new CultureInfo("de-DE");

            //act
            string actual = customer.ToString(ci);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_OverridedMethod_FormattedByDefaultProvider()
        {
            //arrange
            object customer = new Customer()
            {
                Name = "Konstantin Zikov",
                ContactPhone = "+375 (29) 9999999",
                Revenue = 1000.000m
            };
            string expected = "Customer record: Konstantin Zikov, +375 (29) 9999999, 1000.000.";

            //act
            string actual = customer.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
