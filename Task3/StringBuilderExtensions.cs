using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder Reverse(this StringBuilder sb)
        {
            for (int i = 0; i < sb.Length / 2; i++)
            {
                char tmp = sb[i];
                sb[i] = sb[sb.Length - 1 - i];
                sb[sb.Length - 1 - i] = tmp;
            }
            return sb;
        }

        public static StringBuilder ToUpperInvariant(this StringBuilder sb)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] = char.ToUpperInvariant(sb[i]);
            }
            return sb;
        }

        public static StringBuilder ToLowerInvariant(this StringBuilder sb)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] = char.ToLowerInvariant(sb[i]);
            }
            return sb;
        }
    }
}
