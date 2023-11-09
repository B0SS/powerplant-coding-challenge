using System.Text.Json.Serialization;

namespace Web.Dtos;

public class PowerPlantProduction
{
    public string Name { get; set; }

    public decimal Power { get; set; }
}