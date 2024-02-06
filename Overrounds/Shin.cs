namespace Overrounds;

public class Shin : IOverroundMethod
{
    private const double InitStep = 0.01;
    private const double ErrorThreshold = 1e-6;
    private const int MaxIterations = 100;

    private static double GetInitEstimate(double fairBooksum, double idealBooksum, int numOutcomes)
    {
        return (idealBooksum - fairBooksum) / (numOutcomes - fairBooksum);
    }

    private static double ComputeAdjustment(double z, double prob)
    {
        return Math.Sqrt(z *prob + (1 - z) * prob * prob);
    }

    private static double[] ComputeOdds(double[] fairPrices, double fairBooksum, double z)
    {
        double[] odds = new double[fairPrices.Length];
        double sigmaAdjustments = 0;
        for (int i = 0; i < fairPrices.Length; i++)
        {
            sigmaAdjustments += ComputeAdjustment(z, 1 / fairPrices[i]);
        }
        for (int i = 0; i < fairPrices.Length; i++)
        {
            odds[i] = 1 / (ComputeAdjustment(z, 1 / fairPrices[i]) * sigmaAdjustments / fairBooksum);
        }
        return odds;
    }

    public double[] Apply(double[] fairPrices, double idealOverround)
    {
        double fairBooksum = Booksum.FromPrices(fairPrices);
        double idealBooksum = idealOverround * fairBooksum;
        double initEstimate = GetInitEstimate(fairBooksum, idealBooksum, fairPrices.Length);
        Solution solution = Solver.Solve(initEstimate, InitStep, ErrorThreshold, MaxIterations, estimate =>
        {
            double[] odds = ComputeOdds(fairPrices, fairBooksum, estimate);
            double booksum = Booksum.FromPrices(odds);
            return Math.Pow(booksum - idealBooksum, 2);
        });
        return ComputeOdds(fairPrices, fairBooksum, solution.Value);
    }
}