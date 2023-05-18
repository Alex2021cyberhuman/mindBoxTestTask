using ShapeAreaCalculator.Core;
using ShapeAreaCalculator.Core.Interfaces;

namespace ShapeAreaCalculator.UnitTests;

public class InterfaceBasedCalculatorTests : AbstractCalculatorTests
{
    protected override double Call(
        object shapeWithArea)
    {
        var calculator = new InterfaceBasedCalculator();
        return calculator.Calculate((IShapeWithArea)shapeWithArea);
    }
}
