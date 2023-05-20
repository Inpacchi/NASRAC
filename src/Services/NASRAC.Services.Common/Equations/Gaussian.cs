using MathNet.Numerics.Distributions;

namespace NASRAC.Services.Common.Equations;

public class Gaussian
{
    private static Random _rng = new Random();
    
    public static double GeneratePotentialRating(int age)
    {
        var ceilingGaussian = new Normal(80, 20, _rng);
        var ceiling = ceilingGaussian.Sample();

        var ageGaussian = new Normal(42, 5, _rng);
        var ageModifier = ageGaussian.Sample();
        
        var potentialRatingModifierRange = (age - ageModifier) / 10.0;
        var potentialRatingModifier = _rng.NextDouble() * potentialRatingModifierRange;
        var potentialRating = ceiling - potentialRatingModifier;

        return potentialRating;
    }

    public static double GenerateNormal(double mean, double stdDev)
    {
        var gaussian = new Normal(mean, stdDev, _rng);
        
        return gaussian.Sample();
    }
}