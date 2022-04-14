using System.Linq;

namespace PackIT.Domain.ValueObjects
{
    public record Localization(string City, string Country)
    {
        public static Localization Create(string value)
        {
            var splitLocation = value.Split(',');
            return new Localization(splitLocation.First(), splitLocation.Last());
        }

        public override string ToString() => $"{City}, {Country}";
    }
}