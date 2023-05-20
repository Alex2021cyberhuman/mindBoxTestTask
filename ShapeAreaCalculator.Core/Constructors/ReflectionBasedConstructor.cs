using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;
using ShapeAreaCalculator.Core.Exceptions;
using ShapeAreaCalculator.Core.Interfaces;

namespace ShapeAreaCalculator.Core.Constructors;

public class ReflectionBasedConstructor : IShapeConstructor
{
    private readonly Assembly[] _scanningAssemblies;

    private readonly ConcurrentDictionary<string, Func<double[], IShapeWithArea>> Constructors = new();

    /// <summary>
    ///     Creates ReflectionBasedConstructor
    /// </summary>
    /// <param name="scanningAssemblies">Array of assemblies that contains shapes. In priority first assemblies. </param>
    public ReflectionBasedConstructor(params Assembly[] scanningAssemblies)
    {
        _scanningAssemblies = scanningAssemblies;
    }

    public static ReflectionBasedConstructor Default => new(Assembly.GetExecutingAssembly());

    public IShapeWithArea Construct(string type, params double[] parameters)
    {
        var constructor = Constructors.GetOrAdd(type,
            typeArgument =>
            {
                var acceptedType = _scanningAssemblies.SelectMany(x => x.GetTypes())
                    .FirstOrDefault(t => t.Name == type);
                if (acceptedType is null)
                    throw new ShapeConstructorException(nameof(type), type);
                var constructors = acceptedType.GetConstructors().ToList();
                var acceptedConstructor = constructors.FirstOrDefault(c =>
                    c.GetParameters().Length <= parameters.Length &&
                    c.GetParameters().All(p => p.ParameterType == typeof(double)));
                if (acceptedConstructor is null)
                    throw new IndexOutOfRangeException();

                var arrayParameterExpression = Expression.Parameter(typeof(double[]));
                var accessParameters = Enumerable.Range(0, parameters.Length).Select(i =>
                    Expression.ArrayIndex(arrayParameterExpression, Expression.Constant(i)));

                var expression = Expression.Lambda(Expression.Convert(
                        Expression.New(acceptedConstructor, accessParameters),
                        typeof(IShapeWithArea)),
                    arrayParameterExpression);

                var result = (Func<double[], IShapeWithArea>)expression.Compile();
                return result;
            });
        var result = constructor(parameters);
        return result;
    }
}
