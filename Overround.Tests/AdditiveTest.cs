namespace Overround.Tests;

[TestClass]
public class AdditiveTest
{
    private const double Delta = 1e-3;

    private IOverroundMethod method = new Additive();

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
            ArrayAssert.AreEqual([7.272727272727273, 4.2105263157894735, 2.9629629629629632, 2.2857142857142856], odds, Delta);
        }
        {
            double idealOverround = 1.15;
            double[] fairPrices = [1 / 0.01, 1 / 0.29, 1 / 0.3, 1 / 0.4];
            double[] odds = method.Apply(fairPrices, idealOverround);
            Assert.AreEqual(idealOverround, Booksum.FromPrices(odds), Delta);
            ArrayAssert.AreEqual([21.052631578947377, 3.053435114503817, 2.9629629629629632, 2.2857142857142856], odds, Delta);
        }
    }

    [TestMethod]
    public void TestApplyWithFairBooksumOf2()
    {
        double idealOverround = 1.15;
        double[] fairPrices = [1 / 0.2, 1 / 0.4, 1 / 0.6, 1 / 0.8];
        double[] odds = method.Apply(fairPrices, idealOverround);
        Assert.AreEqual(idealOverround * 2, Booksum.FromPrices(odds), Delta);
        ArrayAssert.AreEqual([3.636, 2.105, 1.481, 1.143], odds, Delta);
    }
}