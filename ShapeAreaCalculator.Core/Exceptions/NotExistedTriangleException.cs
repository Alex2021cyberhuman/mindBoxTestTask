namespace ShapeAreaCalculator.Core.Exceptions;

public class NotExistedTriangleException : ArgumentException
{
    public NotExistedTriangleException() : base("Cannot create triangle with this sides")
    {
    }
}