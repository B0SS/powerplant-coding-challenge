namespace Domain.Models;

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
}