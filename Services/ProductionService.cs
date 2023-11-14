using Services.Models;
using Web.Dtos;

namespace Services;

public class ProductionService
{
    public IEnumerable<PowerPlantProduction> ComputeProductionPlan(int load, IReadOnlyCollection<PowerPlant> powerPlants)
    {
        decimal powerLeftToProduce = load;
        var availablePlants = powerPlants
            .Where(plant => plant.PMax > 0)
            .ToList();

        if (availablePlants.Sum(plant => plant.PMax) < load) {
            throw new ArgumentException("The power plants do not have a production capacity sufficient to match the load.");
        }

        while (powerLeftToProduce > 0)
        {
            var powerPlant = availablePlants
                .OrderBy(plant => plant.MarginalCost(powerLeftToProduce))
                .ThenBy(plant => Math.Abs(powerLeftToProduce - plant.PowerProduced(powerLeftToProduce)))
                .First();

            var production = new PowerPlantProduction
            {
                Name = powerPlant.Name,
                Power = Math.Round(powerPlant.PowerProduced(powerLeftToProduce), 1)
            };

            powerLeftToProduce -= production.Power;

            availablePlants.Remove(powerPlant);

            yield return production;
        }
    }
}
