using System.Collections.Generic;

namespace CryptoLibrary
{
    public interface IAesMethods
    {
        List<string> State { get; set; }

        IAesMethods AddRoundKey(List<string> key);

        IAesMethods SubBytes();

        IAesMethods ShiftRows();

        IAesMethods MixColumns();

        IAesMethods MaskCompensation();
    }
}
