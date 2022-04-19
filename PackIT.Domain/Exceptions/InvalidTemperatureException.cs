using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    internal class InvalidTemperatureException : PackITException
    {
        public double Value { get; }

        public InvalidTemperatureException(double value) : base($"Value '{value}' is an invalid temperature")
            => Value = value;
    }
}