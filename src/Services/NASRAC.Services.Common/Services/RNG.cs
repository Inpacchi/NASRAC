namespace NASRAC.Services.Common.Services;

public static class RNG
{
    private static readonly Random RandomNumberGenerator;

    static RNG()
    {
        RandomNumberGenerator = new Random();
    }
    
    /// <summary>
    /// Rolls a random double divided by 10 (range: 0.0 - 0.1)
    /// </summary>
    /// <returns></returns>
    public static double RollDoubleTenths()
    {
        var randomNumber = RandomNumberGenerator.NextDouble();
        if (randomNumber != 0) return randomNumber / 10;
        return randomNumber;
    }

    /// <summary>
    /// Rolls a random integer in the given range (range: lowerBound - upperBound, e.g 0 - 10)
    /// </summary>
    /// <param name="lowerBound">Inclusive lowest number to return</param>
    /// <param name="upperBound">Exclusive highest number to return</param>
    /// <returns></returns>
    public static int RollIntRange(int lowerBound, int upperBound)
    {
        return RandomNumberGenerator.Next(lowerBound, upperBound);
    }

    /// <summary>
    /// Rolls a random double in the given range (range: lowerBound - upperBound; e.g 0.0 - 10.0)
    /// </summary>
    /// <param name="lowerBound">Inclusive lowest number to return</param>
    /// <param name="upperBound">Exclusive highest number to return</param>
    /// <returns></returns>
    public static double RollDoubleRange(double lowerBound, double upperBound)
    {
        return RandomNumberGenerator.NextDouble() * (upperBound - lowerBound) + lowerBound;
    }

    /// <summary>
    /// Rolls a random integer from the given list
    /// </summary>
    /// <param name="list">List of integers to return a random integer from</param>
    /// <returns></returns>
    public static int RollFromList(List<int> list)
    {
        return list[RandomNumberGenerator.Next(list.Count)];
    }

    /// <summary>
    /// Rolls a random enum from the given enum
    /// </summary>
    /// <returns></returns>
    public static T RollEnum<T>() where T : Enum
    {
        var length = Enum.GetValues(typeof(T)).Length;
        var index = RandomNumberGenerator.Next(0, length);
        
        return (T)Enum.GetValues(typeof(T)).GetValue(index);
    }
}