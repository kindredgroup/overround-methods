namespace Overround;

public class Power
{
    public static double GetInitEstimate(double overround, int numOutcomes)
    {
        return 1 + Math.Log(1/overround)/Math.Log(numOutcomes);
    }

    public static double[] Apply(double[] fairPrices, double k)
    {
        double[] odds = new double[fairPrices.Length];
        for (int i = 0; i < fairPrices.Length; i++)
        {
            odds[i] = Math.Pow(fairPrices[i], k);
        }

        return odds;
    }
}