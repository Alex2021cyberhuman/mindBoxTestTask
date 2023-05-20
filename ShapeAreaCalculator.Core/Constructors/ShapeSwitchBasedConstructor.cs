using ShapeAreaCalculator.Core.Exceptions;
using ShapeAreaCalculator.Core.Interfaces;
using ShapeAreaCalculator.Core.Shapes;

namespace ShapeAreaCalculator.Core.Constructors;

public class ShapeSwitchBasedConstructor : IShapeConstructor
{
    public IShapeWithArea Construct(string type, params double[] parameters)
    {
        return type switch
        {
            nameof(Circle) => new Circle(parameters[0]),
            nameof(Triangle) => new Triangle(parameters[0], parameters[1], parameters[2]),
            nameof(Square) => new Square(parameters[0]),
            _ => throw new ShapeConstructorException(nameof(type), type)
        };
    }
}
