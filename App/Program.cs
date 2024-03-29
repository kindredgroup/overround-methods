﻿using Overrounds;

double[] fairPrices = [1 / 0.01, 1 / 0.29, 1 / 0.3, 1 / 0.4];
double fairBooksum = Booksum.FromPrices(fairPrices);
Console.WriteLine("fair prices:     [{0}]", string.Join(", ", fairPrices));
Console.WriteLine("fair booksum:    {0}", fairBooksum);

double idealOverround = 1.15;
Console.WriteLine("ideal overround: {0}", idealOverround);
Console.WriteLine("ideal booksum:   {0}", idealOverround * fairBooksum);

IOverroundMethod[] methods = [new Multiplicative(), new Additive(), new Power(), new OddsRatio(), new Shin()];
foreach (var method in methods)
{
    double[] odds = method.Apply(fairPrices, idealOverround);
    Console.WriteLine("");
    Console.WriteLine("method:          {0}", method.GetType().Name);
    Console.WriteLine("odds:            [{0}], booksum: {1}", string.Join(", ", odds), Booksum.FromPrices(odds));
}