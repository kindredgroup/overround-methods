namespace Overround.Tests;

[TestClass]
public class PowerTest
{
    [TestMethod]
    public void TestCompute()
    {
        //TODO
        double booksum = Booksum.Compute([1 / 0.1, 1 / 0.2, 1 / 0.3, 1 / 0.4]);
        Assert.AreEqual(1, booksum);
    }
}