using ShapeAreaCalculator.Core.Exceptions;
using ShapeAreaCalculator.Core.Interfaces;

namespace ShapeAreaCalculator.Core.Shapes;

/// <summary>
///     Represents model of a circle with specified radius.
///     Serves for the area calculation.
/// </summary>
public readonly struct Circle : IShapeWithArea
{
    /// <summary>
    ///     Create circle with specified radius
    /// </summary>
    /// <param name="radius">Radius of the circle in conventional units</param>
    /// <exception cref="NegativeParameterException">If radius is less than zero</exception>
    /// <exception cref="ZeroParameterException">If radius is equals zero</exception>
    public Circle(double radius)
    {
        GuardHelpers.ThrowIfNegativeOrEqualsZero(radius, nameof(radius));

        Radius = radius;
    }

    /// <summary>
    ///     Radius of the circle in conventional units
    /// </summary>
    public double Radius { get; }

    /// <inheritdoc />
    public double CalculateArea()
    {
        var result = Radius * Radius * Math.PI;
        return result;
    }
}
