using System.Net.NetworkInformation;

namespace Overround;

public class Multiplicative : IOverroundMethod
{
    public double[] Apply(double[] fairPrices, double idealOverround)
    {
        double[] odds = new double[fairPrices.Length];
        for (int i = 0; i < fairPrices.Length; i++)
        {
            odds[i] = fairPrices[i] / idealOverround;
        }
        return odds;
    }
}