namespace ShapeAreaCalculator.Core.Exceptions;

public class NegativeParameterException : ArgumentException
{
    public NegativeParameterException(string? paramName) : base("This parameter cannot be negative", paramName)
    {
    }
}
