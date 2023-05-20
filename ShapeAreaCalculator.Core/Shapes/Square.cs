using ShapeAreaCalculator.Core.Exceptions;
using ShapeAreaCalculator.Core.Interfaces;

namespace ShapeAreaCalculator.Core.Shapes;

/// <summary>
///     Represents model of a square with specified side length.
///     Serves for the area calculation.
/// </summary>
public readonly struct Square : IShapeWithArea
{
    /// <summary>
    ///     Create square with specified side length
    /// </summary>
    /// <param name="side">Length of single side of the square in conventional units</param>
    /// <exception cref="NegativeParameterException">If side is less than zero</exception>
    /// <exception cref="ZeroParameterException">If side is equals zero</exception>
    public Square(double side)
    {
        GuardHelpers.ThrowIfNegativeOrEqualsZero(side, nameof(side));

        Side = side;
    }

    /// <summary>Length of single side of the square in conventional units</summary>
    public double Side { get; }

    /// <inheritdoc />
    public double CalculateArea()
    {
        return Side * Side;
    }
}
