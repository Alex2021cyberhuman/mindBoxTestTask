using ShapeAreaCalculator.Core.Interfaces;

namespace ShapeAreaCalculator.Core;

/// <summary>
///     Simple realization that working with object of <see cref="IShapeWithArea"/>
/// </summary>
public class InterfaceBasedCalculator
{
    /// <summary>
    ///     Returns area of shape
    /// </summary>
    /// <param name="shape"><see cref="IShapeWithArea"/> object</param>
    /// <returns>Area in conventional units</returns>
    public double Calculate(
        IShapeWithArea shape)
    {
        return shape.CalculateArea();
    }
}