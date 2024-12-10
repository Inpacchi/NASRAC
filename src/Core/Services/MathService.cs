using MathNet.Numerics.Distributions;

namespace NASRAC.Core.Services;

public static class MathService
{
    private static readonly Random RNG = new Random();
    
    #region Gaussian Equation Functions
    public static double GeneratePotentialRating(int age)
    {
        var ceilingGaussian = new Normal(80, 20, RNG);
        var ceiling = ceilingGaussian.Sample();

        var ageGaussian = new Normal(42, 5, RNG);
        var ageModifier = ageGaussian.Sample();
        
        var potentialRatingModifierRange = (age - ageModifier) / 10.0;
        var potentialRatingModifier = RNG.NextDouble() * potentialRatingModifierRange;
        var potentialRating = ceiling - potentialRatingModifier;

        return RandomService.Clamp(potentialRating, 0, 100, 3);
    }

    public static double GenerateNormal(double mean, double stdDev)
    {
        var gaussian = new Normal(mean, stdDev, RNG);
        
        return gaussian.Sample();
    }
    #endregion
}