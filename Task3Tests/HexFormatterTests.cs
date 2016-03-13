using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace Task3Tests
{
    [TestClass]
    public class HexFormatterTests
    {
        [TestMethod]
        public void Format_ByteValueAndUppercaseFormatSymbol_UppercaseHexView()
        {
            //arrange
            byte number = 145;
            string expected = "0X91";

            //act
            string actual = string.Format(new HexFormatter(), "{0:X}", number);

            //assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void Format_SbyteValueAndUppercaseFormatSymbol_UppercaseHexView()
        {
            //arrange
            sbyte number = -74;
            string expected = "-0X4A";

            //act
            string actual = string.Format(new HexFormatter(), "{0:X}", number);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_LongValueAndLowercaseFormatSymbol_LowercaseHexView()
        {
            //arrange
            long number = -34359738343;
            string expected = "-0x7ffffffe7";

            //act
            string actual = string.Format(new HexFormatter(), "{0:x}", number);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_UlongValueAndLowercaseFormatSymbol_LowercaseHexView()
        {
            //arrange
            ulong number = 549755814567;
            string expected = "0x80000002a7";

            //act
            string actual = string.Format(new HexFormatter(), "{0:x}", number);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Format_IntValueAndUnsupportedFormatSymbol_FormatException()
        {
            //arrange
            int number = 4356546;

            //act
            string.Format(new HexFormatter(), "{0:H}", number);

            //assert is handled by excpetion
        }

        [TestMethod]
        public void Format_ObjectValueAndLowercaseFormatSymbol_StringViewOfObject()
        {
            //arrange
            object obj = new object();
            string expected = obj.ToString();

            //act
            string actual = string.Format(new HexFormatter(), "{0:x}", obj);

            //assert is handled by excpetion
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_IntValueAndFormatSymbolSuppotedByDefaultProvider_FormattedResult()
        {
            //arrange
            int number = 45;
            string expected = "$45.00";

            //act
            string actual = string.Format(new HexFormatter(), "{0:C}", number);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
