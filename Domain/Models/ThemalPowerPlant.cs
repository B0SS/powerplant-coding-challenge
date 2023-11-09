namespace Domain.Models;

public class ThermalPowerPlant : PowerPlant
{
    public ThermalPowerPlant(string name, string type, int pMin, int pMax, decimal efficiency, decimal fuelCost) : base(name, type)
    {
        PMin = pMin;
        PMax = pMax;
        Efficiency = efficiency;
        FuelCost = fuelCost;
    }

    public decimal Efficiency { get; }

    public decimal FuelCost { get; }

    public override decimal CostPerMwh => FuelCost / Efficiency;
}