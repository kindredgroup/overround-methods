namespace Overrounds.Tests;

[TestClass]
public class BooksumTest
{
    [TestMethod]
    public void TestFromPrices()
    {
        {
            double booksum = Booksum.FromPrices([1 / 0.1, 1 / 0.2, 1 / 0.3, 1 / 0.4]);
            Assert.AreEqual(1, booksum);
        }
        {
            double booksum = Booksum.FromPrices([1 / 0.2, 1 / 0.4, 1 / 0.6, 1 / 0.8]);
            Assert.AreEqual(2, booksum);
        }
    }
}