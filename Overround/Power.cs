namespace Overround;

public class Power : IOverroundMethod
{
    private const double InitStep = -0.01;
    private const double ErrorThreshold = 1e-6;
    private const int MaxIterations = 100;

    static double GetInitEstimate(double overround, int numOutcomes)
    {
        return 1 + Math.Log(1 / overround) / Math.Log(numOutcomes);
    }

    static double[] ComputeOdds(double[] fairPrices, double k)
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
        double targetBooksum = idealOverround * fairBooksum;
        double initEstimate = GetInitEstimate(idealOverround, fairPrices.Length);
        Solution solution = Solver.Solve(initEstimate, InitStep, ErrorThreshold, MaxIterations, estimate =>
        {
            double[] odds = ComputeOdds(fairPrices, estimate);
            double booksum = Booksum.FromPrices(odds);
            return Math.Pow(booksum - targetBooksum, 2);
        });
        return ComputeOdds(fairPrices, solution.Value);
    }
}