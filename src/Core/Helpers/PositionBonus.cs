namespace NASRAC.Core.Helpers;

public class PositionBonus
{
    private static readonly Dictionary<int, double> BONUSES = new()
    {
        { 1, 0.25 },
        { 2, 0.18 },
        { 3, 0.18 },
        { 4, 0.15 },
        { 5, 0.15 },
        { 6, 0.12 },
        { 7, 0.12 },
        { 8, 0.12 },
        { 9, 0.10 },
        { 10, 0.10 },
        { 11, 0.07 },
        { 12, 0.07 },
        { 13, 0.07 },
        { 14, 0.06 },
        { 15, 0.06 },
        { 16, 0.05 },
        { 17, 0.05 },
        { 18, 0.05 },
        { 19, 0.05 },
        { 20, 0.04 },
        { 21, 0.04 },
        { 22, 0.04 },
        { 23, 0.04 },
        { 24, 0.03 },
        { 25, 0.03 },
        { 26, 0.03 },
        { 27, 0.03 },
        { 28, 0.03 },
        { 29, 0.02 },
        { 30, 0.02 },
        { 31, 0.02 },
        { 32, 0.02 },
        { 33, 0.02 },
        { 34, 0.02 },
        { 35, 0.02 },
        { 36, 0.01 },
        { 37, 0.01 },
        { 38, 0.01 },
        { 39, 0.01 },
        { 40, 0.01 },
    };

    public static double Get(int position)
    {
        return BONUSES[position];
    }
}