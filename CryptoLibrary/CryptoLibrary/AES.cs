using System;
using System.Collections.Generic;

namespace CryptoLibrary
{
    public class AES : IAesMethods
    {
        public List<string> State { get; set; }

        private string lastOperation;

        public AES(List<string> message)
        {
            this.State = message;
            lastOperation = "Message initialization";
        }
        
        public IAesMethods AddRoundKey(List<string> key)
        {
            State = State.XORhexList(key);
            lastOperation = "Add round key";
            return this;
        }

        public IAesMethods SubBytes()
        {
            for (int i = 0; i < State.Count; i++)
            {
                State[i] = Utils.GetByteAfterSubByte(State[i]);
            }
            lastOperation = "Sub bytes";
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
            lastOperation = "Shift rows";
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
            lastOperation = "Mix columns";
            return this;
        }

        public AES PrintResults()
        {
            Console.WriteLine($"Last operation - {lastOperation} \nMessage: {CollectionExtension.ConvertListToString(State)}");
            return this;
        }

        public bool IsMessageEquals(List<string> compareMessage)
        {
            var count = 0;
            for (int i = 0; i < compareMessage.Count; i++)
            {
                if (!compareMessage[i].Equals("*"))
                {
                    if (compareMessage[i] == State[i])
                    {
                        count++;
                    }
                }
            }
            return count == 12;
        }

        public IAesMethods MaskCompensation()
        {
            throw new NotImplementedException();
        }
    }
}
