using ShapeAreaCalculator.Core.Interfaces;

namespace ShapeAreaCalculator.Core.Shapes.Factories;

public class TriangleFactory : IShapeFactory
{
    public string Type => nameof(Triangle);

    public IShapeWithArea Parse(params double[] parameters)
    {
        return new Triangle(parameters[0], parameters[1], parameters[2]);
    }
}
