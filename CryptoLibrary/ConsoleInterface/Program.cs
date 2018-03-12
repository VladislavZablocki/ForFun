using System;
using System.Collections.Generic;
using CryptoLibrary;
using System.Text.RegularExpressions;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            // --------------- AES -----------------
            /*
            var f1 = "12 52 a0 * b3 8c * 71 8f * 67 8b * 74 02 f8";
            var messages = new List<List<string>>
            {
                CollectionExtension.SplitStringToListOfStringThroughSeparators("48 83 5c a5 fa 5c 44 d4 fc e5 39 82 87 c5 57 2e"),
                CollectionExtension.SplitStringToListOfStringThroughSeparators("ae 14 66 52 90 bf ad e9 d2 2d 06 2d 4d 22 38 a5"),
                CollectionExtension.SplitStringToListOfStringThroughSeparators("03 e4 80 5f 58 9d 71 7b 7f 01 ff e9 32 30 d6 72"),
                CollectionExtension.SplitStringToListOfStringThroughSeparators("a6 de f0 fd be b1 66 0b 7f ea 86 85 c4 48 27 b7"),
                CollectionExtension.SplitStringToListOfStringThroughSeparators("32 29 39 9c 6f f3 a0 5c 8f b2 43 13 cf 03 5f d4")
            };

            var weights = new List<List<int>>
            {
                CollectionExtension.SplitStringToListOfIntThroughSeparators("7 2 1 4 3 3 5 3 4 1 2 5 2 4 6 2"),
                CollectionExtension.SplitStringToListOfIntThroughSeparators("2 5 5 3 5 2 2 2 2 4 6 5 4 6 4 2"),
                CollectionExtension.SplitStringToListOfIntThroughSeparators("5 5 6 4 2 2 3 3 7 3 4 6 5 6 4 6"),
                CollectionExtension.SplitStringToListOfIntThroughSeparators("1 5 5 5 5 3 5 6 7 3 7 4 3 6 5 4"),
                CollectionExtension.SplitStringToListOfIntThroughSeparators("2 2 3 6 3 3 1 3 5 4 3 2 4 6 7 6")
            };

            AES_SPA aes_spa = new AES_SPA(messages, weights);

            Console.WriteLine($"Possible count of keys : {aes_spa.CalculateCountOfKeys()}");

            var keys = aes_spa.GenerateKeys();
            var messagesAfteMixColumns = new List<List<string>>();

            foreach (var key in keys)
            {
                AES aes = new AES(
                    CollectionExtension.SplitStringToListOfStringThroughSeparators(
                        "48 83 5c a5 fa 5c 44 d4 fc e5 39 82 87 c5 57 2e"));
                aes.AddRoundKey(key)
                    .SubBytes()
                    .ShiftRows()
                    .MixColumns();
                messagesAfteMixColumns.Add(aes.State);

                if (aes.IsMessageEquals(
                    CollectionExtension.SplitStringToListOfStringThroughSeparators(f1)))
                {
                    aes.PrintResults();
                    Console.WriteLine($"COmpare with {f1}");
                    Console.WriteLine($"KEY :  {key.ConvertListToString()}");
                }
            }
            messagesAfteMixColumns.WriteToFile();
            */

            // -------------------- AES256 Bad generator --------------------
            var input = "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
            var mask = "00 0f 36 39 53 5c 65 6a 95 9a a3 ac c6 c9 f0 ff";
            var s0 = "71 ad 8d 60 d5 5a 5f ab 32 6c 53 82 2e f6 12 6b";
            var s1 = "e8 12 4b 62 3c 51 e9 3b ec c9 74 7a e6 f4 61 30";
            
            var maskList = CollectionExtension.SplitStringToListOfStringThroughSeparators(mask);
            for (int offset = 0; offset < 16; offset++)
            {
                var aes = new AES_Mask();
                aes.Mask = maskList.Offset(offset);
                aes.State = CollectionExtension.SplitStringToListOfStringThroughSeparators(s0);
                var key = CollectionExtension.SplitStringToListOfStringThroughSeparators(s0).XORhexList(CollectionExtension.SplitStringToListOfStringThroughSeparators(input).XORhexList(aes.Mask));

                aes.SubBytes()
                    .ShiftRows()
                    .MixColumns()
                    .MaskCompensation();

                key.AddRange(aes.GetSecondPartOfKey(CollectionExtension.SplitStringToListOfStringThroughSeparators(s1)));

                Console.WriteLine($"Offset : {offset}");
                key.ConvertListToString().PrintStatistic();
                Console.WriteLine("-----------------------------------------");
            }
            
            
            Console.ReadLine();
        }
    }
}
