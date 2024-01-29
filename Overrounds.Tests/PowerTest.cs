namespace Overrounds.Tests;

[TestClass]
public class PowerTest
{
    private const double Delta = 1e-3;

    private readonly IOverroundMethod method = new Power();

    [TestMethod]
    public void TestApplyNoOverround()
    {
        double idealOverround = 1.0;
        double[] fairPrices = [1 / 0.1, 1 / 0.2, 1 / 0.3, 1 / 0.4];
        double[] odds = method.Apply(fairPrices, idealOverround);
        Assert.AreEqual(idealOverround, Booksum.FromPrices(odds), Delta);
        ArrayAssert.AreEqual([1 / 0.1, 1 / 0.2, 1 / 0.3, 1 / 0.4], odds, Delta);
    }

    [TestMethod]
    public void TestApplyWithFairBooksumOf1()
    {
        {
            double idealOverround = 1.15;
            double[] fairPrices = [1 / 0.1, 1 / 0.2, 1 / 0.3, 1 / 0.4];
            double[] odds = method.Apply(fairPrices, idealOverround);
            Assert.AreEqual(idealOverround, Booksum.FromPrices(odds), Delta);
            ArrayAssert.AreEqual([7.793, 4.2, 2.926, 2.264], odds, Delta);
        }
        {
            double idealOverround = 1.15;
            double[] fairPrices = [1 / 0.01, 1 / 0.29, 1 / 0.3, 1 / 0.4];
            double[] odds = method.Apply(fairPrices, idealOverround);
            Assert.AreEqual(idealOverround, Booksum.FromPrices(odds), Delta);
            ArrayAssert.AreEqual([56.999, 2.965, 2.878, 2.235], odds, Delta);
        }
    }

    [TestMethod]
    public void TestApplyWithFairBooksumOf2()
    {
        double idealOverround = 1.15;
        double[] fairPrices = [1 / 0.2, 1 / 0.4, 1 / 0.6, 1 / 0.8];
        double[] odds = method.Apply(fairPrices, idealOverround);
        Assert.AreEqual(idealOverround * 2, Booksum.FromPrices(odds), Delta);
        ArrayAssert.AreEqual([3.458, 2.027, 1.483, 1.188], odds, Delta);
    }
}