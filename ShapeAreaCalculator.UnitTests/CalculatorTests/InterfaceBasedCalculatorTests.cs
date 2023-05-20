using ShapeAreaCalculator.Core.Calculators;
using ShapeAreaCalculator.Core.Interfaces;
using ShapeAreaCalculator.UnitTests.AbstractTests;

namespace ShapeAreaCalculator.UnitTests.CalculatorTests;

public class InterfaceBasedCalculatorTests : AbstractCalculatorTests
{
    protected override double Call(object shapeWithArea)
    {
        var calculator = new InterfaceBasedCalculator();
        return calculator.Calculate((IShapeWithArea)shapeWithArea);
    }
}
