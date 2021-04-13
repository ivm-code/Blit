using System;
using System.Collections.Generic;
using System.Text;

namespace Blit
{
    public class TransformationRules
    {
        /// <summary>
        /// Dictionary with predefined rules for converting pyramid elements 
        /// </summary>
        public static Dictionary<string, string> blitPairs = new Dictionary<string, string>()
        {
            { "0000", "0000" },
            { "0001", "1000" },
            { "0010", "0001" },
            { "0011", "0010" },
            { "0100", "0000" },
            { "0101", "0010" },
            { "0110", "1011" },
            { "0111", "1011" },
            { "1000", "0100" },
            { "1001", "0101" },
            { "1010", "0111" },
            { "1011", "1111" },
            { "1100", "1101" },
            { "1101", "1110" },
            { "1110", "0111" },
            { "1111", "1111" }
        };
    }
}
