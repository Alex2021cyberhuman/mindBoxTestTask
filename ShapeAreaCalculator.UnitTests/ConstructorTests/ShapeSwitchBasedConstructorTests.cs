using ShapeAreaCalculator.Core.Constructors;
using ShapeAreaCalculator.Core.Interfaces;
using ShapeAreaCalculator.UnitTests.AbstractTests;

namespace ShapeAreaCalculator.UnitTests.ConstructorTests;

public class ShapeSwitchBasedConstructorTests : AbstractShapeConstructor
{
    protected override IShapeConstructor ShapeConstructor => new ShapeSwitchBasedConstructor();
}