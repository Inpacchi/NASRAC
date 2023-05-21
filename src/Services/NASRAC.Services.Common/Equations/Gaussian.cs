using MathNet.Numerics.Distributions;
using NASRAC.Services.Common.Services;

namespace NASRAC.Services.Common.Equations;

public class Gaussian
{
    private static readonly Random _rng = new Random();
    
    public static double GeneratePotentialRating(int age)
    {
        var ceilingGaussian = new Normal(80, 20, _rng);
        var ceiling = ceilingGaussian.Sample();

        var ageGaussian = new Normal(42, 5, _rng);
        var ageModifier = ageGaussian.Sample();
        
        var potentialRatingModifierRange = (age - ageModifier) / 10.0;
        var potentialRatingModifier = _rng.NextDouble() * potentialRatingModifierRange;
        var potentialRating = ceiling - potentialRatingModifier;

        return RNG.Clamp(potentialRating, 0, 100, 3);
    }

    public static double GenerateNormal(double mean, double stdDev)
    {
        var gaussian = new Normal(mean, stdDev, _rng);
        
        return gaussian.Sample();
    }
}