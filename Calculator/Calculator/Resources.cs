using System;
using System.Collections.Generic;
using Calculator.Operations;

namespace Calculator
{
    public class Resources
    {
        public readonly static Dictionary<string, IOperation> operations = new Dictionary<string, AllOperations>()
        {
            { "+", AllOperations.Sum},
            { "-", AllOperations.Sub},
            { "*", AllOperations.Mult},
            { "/", AllOperations.Div}
        };
    }
}
