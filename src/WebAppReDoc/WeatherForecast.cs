using Swashbuckle.AspNetCore.Annotations;
using System;

namespace WebAppReDoc
{
    [SwaggerSchema(Required = new[] { "Id", "OrderId", "CustomerName", "Address", "OrderValue" })]
    public class WeatherForecast
    {
        [SwaggerSchema(
            Title = "Unique ID",
            Description = "This is the database ID and will be unique.",
            Format = "DateTime")]
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        public string MeuCampo { get; set; }
    }
}
