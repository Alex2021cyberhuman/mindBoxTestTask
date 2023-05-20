namespace ShapeAreaCalculator.Core.Exceptions;

public class ShapeConstructorException : ArgumentException
{
    public ShapeConstructorException(string paramName, string type) : base($"Cannot create Shape of specified type '{type}'", paramName)
    {
    }
}
