using Domain.Models;

namespace Web.Dtos;

public class PowerplantDto
{
    public string Name { get; set; }

    public string Type { get; set; }

    public decimal Efficiency { get; set; }

    public int PMin { get; set; }

    public int PMax { get; set; }

    public PowerPlant MapTo(FuelsDto fuels)
        => Type switch
        {
            "turbojet" => new ThermalPowerPlant(Name, Type, PMin, PMax, Efficiency, fuels.KerosinePricePerMwh),
            "gasfired" => new ThermalPowerPlant(Name, Type, PMin, PMax, Efficiency, fuels.GasPricePerMWh),
            "windturbine" => new GreenPowerPlant(Name, Type, PMin, PMax, fuels.WindPercentage),
            _ => throw new NotImplementedException($"The type of power plant {Type} is not supported")
        };
}