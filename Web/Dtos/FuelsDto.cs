using System.Text.Json.Serialization;

namespace Web.Dtos;

public class FuelsDto
{
    [JsonPropertyName("gas(euro/MWh)")]
    public decimal GasPricePerMWh { get; set; }

    [JsonPropertyName("kerosine(euro/MWh)")]
    public decimal KerosinePricePerMwh { get; set; }

    [JsonPropertyName("co2(euro/ton)")]
    public int Co2PricePerTon { get; set; }

    [JsonPropertyName("wind(%)")]
    public int WindPercentage { get; set; }
}
