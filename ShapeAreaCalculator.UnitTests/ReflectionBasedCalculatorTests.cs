using FluentAssertions;
using ShapeAreaCalculator.Core;

namespace ShapeAreaCalculator.UnitTests;

public class ReflectionBasedCalculatorTests : AbstractCalculatorTests
{
    public const double ExpectedArea = 777d;

    protected override double Call(object shapeWithArea)
    {
        var calculator = new ReflectionBasedCalculator();
        return calculator.Calculate(shapeWithArea);
    }

    [Fact]
    public void SuccessfulReturnsCorrectResult_RandomTypeWithRequiredMethod()
    {
        var obj = new RandomTypeWithRequiredMethod();
        var actual = Call(obj);

        actual.Should().BeApproximately(ExpectedArea, CalculationConstants.Precision);
    }

    [Fact]
    public void Throw_RandomTypeWithoutRequiredMethod()
    {
        var obj = new RandomTypeWithoutRequiredMethod();
        var method = () => Call(obj);

        method.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Throw_RandomTypeWithRequiredMethodWithIncorrectReturnType()
    {
        var obj = new RandomTypeWithRequiredMethodWithIncorrectReturnType();
        var method = () => Call(obj);

        method.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Throw_RandomTypeWithRequiredMethodWithParameter()
    {
        var obj = new RandomTypeWithRequiredMethodWithParameter();
        var method = () => Call(obj);

        method.Should().Throw<InvalidOperationException>();
    }

    public class RandomTypeWithRequiredMethod
    {
        public double CalculateArea() => ExpectedArea;
    }

    public class RandomTypeWithoutRequiredMethod
    {
    }

    public class RandomTypeWithRequiredMethodWithIncorrectReturnType
    {
        public float CalculateArea() => default;
    }

    public class RandomTypeWithRequiredMethodWithParameter
    {
        public double CalculateArea(object obj) => default;
    }
}
