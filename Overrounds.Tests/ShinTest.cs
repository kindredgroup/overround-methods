namespace Overrounds.Tests;

[TestClass]
public class ShinTest
{
    private const double Delta = 1e-3;

    private readonly IOverroundMethod method = new Shin();

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
            ArrayAssert.AreEqual([7.731, 4.253, 2.940, 2.248], odds, Delta);
        }
        {
            double idealOverround = 1.15;
            double[] fairPrices = [1 / 0.01, 1 / 0.29, 1 / 0.3, 1 / 0.4];
            double[] odds = method.Apply(fairPrices, idealOverround);
            Assert.AreEqual(idealOverround, Booksum.FromPrices(odds), Delta);
            ArrayAssert.AreEqual([36.059, 3.012, 2.92, 2.238], odds, Delta);
        }
    }

    [TestMethod]
    public void TestApplyWithFairBooksumOf2()
    {
        double idealOverround = 1.15;
        double[] fairPrices = [1 / 0.2, 1 / 0.4, 1 / 0.6, 1 / 0.8];
        double[] odds = method.Apply(fairPrices, idealOverround);
        Assert.AreEqual(idealOverround * 2, Booksum.FromPrices(odds), Delta);
        ArrayAssert.AreEqual([3.660, 2.099, 1.479, 1.144], odds, Delta);
    }
}