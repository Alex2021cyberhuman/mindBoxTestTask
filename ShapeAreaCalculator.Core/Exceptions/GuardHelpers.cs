namespace ShapeAreaCalculator.Core.Exceptions;

public static class GuardHelpers
{
    public static void ThrowIfNegativeOrEqualsZero(
        double value,
        string parameter)
    {
        if (value < 0d)
            throw new NegativeParameterException(parameter);
        if (value == 0d)
            throw new ZeroParameterException(parameter);
    }
}
