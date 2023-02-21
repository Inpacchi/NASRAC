namespace NASRAC.Services.Common.Services;

public static class RNG
{
    private static readonly Random _randomNumberGenerator;

    static RNG()
    {
        _randomNumberGenerator = new Random();
    }
    
    public static double RollDoubleTenths()
    {
        return _randomNumberGenerator.NextDouble() / 10;
    }

    public static int RollIntRange(int lowerBound, int upperBound)
    {
        return _randomNumberGenerator.Next(lowerBound, upperBound);
    }

    public static double RollDoubleRange(double lowerBound, double upperBound)
    {
        var number = _randomNumberGenerator.NextDouble();
        return number * (upperBound - lowerBound) + lowerBound;
    }
}