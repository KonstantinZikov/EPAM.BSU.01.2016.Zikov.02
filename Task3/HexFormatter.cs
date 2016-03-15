using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Task3
{
    public class HexFormatter : IFormatProvider, ICustomFormatter
    {
        private static readonly List<Type> SupportedTypes = new List<Type>
        {
            typeof(sbyte),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(byte),
            typeof(ushort),
            typeof(uint),
            typeof(ulong)
        };

        private static readonly Dictionary<ulong, string> SymbolMap = new Dictionary<ulong, string>
        {
            {0,"0"},{1,"1"},{2,"2"},{3,"3"},{4,"4"},{5,"5"},{6,"6"},{7,"7"},
            {8,"8"},{9,"9"},{10,"A"},{11,"B"},{12,"C"},{13,"D"},{14,"E"},{15,"F"}
        };


        /// <summary>
        /// Convert integer value to hexadecimal view. Use the 'X' symbol for uppercase and 'x' for lowercase view.
        /// Supported types: sbyte, byte, int, long, byte, ushort, uint, ulong. 
        /// </summary>
        /// <param name="format">"string with format symbols. Must be 'X' or 'x'."</param>
        /// <param name="arg">Formatted value. Not-Integer types are not supported.</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string with hexadecimal view of specified integer value.</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Provide default formatting if arg is not implemented.
            if (!SupportedTypes.Contains(arg.GetType()))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", format), e);
                }
            }

            // Provide default formatting for unsupported format strings.
            if (format != "X" && format != "x")
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", format), e);
                }
            }

            return  format == "X" ?
                Convert(arg).ToUpperInvariant().ToString() :
                Convert(arg).ToLowerInvariant().ToString();
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        private StringBuilder Convert(object arg)
        {
            // Converting.
            StringBuilder sb = new StringBuilder();
            decimal decimalNumber = decimal.Parse(arg.ToString());
            bool isNegative = false;
            if (decimalNumber < 0)
            {
                isNegative = true;
                decimalNumber *= -1;
            }
            ulong number = (ulong)decimalNumber;
            while (number > 15)
            {
                sb.Append(SymbolMap[number % 16]);
                number = number / 16;
            }
            sb.Append(SymbolMap[number]).Append("x0");
            if (isNegative)
            {
                sb.Append('-');
            }
            return sb.Reverse();
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            return string.Empty;
        }
    }
}
