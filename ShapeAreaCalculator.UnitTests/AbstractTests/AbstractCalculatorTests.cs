using FluentAssertions;
using ShapeAreaCalculator.Core.Calculators;
using ShapeAreaCalculator.Core.Interfaces;
using ShapeAreaCalculator.Core.Shapes;

namespace ShapeAreaCalculator.UnitTests.AbstractTests;

public abstract class AbstractCalculatorTests
{
    protected abstract double Call(object shapeWithArea);

    [Theory]
    [MemberData(nameof(GetCorrectTestData))]
    public void ShouldReturnCorrectArea_CorrectShape(IShapeWithArea shapeWithArea, double expected)
    {
        var actual = Call(shapeWithArea);

        actual.Should().BeApproximately(expected, CalculationConstants.Precision);
    }

    public static IEnumerable<object[]> GetCorrectTestData()
    {
        yield return new object[] { new Circle(1), Math.PI };
        yield return new object[] { new Circle(10), 100 * Math.PI };
        yield return new object[] { new Circle(999), 999 * 999 * Math.PI };
        yield return new object[] { new Square(1), 1 };
        yield return new object[] { new Square(10), 100 };
        yield return new object[] { new Square(999), 999 * 999 };
        yield return new object[] { new Square(1.0), 1.0 };
        yield return new object[] { new Square(10.0005), 10.0005 * 10.0005 };
        yield return new object[] { new Square(9999.123456789), 9999.123456789 * 9999.123456789 };
        yield return new object[] { new Triangle(5, 4, 3), 6 };
        yield return new object[] { new Triangle(10, 8, 6), 24 };
        yield return new object[] { new Triangle(101, 81, 61), 2470.4170068027 };
    }
}
