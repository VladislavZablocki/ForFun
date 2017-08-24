namespace Calculator
{
    public class MultiplicationOperation : IOperation
    {
        public double Execute(double first, double second)
        {
            return first * second;
        }
    }
}
