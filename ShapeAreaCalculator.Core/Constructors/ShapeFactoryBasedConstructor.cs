using ShapeAreaCalculator.Core.Exceptions;
using ShapeAreaCalculator.Core.Interfaces;
using ShapeAreaCalculator.Core.Shapes.Factories;

namespace ShapeAreaCalculator.Core.Constructors;

public class ShapeFactoryBasedConstructor : IShapeConstructor
{
    private readonly IReadOnlyDictionary<string, IShapeFactory> _shapeFactories;

    public ShapeFactoryBasedConstructor(IEnumerable<IShapeFactory> shapeFactories)
    {
        _shapeFactories = shapeFactories.ToDictionary(factory => factory.Type);
    }

    public IShapeWithArea Construct(string type, params double[] parameters)
    {
        if (_shapeFactories.TryGetValue(type, out var factory))
        {
            return factory.Parse(parameters);
        }

        throw new ShapeConstructorException(nameof(type), type);
    }

    public static ShapeFactoryBasedConstructor Default=>
        new(new IShapeFactory[] { new CircleFactory(), new SquareFactory(), new TriangleFactory() });
}
