using System.Threading.Tasks;
using FluentValidation;

namespace Application.WeatherForecasts.Queries.GetAirportWeatherForecast
{
    public class GetAirportWeatherForecastQueryValidator : AbstractValidator<GetAirportWeatherForecastQuery>
    {
        public GetAirportWeatherForecastQueryValidator()
        {
            RuleFor(x => x.ICAOCode)
                .Length(4).WithMessage("ICAO Code should only be 4 characters long");

            RuleFor(x => x.ICAOCode)
                .MustAsync(async (icaoCode, cancellation) =>
                {
                    // TODO: Check if ICAO code is valid
                    await Task.Delay(50); // mocking the check
                    return true;
                }).WithMessage("The ICAO code was invalid");
        }
    }
}