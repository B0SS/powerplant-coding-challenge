using Services.Models;
using System.Linq;
using Web.Dtos;

namespace Services;

public class ProductionService
{
    public IEnumerable<PowerPlantProduction> ComputeProductionPlan(int load, IReadOnlyCollection<PowerPlant> powerPlants)
    {
        decimal totalPowerProduced = 0;
        var orderOfMerit = powerPlants
            .Where(plant => plant.PMax > 0)
            .ToList();
        decimal totalCost = 0;
        
        while (totalPowerProduced < load)
        {
            var powerLeftToProduce = load - totalPowerProduced;

            var powerPlant = orderOfMerit
                .OrderBy(plant => (
                    (plant.CostOfOperation(powerLeftToProduce) / Math.Min(plant.PMax, powerLeftToProduce))
                    + (plant.PowerProduced(powerLeftToProduce) / powerLeftToProduce)
                    )/2)
                .First();

            var production = new PowerPlantProduction
            {
                Name = powerPlant.Name,
                Power = powerPlant.PowerProduced(powerLeftToProduce)
            };

            totalPowerProduced += production.Power;

            orderOfMerit.Remove(powerPlant);
            totalCost += powerPlant.CostOfOperation(powerLeftToProduce);

            yield return production;
        }
    }
}
