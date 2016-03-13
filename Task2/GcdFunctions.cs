using System;
using System.Diagnostics;

namespace Task2
{
    public static class GcdFunctions
    {
        #region Euclidean algorithm
        /// <summary>
        /// Returns the greatest common divisor of two numbers. GCD is calculated with Euclidean algorithm.
        /// Both of numbers must be not negative.
        /// Also returns the calculating time as an out parameter.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when firstNumber or secondNumber is less then or equal to 0;</exception>
        /// <param name="time">
        /// After the execution of the method this argument will contain the time spent on calculation.</param>
        /// <param name="firstNumber">The first number for GCD algorythm.</param>
        /// <param name="secondNumber">The second number for GCD algorythm.</param>
        /// <returns>The GCD of two specified numbers</returns>
        public static int Gcd(out double time, int firstNumber, int secondNumber)
        {
            if (firstNumber < 0)
            {
                throw new ArgumentOutOfRangeException("firstNumber must be greater then 0.");
            }
            if (secondNumber < 0)
            {
                throw new ArgumentOutOfRangeException("secondNumber must be greater then 0.");
            }
            timer.Restart();
            var result = firstNumber = PureGcd(firstNumber, secondNumber);
            timer.Stop();
            time = timer.Elapsed.TotalMilliseconds;
            return result;
        }

