using ShapeAreaCalculator.Core.Interfaces;

namespace ShapeAreaCalculator.Core.Shapes.Factories;

public class SquareFactory : IShapeFactory
{
    public string Type => nameof(Square);

    public IShapeWithArea Parse(params double[] parameters) => new Square(parameters[0]);
}
