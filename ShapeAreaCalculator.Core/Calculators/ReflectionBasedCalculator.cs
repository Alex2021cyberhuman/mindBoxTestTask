using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace ShapeAreaCalculator.Core.Calculators;

/// <summary>
///     Reflection based realization
/// </summary>
/// <remarks>
///     Prefer <see cref="InterfaceBasedCalculator" /> instead this realization.
///     It causes boxing on value types.
/// </remarks>
/// <example>
///     1) Create type that contains public instance 'CalculateArea' method that returns <see cref="double" /> and hasn't
///     any parameter
///     <code>
/// public class MyShape
/// { 
///   public double CalculateArea() => ...;
/// }
/// </code>
///     2) Create instance <see cref="ReflectionBasedCalculator" /> and keep it one per application
///     <code>
/// var reflectionBasedCalculator = new ReflectionBasedCalculator();
/// </code>
///     3) Call calculate and pass object that have CalculateArea method
///     <code>
/// var shape = new MyShape();
/// var result = reflectionBasedCalculator.Calculate(shape);
/// </code>
/// </example>
public class ReflectionBasedCalculator
{
    private readonly ConcurrentDictionary<Type, Func<object, double>> AreaGetters = new();

    public double Calculate(object shape)
    {
        var shapeType = shape.GetType();
        var calculateArea = AreaGetters.GetOrAdd(shapeType,
            type =>
            {
                var calculateAreaMethod = type.GetMethod("CalculateArea",
                    BindingFlags.Public | BindingFlags.Instance,
                    Type.EmptyTypes);
                if (calculateAreaMethod is null || calculateAreaMethod.ReturnType != typeof(double))
                    throw new InvalidOperationException(
                        $"Object of type ${type} should has method 'CalculateArea' without arguments and return type 'double'");

                var instanceParameter = Expression.Parameter(typeof(object), "obj");

                var expression = Expression.Lambda(
                    Expression.Call(Expression.Convert(instanceParameter, type), calculateAreaMethod),
                    instanceParameter);
                var result = (Func<object, double>)expression.Compile();

                return result;
            });
        var result = calculateArea(shape);
        return result;
    }
}
