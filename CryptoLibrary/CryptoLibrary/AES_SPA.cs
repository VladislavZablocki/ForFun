using System.Collections.Generic;
using System.Linq;

namespace CryptoLibrary
{
    public class AES_SPA
    {
        public string[] Key { get; private set; }

        private readonly List<List<string>> messages;

        private readonly List<List<int>> hammingWeights;

        private List<List<string>> possibleKeyBytes;

        private readonly List<string> allVariantsOfNumbersUpTo256Bin;
        
        public AES_SPA(List<List<string>> messages, List<List<int>> hammingWeight)
        {
            this.messages = messages;
            this.hammingWeights = hammingWeight;
            this.allVariantsOfNumbersUpTo256Bin = new List<string>();
            this.possibleKeyBytes = new List<List<string>>();
            this.Key = new string[16];
            GenerateAllVariantsOfNumersUpTo256();
            this.messages = CollectionExtension.ConvertListOfListToBin(messages);
        }

        public int CalculateCountOfKeys()
        {
            var count = 1;
            for (int i = 0; i < messages[0].Count; i++)
            {
                count *= GetCountOfPossibleKeysTo1Byte(i);
            }
            return count;
        }

        public List<List<string>> GenerateKeys()
        {
            // refactoring is required
            var a = from list0 in possibleKeyBytes[0]
                from list1 in possibleKeyBytes[1]
                from list2 in possibleKeyBytes[2]
                from list3 in possibleKeyBytes[3]
                from list4 in possibleKeyBytes[4]
                from list5 in possibleKeyBytes[5]
                from list6 in possibleKeyBytes[6]
                from list7 in possibleKeyBytes[7]
                from list8 in possibleKeyBytes[8]
                from list9 in possibleKeyBytes[9]
                from list10 in possibleKeyBytes[10]
                from list11 in possibleKeyBytes[11]
                from list12 in possibleKeyBytes[12]
                from list13 in possibleKeyBytes[13]
                from list14 in possibleKeyBytes[14]
                from list15 in possibleKeyBytes[15]
                select new List<string>
                {
                    list0,
                    list1,
                    list2,
                    list3,
                    list4,
                    list5,
                    list6,
                    list7,
                    list8,
                    list9,
                    list10,
                    list11,
                    list12,
                    list13,
                    list14,
                    list15
                };
            return a.ToList();
        }

        private int GetCountOfPossibleKeysTo1Byte(int iteration)
        {
            var oldList = new List<string>();
            var newList = new List<string>();
            for (var i = 0; i < messages.Count; i++)
            {
                newList = GeneratePossibleListOfKeys(messages[i][iteration], hammingWeights[i][iteration]);
                if (i == 0)
                {
                    oldList.AddRange(newList);
                }
                else
                {
                    oldList = newList.Intersect(oldList).ToList();
                }

            }
            Key[iteration] = (oldList.Count == 1) ? NumberExtension.ConvertBinToHex(oldList.First()) : string.Empty;

            possibleKeyBytes.Add(CollectionExtension.ConvertListOfBinToHex(oldList));

            return oldList.Count;
        }

        private List<string> GeneratePossibleListOfKeys(string message, int hWeight)
        {
            var list = new List<string>();
            foreach (var item in allVariantsOfNumbersUpTo256Bin)
            {
                if (item.GetCountOfDifferentNumber(message) == hWeight)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        private void GenerateAllVariantsOfNumersUpTo256()
        {
            for (int i = 0; i < 256; i++)
            {
                allVariantsOfNumbersUpTo256Bin.Add(NumberExtension.ConvertDecToBin(i));
            }
        }
    }
}
