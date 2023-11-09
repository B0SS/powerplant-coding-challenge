namespace Services.Models;

public class GreenPowerPlant : PowerPlant
{
    public GreenPowerPlant(string name, string type, int pMin, int pMax, int elementPowerPercentage) : base(name, type)
    {
        decimal elementPowerFraction = elementPowerPercentage / 100M;
        PMin = pMin * elementPowerFraction;
        PMax = pMax * elementPowerFraction;
    }

    public override decimal CostPerMwh => 0;
}