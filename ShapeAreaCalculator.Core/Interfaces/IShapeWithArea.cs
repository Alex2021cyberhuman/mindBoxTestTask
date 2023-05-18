namespace ShapeAreaCalculator.Core.Interfaces;

public interface IShapeWithArea
{
    /// <summary>
    ///     Returns area of the shape that have calculable area 
    /// </summary>
    /// <returns>Area in conventional units</returns>
    double CalculateArea();
}