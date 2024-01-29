namespace Overrounds;

public class Power : IOverroundMethod
{
    private const double InitStep = -0.01;
    private const double ErrorThreshold = 1e-6;
    private const int MaxIterations = 100;

    private static double GetInitEstimate(double fairBooksum, double idealBooksum, int numOutcomes)
    {
        return Math.Log(idealBooksum / numOutcomes) / Math.Log(fairBooksum / numOutcomes);
    }

    private static double[] ComputeOdds(double[] fairPrices, double k)
    {
        double[] odds = new double[fairPrices.Length];
        for (int i = 0; i < fairPrices.Length; i++)
        {
            odds[i] = Math.Pow(fairPrices[i], k);
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
            double[] odds = ComputeOdds(fairPrices, estimate);
            double booksum = Booksum.FromPrices(odds);
            return Math.Pow(booksum - idealBooksum, 2);
        });
        return ComputeOdds(fairPrices, solution.Value);
    }
}