        /// <summary>
        /// Returns the greatest common divisor of three numbers. GCD is calculated with Euclidean algorithm.
        /// All numbers must be not negative.
        /// Also returns the calculating time as an out parameter.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when one of numbers is less then or equal to 0;</exception>
        /// <param name="time">
        /// After the execution of the method this argument will contain the time spent on calculation.</param>
        /// <param name="firstNumber">The first number for GCD algorythm.</param>
        /// <param name="secondNumber">The second number for GCD algorythm.</param>
        /// <param name="thirdNumber">The third number for GCD algorythm.</param>
        /// <returns>The GCD of three specified numbers</returns>
        public static int Gcd(out double time, int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber < 0)
            {
                throw new ArgumentOutOfRangeException("firstNumber must be greater then 0.");
            }
            if (secondNumber < 0)
            {
                throw new ArgumentOutOfRangeException("secondNumber must be greater then 0.");
            }
            if (thirdNumber < 0)
            {
                throw new ArgumentOutOfRangeException("thirdNumber must be greater then 0.");
            }
            timer.Restart();
            var result = PureGcd(PureGcd(firstNumber, secondNumber), thirdNumber);
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Returns the greatest common divisor of the set of numbers. GCD is calculated with Euclidean algorithm.
        /// All numbers must be not negative.
        /// Also returns the calculating time as an out parameter.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when one of numbers is less then or equal to 0;
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the numbers array is null;
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the count of numbers is less then 2.
        /// </exception>
        /// <param name="time">
        /// After the execution of the method this argument will contain the time spent on calculation.</param>
        /// <param name="numbers">The specified numbers for GCD algorythm.</param>
        /// <returns>The GCD of couple of numbers</returns>
        public static int Gcd(out double time, params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("numbers is null.");
            }
            if (numbers.Length < 2)
            {
                throw new ArgumentException("The GCD requires at least two numbers.");
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    throw new ArgumentOutOfRangeException($"The number at index {i} must be greater then 0");
                }
            }
            timer.Restart();
            int lastGcd = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                lastGcd = PureGcd(lastGcd, numbers[i]);
            }
            timer.Stop();
            time = timer.Elapsed.TotalMilliseconds;
            return lastGcd;
        }
        #endregion

        #region Binary Euclidean algorithm
        /// <summary>
        /// Returns the greatest common divisor of two numbers. GCD is calculated with binary Euclidean algorithm.
        /// Both of numbers must be not negative.
        /// Also returns the calculating time as an out parameter.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when firstNumber or secondNumber is less then 0;</exception>
        /// <param name="time">
        /// After the execution of the method this argument will contain the time spent on calculation.</param>
        /// <param name="firstNumber">The first number for GCD algorythm.</param>
        /// <param name="secondNumber">The second number for GCD algorythm.</param>
        /// <returns>The GCD of two specified numbers</returns>
        public static int BinaryGcd(out double time, int firstNumber, int secondNumber)
        {
            if (firstNumber < 0)
            {
                throw new ArgumentOutOfRangeException("firstNumber must be greater then -1.");
            }
            if (secondNumber < 0)
            {
                throw new ArgumentOutOfRangeException("secondNumber must be greater then -1.");
            }
            timer.Restart();
            var result = firstNumber = PureBinaryGcd(firstNumber, secondNumber);
            timer.Stop();
            time = timer.Elapsed.TotalMilliseconds;
            return result;
        }

        /// <summary>
        /// Returns the greatest common divisor of three numbers. GCD is calculated with binary Euclidean algorithm.
        /// All numbers must be not negative.
        /// Also returns the calculating time as an out parameter.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when one of numbers is less then 0;</exception>
        /// <param name="time">
        /// After the execution of the method this argument will contain the time spent on calculation.</param>
        /// <param name="firstNumber">The first number for GCD algorythm.</param>
        /// <param name="secondNumber">The second number for GCD algorythm.</param>
        /// <param name="thirdNumber">The third number for GCD algorythm.</param>
        /// <returns>The GCD of three specified numbers</returns>
        public static int BinaryGcd(out double time, int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber < 0)
            {
                throw new ArgumentOutOfRangeException("firstNumber must be greater then -1.");
            }
            if (secondNumber < 0)
            {
                throw new ArgumentOutOfRangeException("secondNumber must be greater then -1.");
            }
            if (thirdNumber < 0)
            {
                throw new ArgumentOutOfRangeException("thirdNumber must be greater then -1.");
            }
            timer.Restart();
            var result = PureBinaryGcd(PureBinaryGcd(firstNumber, secondNumber), thirdNumber);
            timer.Stop();
            time = timer.Elapsed.TotalMilliseconds;
            return result;
        }

        /// <summary>
        /// Returns the greatest common divisor of the set of numbers. GCD is calculated with binary Euclidean algorithm.
        /// All numbers must be not negative.
        /// Also returns the calculating time as an out parameter.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when one of numbers is less then 0;
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the numbers array is null;
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the count of numbers is less then 2.
        /// </exception>
        /// <param name="time">
        /// After the execution of the method this argument will contain the time spent on calculation.</param>
        /// <param name="numbers">The specified numbers for GCD algorythm.</param>
        /// <returns>The GCD of couple of numbers</returns>
        public static int BinaryGcd(out double time, params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("numbers is null.");
            }
            if (numbers.Length < 2)
            {
                throw new ArgumentException("The GCD requires at least two numbers.");
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    throw new ArgumentOutOfRangeException($"The number at index {i} must be greater then -1");
                }
            }
            timer.Restart();
            int lastGcd = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                lastGcd = PureBinaryGcd(lastGcd, numbers[i]);
            }
            timer.Stop();
            time = timer.Elapsed.TotalMilliseconds;
            return lastGcd;
        }
        #endregion

        #region Private parts
        // The pure gcd algorythm without validation and timer. 
        private static int PureGcd(int firstNumber, int secondNumber)
        {
            while (secondNumber != 0)
            {
                secondNumber = firstNumber % (firstNumber = secondNumber);
            }
            return firstNumber;
        }

        // The pure binary gcd algorythm without validation and timer.
        private static int PureBinaryGcd(int firstNumber, int secondNumber)
        {
            if (firstNumber == secondNumber || secondNumber == 0)
            {
                return firstNumber;
            }
            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if ((firstNumber & 1) != 1)// Parity check.
            {
                return (secondNumber & 1) != 1 ?
                    2 * PureBinaryGcd(firstNumber / 2, secondNumber / 2) :
                    PureBinaryGcd(firstNumber / 2, secondNumber);
            }
            if ((secondNumber & 1) != 1)
            {
                return PureBinaryGcd(firstNumber, secondNumber / 2);
            }
            else
            {
                return (firstNumber > secondNumber) ?
                    PureBinaryGcd((firstNumber - secondNumber) / 2, secondNumber) :
                    PureBinaryGcd((secondNumber - firstNumber) / 2, firstNumber);
            }
        }

        private static Stopwatch timer = new Stopwatch();
        #endregion
    }
}
