using ShapeAreaCalculator.Core.Constructors;
using ShapeAreaCalculator.Core.Interfaces;
using ShapeAreaCalculator.UnitTests.AbstractTests;

namespace ShapeAreaCalculator.UnitTests.ConstructorTests;

public class ReflectionBasedConstructorTestsTests : AbstractShapeConstructorTests
{
    protected override IShapeConstructor ShapeConstructor => ReflectionBasedConstructor.Default;
}