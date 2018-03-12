using System.Collections.Generic;

namespace CryptoLibrary
{
    public class AES_Mask : IAesMethods
    {
        public List<string> State { get; set; }

        public List<string> Mask { get; set; }

        public IAesMethods AddRoundKey(List<string> key)
        {
            State = State.XORhexList(key);
            return this;
        }

        public IAesMethods SubBytes()
        {
            // TODO offset+r-1
            State = State.XORhexList(Mask);
            for (int i = 0; i < State.Count; i++)
            {
                State[i] = Utils.GetByteAfterSubByte(State[i]);
            }
            // TODO offset+r
            State = State.XORhexList(Mask.Offset(1));
            return this;
        }

        public IAesMethods ShiftRows()
        {
            var result = new List<string>();
            for (int i = 0; i < State.Count; i++)
            {
                result.Add(State[Resources.ShiftRows[i]]);
            }
            State = result;
            return this;
        }

        public IAesMethods MixColumns()
        {
            var temp = new List<string>();
            for (int i = 0; i < State.Count; i++)
            {
                temp.Add(State.Calculate1ByteMixColumt(i));
            }
            State = temp;
            return this;
        }

        public IAesMethods MaskCompensation()
        {
            // TODO offset+r
            AES aes = new AES(Mask.Offset(1));
            State = State.XORhexList(aes.ShiftRows()
                                        .MixColumns()
                                        .State.XORhexList(Mask.Offset(1)));
            return this;
        }

        public List<string> GetSecondPartOfKey(List<string> s1)
        {
            return State.XORhexList(s1);
        }
    }
}
