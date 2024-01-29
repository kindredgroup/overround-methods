namespace Overrounds.Tests;

static class ArrayAssert
{
    internal static void AreEqual(double[] expected, double[] actual, double delta)
    {
        Assert.AreEqual(expected.Length, actual.Length, "Array length mismatch.");
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], actual[i], delta, "Mismatch in element {0}.", i);
        }
    }
}