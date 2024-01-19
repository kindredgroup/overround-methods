namespace Overround;

public class Solution(double value, double error, int iterations)
{
    public double Value { get; } = value;

    public double Error { get; } = error;

    public int Iterations { get; } = iterations;

    public override string ToString()
    {
        return String.Format("{{value: {0}, error: {1}, iterations: {2}}}", Value, Error, Iterations);
    }
}

public class Solver
{
    public static Solution Solve(double initEstimate, double initStep, double errorThreshold, int maxIterations, Func<double, double> lossFunc)
    {
        double lastError = lossFunc(initEstimate);
        if (lastError < errorThreshold)
        {
            return new Solution(initEstimate, lastError, 1);
        }

        double lastEstimate = initEstimate;
        double step = initStep;
        int iteration = 2;
        while (true)
        {
            double estimate = lastEstimate + step;
            double error = lossFunc(estimate);
            if (error < errorThreshold)
            {
                return new Solution(estimate, error, iteration);
            }
            else if (error >= lastError)
            {
                step = -step / 2;
            }

            if (iteration >= maxIterations)
            {
                return new Solution(estimate, error, iteration);
            }
            iteration++;
            lastEstimate = estimate;
            lastError = error;
        }
    }
}