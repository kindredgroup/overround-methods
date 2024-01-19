namespace Overround.Tests;

[TestClass]
public class SolverTest
{
    private const double Delta = 1e-6;

    [TestMethod]
    public void TestTerminateAfterFirst()
    {
        var solution = Solver.Solve(5, 0.1, Delta, 100, est => Math.Pow(est - 5, 2));
        Assert.AreEqual(5, solution.Value);
        Assert.AreEqual(1, solution.Iterations);
        Assert.AreEqual(0, solution.Error);
    }

    [TestMethod]
    public void TestForwardOnly()
    {
        var solution = Solver.Solve(4, 0.1, Delta, 100, est => Math.Pow(est - 5, 2));
        Assert.AreEqual(5, solution.Value, Delta);
        Assert.AreEqual(11, solution.Iterations);
        Assert.AreEqual(0, solution.Error, Delta);
    }

    [TestMethod]
    public void TestWithBacktrack()
    {
        // the estimation sequence will be 4, 6, 5
        var solution = Solver.Solve(4, 2, Delta, 100, est => Math.Pow(est - 5, 2));
        Assert.AreEqual(5, solution.Value, Delta);
        Assert.AreEqual(3, solution.Iterations);
        Assert.AreEqual(0, solution.Error, Delta);
    }

    [TestMethod]
    public void TestExhaustMaxIterations()
    {
        var solution = Solver.Solve(4, 0.01, Delta, 10, est => Math.Pow(est - 5, 2));
        Assert.AreEqual(4.09, solution.Value, Delta);
        Assert.AreEqual(10, solution.Iterations);
        Assert.AreEqual(0.8281, solution.Error, Delta); // (5-4.09)^2
    }
}