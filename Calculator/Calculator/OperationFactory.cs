using System;
using Calculator.Operations;
using System.Linq;

namespace Calculator
{
    public class OperationFactory
    {
        private static IOperation operation = null;

        public static IOperation GetOperation(string operatorString)
        {
            switch (Resources.operations.First(o => o.Key == operatorString).Value)
            {
                case AllOperations.Sum
            }
        }
    }
}
