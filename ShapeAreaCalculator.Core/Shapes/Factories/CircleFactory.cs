using ShapeAreaCalculator.Core.Interfaces;

namespace ShapeAreaCalculator.Core.Shapes.Factories;

public class CircleFactory: IShapeFactory
{
    public string Type => nameof(Circle);

    public IShapeWithArea Parse(params double[] parameters) => new Circle(parameters[0]);
}
