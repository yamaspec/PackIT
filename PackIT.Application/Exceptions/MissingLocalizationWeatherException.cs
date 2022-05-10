using PackIT.Domain.ValueObjects;
using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Application.Exceptions
{
    public class MissingLocalizationWeatherException : PackITException
    {
        public Localization Localization { get; }

        public MissingLocalizationWeatherException(Localization localization)
            : base($"Weather for destination '{localization.City}/{localization.Country}' could not be found")
        {
            Localization = localization;
        }
    }
}