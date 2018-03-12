using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoLibrary
{
    public static class CollectionExtension
    {
        public static List<string> SplitStringToListOfStringThroughSeparators(string splitString) =>
            splitString.Split(' ', ';', '.').ToList();

        public static List<int> SplitStringToListOfIntThroughSeparators(string splitString) =>
            splitString.Split(' ', ';', '.').Select(int.Parse).ToList();
        
        public static List<List<string>> ConvertListOfListToBin(List<List<string>> list)
        {
            var temp = new List<List<string>>();
            for (int row = 0; row < list.Count; row++)
            {
                temp.Add(new List<string>());
                for (int item = 0; item < list[0].Count; item++)
                {
                    temp[row].Add(NumberExtension.ConvertHexToBin(list[row][item]));
                }
            }
            return temp;
        }

        public static List<string> ConvertListOfBinToHex(List<string> list)
        {
            var temp = new List<string>();
            foreach (var item in list)
            {
                temp.Add(NumberExtension.ConvertBinToHex(item));
            }
            return temp;
        }

        public static string ConvertListToString(this List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item);
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public static List<string> Offset(this List<string> mask, int offset)
        {
            var result = mask.GetRange(offset, mask.Count-offset);
            result.AddRange(mask.GetRange(0, offset));
            return result;
        }
    }
}
