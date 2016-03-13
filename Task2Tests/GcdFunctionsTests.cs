using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Task2.GcdFunctions;

namespace Task2Tests
{ 
    [TestClass]
    public class GcdFunctionsTests
    {

        #region Gcd tests
        [TestMethod]
        public void Gcd_Put42and18_Expected6()
        {
            //arrange
            int a = 42;
            int b = 18;
            double time;

            int expected = 6;

            //act
            int actual = Gcd(out time, a, b);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Gcd_Put42andMinus3_ArgumentOutOfRangeException()
        {
            //arrange
            int a = 42;
            int b = -3;
            double time;

            //act
            int actual = Gcd(out time, a, b);

            //assert are handled by exception
        }

        [TestMethod]
        public void Gcd_Put42and18and21_Expected3()
        {
            //arrange
            int a = 42;
            int b = 18;
            int c = 21;
            double time;

            int expected = 3;

            //act
            int actual = Gcd(out time, a, b, c);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Gcd_PutMinus15and18and21_ArgumentOutOfRangeException()
        {
            //arrange
            int a = -15;
            int b = 18;
            int c = 21;
            double time;

            //act
            int actual = Gcd(out time, a, b, c);

            //assert are handled by exception
        }

        [TestMethod]
        public void Gcd_Put42and18and21and5_Expected1()
        {
            //arrange
            int a = 42;
            int b = 18;
            int c = 21;
            int d = 5;
            double time;

            int expected = 1;

            //act
            int actual = Gcd(out time, a, b, c, d);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Gcd_PutNullArray_ArgumentNullException()
        {
            //arrange
            int[] array = null;
            double time;

            //act
            int actual = Gcd(out time, array);

            //assert is handled by exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Gcd_PutArrayWithNegativeElement_ArgumentOutOfRangeException()
        {
            //arrange
            int[] array = new[] {17,5,-7,23};
            double time;

            //act
            int actual = Gcd(out time, array);

            //assert is handled by exception
        }

        #endregion

        #region BinaryGcd tests
        [TestMethod]
        public void BinaryGcd_Put74and8_Expected2()
        {
            //arrange
            int a = 74;
            int b = 8;
            double time;

            int expected = 2;

            //act
            int actual = BinaryGcd(out time, a, b);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BinaryGcd_PutMinus78and15_ArgumentOutOfRangeException()
        {
            //arrange
            int a = -78;
            int b = 15;
            double time;

            //act
            int actual = BinaryGcd(out time, a, b);

            //assert are handled by exception
        }

        [TestMethod]
        public void BinaryGcd_Put42and18and21_Expected3()
        {
            //arrange
            int a = 100;
            int b = 10;
            int c = 45;
            double time;

            int expected = 5;

            //act
            int actual = BinaryGcd(out time, a, b, c);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinaryGcd_Put0and18and21_Expected6()
        {
            //arrange
            int a = 0;
            int b = 18;
            int c = 24;
            double time;

            int expected = 6;

            //act
            int actual = BinaryGcd(out time, a, b, c);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinaryGcd_Put42and18and21and5_Expected1()
        {
            //arrange
            int a = 42;
            int b = 18;
            int c = 21;
            int d = 5;
            double time;

            int expected = 1;

            //act
            int actual = BinaryGcd(out time, a, b, c, d);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinaryGcd_PutNullArray_ArgumentNullException()
        {
            //arrange
            int[] array = null;
            double time;

            //act
            int actual = BinaryGcd(out time, array);

            //assert is handled by exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BinaryGcd_PutArrayWithElementEqualToMinus1_ArgumentOutOfRangeException()
        {
            //arrange
            int[] array = new[] { 17, 5, -1, 23 };
            double time;

            //act
            int actual = BinaryGcd(out time, array);

            //assert is handled by exception
        }
        #endregion
    }
}
