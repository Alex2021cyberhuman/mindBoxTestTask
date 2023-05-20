namespace ShapeAreaCalculator.Core.Interfaces;

public interface IShapeConstructor
{
    IShapeWithArea Construct(string type, params double[] parameters);
}
