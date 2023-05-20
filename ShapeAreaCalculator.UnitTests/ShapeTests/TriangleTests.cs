using FluentAssertions;
using ShapeAreaCalculator.Core.Exceptions;
using ShapeAreaCalculator.Core.Shapes;

namespace ShapeAreaCalculator.UnitTests.ShapeTests;

public class TriangleTests
{
    [Theory]
    [InlineData(1d, 1d, 1d)]
    [InlineData(2d, 2d, 2d)]
    [InlineData(3d, 3d, 3d)]
    [InlineData(4d, 4d, 4d)]
    [InlineData(5d, 5d, 5d)]
    [InlineData(6d, 6d, 6d)]
    [InlineData(1000000d, 1000000d, 1000000d)]
    public void SuccessfulCreation_CorrectParameters(double sideA, double sideB, double sideC)
    {
        var method = () => new Triangle(sideA, sideB, sideC);
        method.Should().NotThrow();
    }

    [Theory]
    [InlineData(3d, 4d, 5d, true)]
    [InlineData(15d, 20d, 25d, true)]
    [InlineData(4d, 3d, 5d, true)]
    [InlineData(20d, 15d, 25d, true)]
    [InlineData(1d, 1d, 1d, false)]
    [InlineData(5d, 5d, 5d, false)]
    [InlineData(6d, 6d, 6d, false)]
    [InlineData(1000000d, 1000000d, 1000000d, false)]
    public void CheckIsRight_ExpectedResult(double sideA, double sideB, double sideC, bool expected)
    {
        var obj = new Triangle(sideA, sideB, sideC);
        var actual = obj.CheckIsRight();

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(-1d, -1d, -1d)]
    [InlineData(-1d, 1d, 1d)]
    [InlineData(1d, -1d, 1d)]
    [InlineData(1d, 1d, -1d)]
    public void FailCreationWithNegativeParameterException_NegativeSide(double sideA, double sideB, double sideC)
    {
        var method = () => new Triangle(sideA, sideB, sideC);
        method.Should().Throw<NegativeParameterException>();
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 1d, 1d)]
    [InlineData(1d, 0, 1d)]
    [InlineData(1d, 1d, 0)]
    public void FailCreationWithZeroParameterException_ZeroSide(double sideA, double sideB, double sideC)
    {
        var method = () => new Triangle(sideA, sideB, sideC);
        method.Should().Throw<ZeroParameterException>();
    }
    
    [Theory]
    [InlineData(3, 1, 1)]
    [InlineData(2, 1, 1)]
    [InlineData(5, 1, 1)]
    [InlineData(100000d, 1d, 1)]
    [InlineData(3, 1123, 1)]
    [InlineData(2, 1, 1213123)]
    [InlineData(5, 11231233, 1)]
    [InlineData(100000d, 1123123123, 1)]
    public void FailCreationWithNotExistedTriangleException_WrongSides(double sideA, double sideB, double sideC)
    {
        var method = () => new Triangle(sideA, sideB, sideC);
        method.Should().Throw<NotExistedTriangleException>();
    }
}
