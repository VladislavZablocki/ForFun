using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoLibrary
{
    public static class Operations
    {
        public static string XORbin(this string first, string second)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < first.Length; i++)
            {
                var addedChar = first[i] == second[i] ? "0" : "1";
                sb.Append(addedChar);
            }
            return sb.ToString();
        }

        public static string XORhex(this string first, string second) =>
            NumberExtension.ConvertBinToHex(NumberExtension.ConvertHexToBin(first).XORbin(NumberExtension.ConvertHexToBin(second)));

        public static List<string> XORhexList(this List<string> first, List<string> second)
        {
            for (int i = 0; i < first.Count; i++)
            {
                first[i] = first[i].XORhex(second[i]);
            }
            return first;
        }

        public static string Multiplication(this string number, int coef)
        {
            var result = string.Empty;
            if (coef == 1)
            {
                result = number;
            }
            else if (coef == 2)
            {
                result = Mult2(number);
            }
            else if (coef == 3)
            {
                result = Mult2(number).XORhex(number);
            }
            return result.Length == 3 ? result.XORhex(Resources.Module) : Utils.AddZerosAtBegin(result, 2);
        }

        private static string Mult2(string number)
        {
            var result = string.Empty;
            result = NumberExtension.ConvertDecToHex(int.Parse(NumberExtension.ConvertHexToDec(number)) * 2);
            return result.Length == 3 ? result.XORhex(Resources.Module) : Utils.AddZerosAtBegin(result, 2);
        }

        public static string Sum(this List<string> list)
        {
            var result = "00";
            foreach (var item in list)
            {
                result = result.XORhex(item);
            }
            return result;
        }

    }
}
