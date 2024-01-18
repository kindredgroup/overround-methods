namespace Overround.Tests;

[TestClass]
public class OddsRatioTest
{
    private const double Delta = 1e-3;

    private IOverroundMethod method = new OddsRatio();

    [TestMethod]
    public void TestApplyNoOverround()
    {
        double idealOverround = 1.0;
        double[] fairPrices = [1 / 0.1, 1 / 0.2, 1 / 0.3, 1 / 0.4];
        double[] odds = method.Apply(fairPrices, idealOverround);
        Assert.AreEqual(idealOverround, Booksum.FromPrices(odds), Delta);
    }

    [TestMethod]
    public void TestApplyWithFairBooksumOf1()
    {
        {
            double idealOverround = 1.15;
            double[] fairPrices = [1 / 0.1, 1 / 0.2, 1 / 0.3, 1 / 0.4];
            double[] odds = method.Apply(fairPrices, idealOverround);
            Assert.AreEqual(idealOverround, Booksum.FromPrices(odds), Delta);
            ArrayAssert.AreEqual([8.328244274809158, 4.256997455470738, 2.8999151823579306, 2.2213740458015265], odds, Delta);
        }
        {
            double idealOverround = 1.15;
            double[] fairPrices = [1 / 0.01, 1 / 0.29, 1 / 0.3, 1 / 0.4];
            double[] odds = method.Apply(fairPrices, idealOverround);
            Assert.AreEqual(idealOverround, Booksum.FromPrices(odds), Delta);
            ArrayAssert.AreEqual([80.59798994974874, 2.968463004678565, 2.876046901172529, 2.2060301507537687], odds, Delta);
        }
    }

    [TestMethod]
    public void TestApplyWithFairBooksumOf2()
    {
        double idealOverround = 1.15;
        double[] fairPrices = [1 / 0.2, 1 / 0.4, 1 / 0.6, 1 / 0.8];
        double[] odds = method.Apply(fairPrices, idealOverround);
        Assert.AreEqual(idealOverround * 2, Booksum.FromPrices(odds), Delta);
    }
}