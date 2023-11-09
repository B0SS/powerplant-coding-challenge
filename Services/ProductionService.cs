using Domain.Models;
using Web.Dtos;

namespace Services;

public class ProductionService
{
    public IEnumerable<PowerPlantProduction> ComputeProductionPlan(int load, IReadOnlyCollection<PowerPlant> powerPlants)
    {
        decimal totalPowerProduced = 0;
        var powerPlantsByCost = powerPlants.OrderBy(powerPlant => powerPlant.CostPerMwh).ToList();

        foreach(var powerPlant in powerPlantsByCost)
        {
            var powerLeftToProduce = load - totalPowerProduced;

            if (powerLeftToProduce + powerPlant.PMin <= load)
            {
                 var production = new PowerPlantProduction
                 {
                     Name = powerPlant.Name,
                     Power = powerPlant.PMax * Math.Min(powerLeftToProduce / powerPlant.PMax, 1)
                 };

                totalPowerProduced += production.Power;

                yield return production;
            }
        }
    }
}
