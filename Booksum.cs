namespace Overround;

public class Booksum
{
    public static double Compute(double[] prices)
    {
        double sum = 0;
        foreach (double price in prices)
        {
            sum += 1 / price;
        }

        return sum;
    }
}