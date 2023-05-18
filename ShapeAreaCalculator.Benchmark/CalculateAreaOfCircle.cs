using BenchmarkDotNet.Attributes;
using ShapeAreaCalculator.Core;
using ShapeAreaCalculator.Core.Interfaces;
using ShapeAreaCalculator.Core.Shapes;

namespace ShapeAreaCalculator.Benchmark;

[SimpleJob]
[MemoryDiagnoser]
public class CalculateAreaOfCircle
{
    private List<Circle>? _list;
    private InterfaceBasedCalculator? _interfaceBased;
    private ReflectionBasedCalculator? _reflectionBased;

    public const int N = 1_000_000;

    [IterationSetup]
    public void Setup()
    {
        _list = Enumerable.Range(0, N).Select(_ => Random.Shared.NextDouble() * 100d + CalculationConstants.Precision)
            .Select(radius => new Circle(radius)).ToList();
        _interfaceBased = new();
        _reflectionBased = new();
    }

    [Benchmark]
    public void InterfaceBasedRealization()
    {
        for (var index = 0; index < N; index++)
        {
            var circle = _list![index];
            var x = _interfaceBased!.Calculate(circle);
        }
    }

    [Benchmark]
    public void ReflectionBasedCalculator()
    {
        for (var index = 0; index < N; index++)
        {
            var circle = _list![index];
            var x = _reflectionBased!.Calculate(circle);
        }
    }
}
