using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Customer
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
