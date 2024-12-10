namespace NASRAC.Core.Services;

public static class RandomService
{
    private static readonly Random RNG;
    private static readonly Dictionary<string, int> COLOR_WEIGHTS = new();
    private static readonly int TOTAL_COLOR_WEIGHT;
    
    private static readonly List<string> COLORS = new()
    {
        "Black",
        "Blue",
        "Green",
        "Orange",
        "Purple",
        "Red",
        "White",
        "Yellow",
        ""
    };

    static RandomService()
    {
        RNG = new Random();

        foreach (var color in COLORS)
        {
            var weight = color switch
            {
                "" => 10,
                "Black" => 5,
                "White" => 3,
                "Red" => 2,
                "Blue" => 2,
                _ => 1
            };

            TOTAL_COLOR_WEIGHT += weight;
            COLOR_WEIGHTS[color] = TOTAL_COLOR_WEIGHT;
        }
    }

    /// <summary>
    /// Roll a random integer up to the given max value (range: 0 - maxValue)
    /// </summary>
    /// <param name="maxValue">Exclusive highest number to return</param>
    /// <returns></returns>
    public static int RollInt(int maxValue)
    {
        return RNG.Next(maxValue);
    }
    
    /// <summary>
    /// Roll a random double divided by 10 (range: 0.0 - 0.1)
    /// </summary>
    /// <returns></returns>
    public static double RollDoubleTenths()
    {
        var randomNumber = RNG.NextDouble();
        if (randomNumber != 0) return randomNumber / 10;
        return randomNumber;
    }

    /// <summary>
    /// Roll a random integer in the given range (range: lowerBound - upperBound, e.g 0 - 10)
    /// </summary>
    /// <param name="lowerBound">Inclusive lowest number to return</param>
    /// <param name="upperBound">Exclusive highest number to return</param>
    /// <returns></returns>
    public static int RollIntRange(int lowerBound, int upperBound)
    {
        return RNG.Next(lowerBound, upperBound);
    }

    /// <summary>
    /// Roll a random double in the given range (range: lowerBound - upperBound; e.g 0.0 - 10.0)
    /// </summary>
    /// <param name="lowerBound">Inclusive lowest number to return</param>
    /// <param name="upperBound">Exclusive highest number to return</param>
    /// <returns></returns>
    public static double RollDoubleRange(double lowerBound, double upperBound)
    {
        return RNG.NextDouble() * (upperBound - lowerBound) + lowerBound;
    }

    /// <summary>
    /// Roll a random double in the given range (range: lowerBound - upperBound; e.g 0.0 - 10.0), then round it to the given precision
    /// </summary>
    /// <param name="lowerBound">Inclusive lowest number to return</param>
    /// <param name="upperBound">Exclusive highest number to return</param>
    /// <param name="precision">Number of decimal places to round to</param>
    /// <returns></returns>
    public static double RollDoubleRange(double lowerBound, double upperBound, int precision)
    {
        return Math.Round(RNG.NextDouble() * (upperBound - lowerBound) + lowerBound, precision);
    }

    /// <summary>
    /// Rolls a random integer from the given list
    /// </summary>
    /// <param name="list">List of integers to return a random integer from</param>
    /// <returns></returns>
    public static int RollFromList(List<int> list)
    {
        return list[RNG.Next(list.Count)];
    }

    /// <summary>
    /// Rolls a random enum from the given enum
    /// </summary>
    /// <returns></returns>
    public static T RollEnum<T>() where T : Enum
    {
        var length = Enum.GetValues(typeof(T)).Length;
        var index = RNG.Next(0, length);
        
        return (T)Enum.GetValues(typeof(T)).GetValue(index);
    }
    
    /// <summary>
    /// Clamp the value between min and max
    /// </summary>
    /// <param name="value">Value to clamp</param>
    /// <param name="min">Minimum number the value should be</param>
    /// <param name="max">Maximum number the value should be</param>
    /// <returns></returns>
    public static double Clamp(double value, double min, double max)
    {
        return Math.Min(Math.Max(value, min), max);
    }

    /// <summary>
    /// Clamp the value between min and max, then round to the given precision
    /// </summary>
    /// <param name="value">Value to clamp</param>
    /// <param name="min">Minimum number the value should be</param>
    /// <param name="max">Maximum number the value should be</param>
    /// <param name="precision">Number of decimal places to round to</param>
    /// <returns></returns>
    public static double Clamp(double value, double min, double max, int precision)
    {
        return Math.Min(Math.Max(Math.Round(value, precision), min), max);
    }
    
    /// <summary>
    /// Pick a random primary or secondary color, or no color
    /// </summary>
    /// <returns></returns>
    public static string GetRandomColor()
    {
        var randomNumber = RandomService.RollIntRange(0, TOTAL_COLOR_WEIGHT);

        foreach (var color in COLORS.Where(color => randomNumber < COLOR_WEIGHTS[color]))
            return color;

        return "";
    }
}