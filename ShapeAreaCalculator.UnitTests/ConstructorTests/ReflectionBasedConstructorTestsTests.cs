using System.Reflection;
using FluentAssertions;
using ShapeAreaCalculator.Core.Constructors;
using ShapeAreaCalculator.Core.Exceptions;
using ShapeAreaCalculator.Core.Interfaces;
using ShapeAreaCalculator.UnitTests.AbstractTests;

namespace ShapeAreaCalculator.UnitTests.ConstructorTests;

public class ReflectionBasedConstructorTestsTests : AbstractShapeConstructorTests
{
    protected override IShapeConstructor ShapeConstructor => ReflectionBasedConstructor.Default;

    [Fact]
    public void Construct_ShouldThrowShapeConstructorException_TypeWithoutInterface()
    {
        var constructor = new ReflectionBasedConstructor(Assembly.GetExecutingAssembly());
        const string type = "TypeWithoutInterface";
        var parameters = Array.Empty<double>();

        var method = () => constructor.Construct(type, parameters);

        method.Should().Throw<ShapeConstructorException>();
    }

    [Fact]
    public void Construct_ShouldNotThrow_TypeWithInterface()
    {
        var constructor = new ReflectionBasedConstructor(Assembly.GetExecutingAssembly());
        const string type = "TypeWithInterface";
        var parameters = Array.Empty<double>();

        var method = () => constructor.Construct(type, parameters);

        method.Should().NotThrow();
    }

    public class TypeWithoutInterface
    {
    }

    public class TypeWithInterface : IShapeWithArea
    {
        public double CalculateArea() => 0;
    }
}
