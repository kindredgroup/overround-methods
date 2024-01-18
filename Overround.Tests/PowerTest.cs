namespace Overround.Tests;

[TestClass]
public class PowerTest
{
    private const double Delta = 1e-3;

    private IOverroundMethod method = new Power();

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
            ArrayAssert.AreEqual([7.792612295808612, 4.200100853723753, 2.9257830833421794, 2.2637912052854765], odds, Delta);
        }
        {
            double idealOverround = 1.15;
            double[] fairPrices = [1 / 0.01, 1 / 0.29, 1 / 0.3, 1 / 0.4];
            double[] odds = method.Apply(fairPrices, idealOverround);
            Assert.AreEqual(idealOverround, Booksum.FromPrices(odds), Delta);
            ArrayAssert.AreEqual([56.99885594904725, 2.9646851350987014, 2.877746548950255, 2.235448624371958], odds, Delta);
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