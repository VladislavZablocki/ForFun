using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace CryptoLibrary
{
    public static class Utils
    {
        public static string AddZerosAtBegin(string number, int numberOfDigit)
        {
            StringBuilder sb = new StringBuilder(number);
            var dif = numberOfDigit - number.Length;
            if (dif > 0)
            {
                sb.Insert(0, "0", dif);
            }
            return sb.ToString();
        }

        public static int GetCountOfDifferentNumber(this string a, string b)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    count++;
                }
            }
            return count;
        }

        public static string GetByteAfterSubByte(string Byte)
        {
            var X = int.Parse(NumberExtension.ConvertHexToDec(Byte[0].ToString()));
            var Y = int.Parse(NumberExtension.ConvertHexToDec(Byte[1].ToString()));
            return Resources.SBox[X][Y];
        }

        public static string Calculate1ByteMixColumt(this List<string> state, int iteration)
        {
            int column = iteration / 4;
            var columnElements = new List<string>
            {
                state[0 + 4 * column],
                state[1 + 4 * column],
                state[2 + 4 * column],
                state[3 + 4 * column]
            };
            int row = iteration % 4;
            List<string> sum = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                sum.Add(columnElements[i].Multiplication(Resources.MixColumnsMatrix[row][i]));
            }

            var result = sum.Sum();
            return result.Length == 3 ? result.XORhex(Resources.Module) : Utils.AddZerosAtBegin(result, 2);
        }

        public static void WriteToFile(this List<List<string>> messageList, string path = "keys.txt")
        {
            using (StreamWriter sw = new StreamWriter("keys.txt"))
            {
                foreach (var item in messageList)
                {
                    sw.WriteLine(item.ConvertListToString());
                }
            }
        }

        public static void PrintStatistic(this string key)
        {
            Dictionary<string, int> matches = new Dictionary<string, int>();
            for (int i = 0; i < 16; i++)
            {
                var num = NumberExtension.ConvertDecToHex(i, 1);
                matches.Add(num, new Regex(num).Matches(key).Count);
            }

            matches = matches.OrderByDescending(i => i.Value).ToDictionary(i => i.Key, i => i.Value);

            Console.WriteLine($"Key \n{key}");

            foreach (var item in matches)
            {
                Console.WriteLine($"number: {item.Key} | count: {item.Value}");
            }
        }
    }
}