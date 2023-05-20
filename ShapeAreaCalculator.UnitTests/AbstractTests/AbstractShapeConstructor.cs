using FluentAssertions;
using ShapeAreaCalculator.Core.Exceptions;
using ShapeAreaCalculator.Core.Interfaces;
using ShapeAreaCalculator.Core.Shapes;

namespace ShapeAreaCalculator.UnitTests.AbstractTests;

public abstract class AbstractShapeConstructor
{
    protected abstract IShapeConstructor ShapeConstructor { get; }

    [Theory]
    [MemberData(nameof(CorrectParametersForCreation))]
    public void Construct_ShouldCreateCorrectShapes_CorrectParametersForCreation(
        object expected,
        string type,
        double[] parameters)
    {
        var actual = ShapeConstructor.Construct(type, parameters);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Construct_ShouldThrowShapeConstructorException_UnknownType()
    {
        const string type = "Unknown";
        var parameters = new double[10];

        var method = () => ShapeConstructor.Construct(type, parameters);

        method.Should().Throw<ShapeConstructorException>();
    }

    [Fact]
    public void Construct_ShouldThrowArgumentOutOfRangeException_WrongCountOfArguments()
    {
        const string type = nameof(Triangle);
        var parameters = new double[2];

        var method = () => ShapeConstructor.Construct(type, parameters);

        method.Should().Throw<IndexOutOfRangeException>();
    }

    public static IEnumerable<object[]> CorrectParametersForCreation()
    {
        yield return new object[] { new Circle(1), nameof(Circle), new double[] { 1 } };
        yield return new object[] { new Circle(2.5), nameof(Circle), new double[] { 2.5 } };
        yield return new object[] { new Circle(10000), nameof(Circle), new double[] { 10000 } };
        yield return new object[] { new Square(123), nameof(Square), new double[] { 123 } };
        yield return new object[] { new Square(99999), nameof(Square), new double[] { 99999 } };
        yield return new object[] { new Square(0.000001), nameof(Square), new double[] { 0.000001 } };
        yield return new object[] { new Triangle(2, 2, 3), nameof(Triangle), new double[] { 2, 2, 3 } };
        yield return new object[] { new Triangle(100, 100, 199), nameof(Triangle), new double[] { 100, 100, 199 } };
        yield return new object[] { new Triangle(24, 48, 64), nameof(Triangle), new double[] { 24, 48, 64 } };
    }
}
