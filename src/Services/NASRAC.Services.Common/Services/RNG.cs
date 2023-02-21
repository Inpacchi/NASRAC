namespace NASRAC.Services.Common.Services;

public static class RNG
{
    private static readonly Random RandomNumberGenerator;

    static RNG()
    {
        RandomNumberGenerator = new Random();
    }
    
    public static double RollDoubleTenths()
    {
        return RandomNumberGenerator.NextDouble() / 10;
    }

    public static int RollIntRange(int lowerBound, int upperBound)
    {
        return RandomNumberGenerator.Next(lowerBound, upperBound);
    }

    public static double RollDoubleRange(double lowerBound, double upperBound)
    {
        return RandomNumberGenerator.NextDouble() * (upperBound - lowerBound) + lowerBound;
    }

    public static int RollFromList(List<int> list)
    {
        return list[RandomNumberGenerator.Next(list.Count)];
    }
}