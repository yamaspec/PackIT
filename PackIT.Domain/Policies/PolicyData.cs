using PackIT.Domain.Consts;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies
{
    public record PolicyData(TravelDays Days, Gender Gender, Temperature Temperature, Localization Localization);
}