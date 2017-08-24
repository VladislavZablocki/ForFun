namespace Calculator
{
    public class SubtractionOperation : IOperation
    {
        public double Execute(double first, double second)
        {
            return first - second;
        }
    }
}
