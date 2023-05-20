using ShapeAreaCalculator.Core.Calculators;
using ShapeAreaCalculator.Core.Exceptions;
using ShapeAreaCalculator.Core.Interfaces;

namespace ShapeAreaCalculator.Core.Shapes;

/// <summary>
///     Represents model of a triangle with specified side lengths.
///     Serves for the area calculation.
/// </summary>
public readonly struct Triangle : IShapeWithArea, IRightTriangleCheck
{
    /// <summary>
    ///     Create triangle with specified side lengths
    /// </summary>
    /// <param name="sideA">Length of first side in conventional units</param>
    /// <param name="sideB">Length of second side in conventional units</param>
    /// <param name="sideC">Length of third side in conventional units</param>
    /// <exception cref="NegativeParameterException">If any side is less than zero</exception>
    /// <exception cref="ZeroParameterException">If any side is equals zero</exception>
    public Triangle(double sideA, double sideB, double sideC)
    {
        GuardHelpers.ThrowIfNegativeOrEqualsZero(sideA, nameof(sideA));
        GuardHelpers.ThrowIfNegativeOrEqualsZero(sideB, nameof(sideB));
        GuardHelpers.ThrowIfNegativeOrEqualsZero(sideC, nameof(sideC));
        var biggerSide = Math.Max(sideA, Math.Max(sideB, sideC));
        var otherTwoSides = sideA + sideB + sideC - biggerSide;
        if (biggerSide >= otherTwoSides)
            throw new NotExistedTriangleException();
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double SideA { get; }

    public double SideB { get; }

    public double SideC { get; }


    /// <inheritdoc />
    /// <returns>
    ///     Function is based on the Pythagorean Theorem
    /// </returns>
    public bool CheckIsRight()
    {
        var hypotenuseSquare = Math.Max(SideA, Math.Max(SideB, SideC));
        hypotenuseSquare *= hypotenuseSquare;
        var sideSquaresSum = SideA * SideA + SideB * SideB + SideC * SideC;
        var result = Math.Abs(sideSquaresSum - hypotenuseSquare * 2) < CalculationConstants.Precision;
        return result;
    }

    /// <inheritdoc />
    /// <remarks>
    ///     Calculates triangle area only by 3 sides.
    ///     Function is based on the Heron`s formula.
    /// </remarks>
    public double CalculateArea()
    {
        var halfOfPerimeter = (SideA + SideB + SideC) / 2d;
        var result = Math.Sqrt(halfOfPerimeter *
                               (halfOfPerimeter - SideA) *
                               (halfOfPerimeter - SideB) *
                               (halfOfPerimeter - SideC));
        return result;
    }
}
