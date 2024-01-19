namespace Overround;

public class OddsRatio : IOverroundMethod
{
    private const double InitStep = 0.1;
    private const double ErrorThreshold = 1e-6;
    private const int MaxIterations = 100;

    private static double[] ComputeOdds(double[] fairPrices, double g)
    {
        double[] odds = new double[fairPrices.Length];
        for (int i = 0; i < fairPrices.Length; i++)
        {
            odds[i] = (fairPrices[i] - 1) / g + 1;
        }
        return odds;
    }

    public double[] Apply(double[] fairPrices, double idealOverround)
    {
        double fairBooksum = Booksum.FromPrices(fairPrices);
        double targetBooksum = idealOverround * fairBooksum;
        double initEstimate = idealOverround;
        Solution solution = Solver.Solve(initEstimate, InitStep, ErrorThreshold, MaxIterations, estimate =>
        {
            double[] odds = ComputeOdds(fairPrices, estimate);
            double booksum = Booksum.FromPrices(odds);
            return Math.Pow(booksum - targetBooksum, 2);
        });
        return ComputeOdds(fairPrices, solution.Value);
    }
}