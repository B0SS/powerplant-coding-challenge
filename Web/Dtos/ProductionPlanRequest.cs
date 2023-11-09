using System.Text.Json.Serialization;

namespace Web.Dtos;

public class ProductionPlanRequest
{
    public int Load { get; set; }

    public Fuels Fuels { get; set; }

    public List<Powerplant> Powerplants { get; set; }
}

public class Fuels
{
    [JsonPropertyName("gas(euro/MWh)")]
    public double GasPricePerMWh { get; set; }

    [JsonPropertyName("kerosine(euro/MWh)")]
    public double KerosinePricePerMwh { get; set; }

    [JsonPropertyName("co2(euro/ton)")]
    public int Co2PricePerTon { get; set; }

    [JsonPropertyName("wind(%)")]
    public int WindPercentage { get; set; }
}

public class Powerplant
{
    public string Name { get; set; }

    public string Type { get; set; }

    public double Efficiency { get; set; }

    public int PMin { get; set; }

    public int PMax { get; set; }
}