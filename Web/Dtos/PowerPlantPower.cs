using System.Text.Json.Serialization;

namespace Web.Dtos;

public class PowerPlantPower
{
    public string Name { get; set; }

    [JsonPropertyName("p")]
    public double Power { get; set; }
}