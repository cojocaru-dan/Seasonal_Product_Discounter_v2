public static class RandomExtensions
{
    public static double NextDouble(this Random Random, double minimum, double maximum)
    {
        double doubleNumber = Random.NextDouble() * (maximum - minimum);
        return minimum + doubleNumber;
    }
}