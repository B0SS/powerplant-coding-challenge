using Services.Models;
using System.Text.Json.Serialization;

namespace Web.Dtos;

public class PowerPlantProductionDto
{
    public string Name { get; set; }

    [JsonPropertyName("p")]
    public decimal Power { get; set; }

    public static PowerPlantProductionDto MapFrom(PowerPlantProduction powerPlantProd)
        => new() { Name = powerPlantProd.Name, Power = powerPlantProd.Power };
}