using System.Net.NetworkInformation;

namespace Overround;

public class Additive : IOverroundMethod
{
    public double[] Apply(double[] fairPrices, double idealOverround)
    {
        double fairBooksum = Booksum.FromPrices(fairPrices);
        double increment = (idealOverround - 1) * fairBooksum / fairPrices.Length;
        double[] odds = new double[fairPrices.Length];
        for (int i = 0; i < fairPrices.Length; i++)
        {
            odds[i] = 1 / (1 / fairPrices[i] + increment);
        }
        return odds;
    }
}