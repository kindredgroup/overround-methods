using Overround;


double[] fairPrices = [1 / 0.01, 1 / 0.29, 1 / 0.3, 1 / 0.4];
double booksum = Booksum.FromPrices(fairPrices);
Console.WriteLine($"booksum is {booksum}");
double idealOverround = 1.15;

// power method
IOverroundMethod method = new Power();
double[] odds = method.Apply(fairPrices, idealOverround);
// double initEstimate = Power.GetInitEstimate(idealOverround, fairPrices.Length);
// double initStep = -0.01;
// double errorThreshold = 1e-6;
// int maxIterations = 100;
// Solution k = Solver.Solve(initEstimate, initStep, errorThreshold, maxIterations, estimate =>
// {
//     double[] odds = Power.Apply(fairPrices, estimate);
//     double overround = Booksum.FromPrices(odds);
//     return Math.Pow(overround - idealOverround, 2);
// });
// double[] odds = Power.Apply(fairPrices, k.Value);
Console.WriteLine("fair prices: {0}, overround: {1}, odds: {2}", ArrayToString(fairPrices), idealOverround, ArrayToString(odds));

static string ArrayToString(double[] array)
{
    return String.Format("[{0}]", string.Join(", ", array));
}