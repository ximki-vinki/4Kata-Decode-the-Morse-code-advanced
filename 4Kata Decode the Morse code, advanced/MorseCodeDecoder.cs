using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Kata_Decode_the_Morse_code__advanced
{
    internal class MorseCodeDecoder
    {
        public static string DecodeBits(string bits)
        {

            List<int> bitsList = bits.Select(x => x - '0').ToList();
            StringBuilder dotsAndDash = new StringBuilder();

            while (bitsList[0] == 0) bitsList.Remove(0);
            while (bitsList.Last() == 0) bitsList.RemoveAt(bitsList.Count - 1);
            if (bitsList.Where(x => x == 1).Count() == bitsList.Count) return (".");

            int countTime = 0;
            for (; bitsList[countTime] == bitsList[countTime + 1]; countTime++) ;
            //int countTimeZero =0;
           // for (; bitsList[countTime+ countTimeZero+1] == bitsList[countTime + 2+ countTimeZero]; countTimeZero++) ;
            int lenghtBitsList = bitsList.Count;
            if ((countTime+1) % 3 == 0) countTime=(countTime+1) / 3-1;
            
            if (countTime > 0 ) for (int i = lenghtBitsList - 1; i > 0; i -= 1 + countTime ) bitsList.RemoveAt(i);

            int countZero = 0;
            int countOne = 0;
            for (int i = 0; i < bitsList.Count; i++)
            {
                if (bitsList[i] == 1)
                {
                    countOne++;
                    countZero = 0;
                }
                if (bitsList[i] == 0) countZero++;
                if (countOne == 3 && (countZero == 1 || i == bitsList.Count - 1))
                {
                    dotsAndDash.Append("-");
                    countOne = 0;
                }
                if (countOne == 1 && (countZero == 1 || i == bitsList.Count - 1))
                {
                    dotsAndDash.Append(".");
                    countOne = 0;
                }
                if (countZero == 3 && bitsList[i + 1] == 1) dotsAndDash.Append(" ");

                if (countZero == 7) dotsAndDash.Append("   ");
            }
            return String.Concat(dotsAndDash);
        }
        public static string DecodeMorse(string morseCode)
        {
            return string.Concat(morseCode.Trim().Replace("   ", "  ").Split().Select(x => x == "" ? " " : MorseCode.Get(x)));
        }
    }
}
