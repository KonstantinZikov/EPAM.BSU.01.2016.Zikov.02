using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Customer : IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }


        public override string ToString()
        {
            return ToString();
        }

        public string ToString(IFormatProvider provider = null)
        {
            return "Customer record: " +
                Name + ", " + ContactPhone + ", " + Revenue.ToString(provider) + ".";
        }


        /// <summary>
        /// Formats this instance of Customer according to the next rules:
        /// 1) "$N" transformed to Name property value;
        /// 2) "$P" transformed to ContactPhone property value;
        /// 3) "$R" transformed to Revenue property value;
        /// 4) "$$" transformed to single $ sumbol;
        /// 5) Other symbols sets remain the same.
        /// </summary>
        /// <param name="format">The format string, which will be transformed according to certain rules.</param>
        /// <param name="provider">Provider for formatting the Revenue property.</param>
        /// <returns>Formatted string view of this instance.</returns>
        public string ToString(string format, IFormatProvider provider = null)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < format.Length;i++)
            {
                if (format[i] == '$' && i < format.Length - 1)
                {
                    i++;
                    switch(format[i])
                    {
                        case 'N':
                            sb.Append(Name);
                            break;
                        case 'P':
                            sb.Append(ContactPhone);
                            break;
                        case 'R':
                            sb.Append(Revenue.ToString(provider));
                            break;
                        case '$':
                            sb.Append('$');
                            break;
                        default:
                            sb.Append('$');
                            sb.Append(format[i]);
                            break;
                    }
                }
                else
                {
                    sb.Append(format[i]);
                }
            }
            return sb.ToString();        
        }
    }
}
