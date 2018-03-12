using System;

namespace CryptoLibrary
{
    public class NumberExtension
    {
        private const int BinToBase = 2;

        private const int HexToBase = 16;

        private const int DefaulNumberOfDigittHex = 2;

        private const int DefaultNumberOfDigitBin = 8;

        // Convert Bin
        public static string ConvertBinToDec(string bin) => Convert.ToInt32(bin, BinToBase).ToString();

        public static string ConvertBinToHex(string bin, int numberOfDigit = DefaulNumberOfDigittHex) =>
            ConvertDecToHex(ConvertBinToDec(bin), numberOfDigit);

        // Convert Dec
        public static string ConvertDecToBin(string dec, int numberOfDigit = DefaultNumberOfDigitBin)
        {
            var intDec = Int32.Parse(dec);
            return ConvertDecToBin(intDec, numberOfDigit);
        }

        public static string ConvertDecToBin(int dec, int numberOfDigit = DefaultNumberOfDigitBin) =>
            Utils.AddZerosAtBegin(Convert.ToString(dec, BinToBase), numberOfDigit);

        public static string ConvertDecToHex(string dec, int numberOfDigit = DefaulNumberOfDigittHex)
        {
            var intDec = Int32.Parse(dec);
            return ConvertDecToHex(intDec, numberOfDigit);
        }

        public static string ConvertDecToHex(int dec, int numberOfDigit = DefaulNumberOfDigittHex) =>
            Utils.AddZerosAtBegin(Convert.ToString(dec, HexToBase), numberOfDigit);

        // Convert Hex
        public static string ConvertHexToBin(string hex, int numberOfDigit = DefaultNumberOfDigitBin) =>
            ConvertDecToBin(ConvertHexToDec(hex), numberOfDigit);

        public static string ConvertHexToDec(string hex) => Convert.ToInt32(hex, HexToBase).ToString();
    }
}