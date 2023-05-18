namespace ShapeAreaCalculator.Core.Exceptions;

public class ZeroParameterException : ArgumentException
{
    public ZeroParameterException(
        string? paramName) : base("This parameter cannot be equal zero",
        paramName)
    {
    }
}
