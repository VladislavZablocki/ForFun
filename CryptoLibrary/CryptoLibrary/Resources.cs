using System.Collections.Generic;

namespace CryptoLibrary
{
    public sealed class Resources
    {
        public static List<List<string>> SBox = new List<List<string>>
        {
            new List<string>{"63", "7c", "77", "7b", "f2", "6b", "6f", "c5", "30", "01", "67", "2b", "fe", "d7", "ab", "76"},
            new List<string>{"ca", "82", "c9", "7d", "fa", "59", "47", "f0", "ad", "d4", "a2", "af", "9c", "a4", "72", "c0"},
            new List<string>{"b7", "fd", "93", "26", "36", "3f", "f7", "cc", "34", "a5", "e5", "f1", "71", "d8", "31", "15"},
            new List<string>{"04", "c7", "23", "c3", "18", "96", "05", "9a", "07", "12", "80", "e2", "eb", "27", "b2", "75"},
            new List<string>{"09", "83", "2c", "1a", "1b", "6e", "5a", "a0", "52", "3b", "d6", "b3", "29", "e3", "2f", "84"},
            new List<string>{"53", "d1", "00", "ed", "20", "fc", "b1", "5b", "6a", "cb", "be", "39", "4a", "4c", "58", "cf"},
            new List<string>{"d0", "ef", "aa", "fb", "43", "4d", "33", "85", "45", "f9", "02", "7f", "50", "3c", "9f", "a8"},
            new List<string>{"51", "a3", "40", "8f", "92", "9d", "38", "f5", "bc", "b6", "da", "21", "10", "ff", "f3", "d2"},
            new List<string>{"cd", "0c", "13", "ec", "5f", "97", "44", "17", "c4", "a7", "7e", "3d", "64", "5d", "19", "73"},
            new List<string>{"60", "81", "4f", "dc", "22", "2a", "90", "88", "46", "ee", "b8", "14", "de", "5e", "0b", "db"},
            new List<string>{"e0", "32", "3a", "0a", "49", "06", "24", "5c", "c2", "d3", "ac", "62", "91", "95", "e4", "79"},
            new List<string>{"e7", "c8", "37", "6d", "8d", "d5", "4e", "a9", "6c", "56", "f4", "ea", "65", "7a", "ae", "08"},
            new List<string>{"ba", "78", "25", "2e", "1c", "a6", "b4", "c6", "e8", "dd", "74", "1f", "4b", "bd", "8b", "8a"},
            new List<string>{"70", "3e", "b5", "66", "48", "03", "f6", "0e", "61", "35", "57", "b9", "86", "c1", "1d", "9e"},
            new List<string>{"e1", "f8", "98", "11", "69", "d9", "8e", "94", "9b", "1e", "87", "e9", "ce", "55", "28", "df"},
            new List<string>{"8c", "a1", "89", "0d", "bf", "e6", "42", "68", "41", "99", "2d", "0f", "b0", "54", "bb", "16"}
        };

        public static string Module = "11B";

        public static Dictionary<int, int> ShiftRows = new Dictionary<int, int>
        {
            { 0, 0 }, { 1, 5 }, { 2, 10 }, { 3, 15 },
            { 4, 4 }, { 5, 9 }, { 6, 14 }, { 7, 3 },
            { 8, 8 }, { 9, 13 }, { 10, 2 }, { 11, 7 },
            { 12, 12}, { 13, 1 }, {14, 6 }, { 15, 11 }
        };

        public static List<List<int>> MixColumnsMatrix = new List<List<int>>
        {
            new List<int>{ 2, 3, 1, 1},
            new List<int>{ 1, 2, 3, 1},
            new List<int>{ 1, 1, 2, 3},
            new List<int>{ 3, 1, 1, 2}
        };
    }
}
