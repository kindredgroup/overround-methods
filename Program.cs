using Overround;

double booksum = Booksum.Compute([1 / 0.1, 1 / 0.2, 1 / 0.3, 1 / 0.4]);
Console.WriteLine($"booksum is {booksum}");

double[] fairPrices = [1 / 0.1, 1 / 0.2, 1 / 0.3, 1 / 0.4];
double idealOverround = 1.15;

// power method
double initEstimate = Power.GetInitEstimate(idealOverround, fairPrices.Length);
double initStep = -0.01;
double errorThreshold = 1e-6;
int maxIterations = 100;
double k = Solver.Solve(initEstimate, initStep, errorThreshold, maxIterations, estimate =>
{
    double[] odds = Power.Apply(fairPrices, estimate);
    double overround = Booksum.Compute(odds);
    return Math.Pow(overround - idealOverround, 2);
});
double[] odds = Power.Apply(fairPrices, k);
Console.WriteLine("k estimate for fair prices [{0}], overround {1} is {2}", string.Join(", ", fairPrices), idealOverround, k);
Console.WriteLine("odds are: {0}", ArrayToString(odds));

static string ArrayToString(double[] array)
{
    return String.Format("[{0}]", string.Join(", ", array));
}