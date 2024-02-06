`overround-methods`
===
[![Build Status](https://img.shields.io/github/actions/workflow/status/kindredgroup/overround-methods/dotnet.yml?branch=master&style=flat-square&logo=github)](https://github.com/kindredgroup/overround-methods/actions/workflows/dotnet.yml)

A collection of overround application methods: _Multiplicative_, _Additive_, _Power_, _Odds-Ratio_ and _Shin_.

# Examples
```csharp
using Overrounds;

double[] fairPrices = [1 / 0.1, 1 / 0.2, 1 / 0.3, 1 / 0.4];
double fairBooksum = Booksum.FromPrices(fairPrices);
Console.WriteLine("fair prices:     [{0}]", string.Join(", ", fairPrices));
Console.WriteLine("fair booksum:    {0}", fairBooksum);

double idealOverround = 1.15;
Console.WriteLine("ideal overround: {0}", idealOverround);

IOverroundMethod[] methods = [new Multiplicative(), new Additive(), new Power(), new OddsRatio(), new Shin()];
foreach (var method in methods)
{
    double[] odds = method.Apply(fairPrices, idealOverround);
    Console.WriteLine("");
    Console.WriteLine("method:          {0}", method.GetType().Name);
    Console.WriteLine("odds:            [{0}]", string.Join(", ", odds));
}
```