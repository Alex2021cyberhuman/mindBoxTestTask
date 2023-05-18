using FluentAssertions;
using ShapeAreaCalculator.Core.Exceptions;
using ShapeAreaCalculator.Core.Shapes;

namespace ShapeAreaCalculator.UnitTests;

public class SquareTests
{
    [Theory]
    [InlineData(1d)]
    [InlineData(2d)]
    [InlineData(3d)]
    [InlineData(4d)]
    [InlineData(5d)]
    [InlineData(6d)]
    [InlineData(1000000d)]
    public void SuccessfulCreation_CorrectParameters(
        double side)
    {
        var method = () => new Square(side);
        method.Should().NotThrow();
    }
    
    [Theory]
    [InlineData(-1d)]
    [InlineData(-2d)]
    public void FailCreationWithNegativeParameterException_NegativeSide(
        double side)
    {
        var method = () => new Square(side);
        method.Should().Throw<NegativeParameterException>();
    }  
    
    [Fact]
    public void FailCreationWithZeroParameterException_ZeroSide()
    {
        var method = () => new Square(0);
        method.Should().Throw<ZeroParameterException>();
    }
}