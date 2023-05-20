namespace ShapeAreaCalculator.Core.Interfaces;

public interface IShapeFactory
{
    string Type { get; }
    IShapeWithArea Parse(params double[] parameters);
}
