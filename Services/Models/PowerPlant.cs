namespace Services.Models;

public abstract class PowerPlant
{
    public PowerPlant(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; }

    public string Type { get; }

    public decimal PMin { get; protected set; }

    public decimal PMax { get; protected set; }

    public abstract decimal CostPerMwh { get; }

    public decimal MarginalCost(decimal load) => CostOfOperation(load) / Math.Min(PMax, load);

    public decimal CostOfOperation(decimal load) => PowerProduced(load) * CostPerMwh;

    public decimal PowerProduced(decimal load) => Math.Max(Math.Min(PMax, load), PMin);
}