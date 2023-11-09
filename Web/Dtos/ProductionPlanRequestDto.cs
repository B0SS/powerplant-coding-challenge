namespace Web.Dtos;

public class ProductionPlanRequestDto
{
    public int Load { get; set; }

    public FuelsDto Fuels { get; set; }

    public List<PowerplantDto> Powerplants { get; set; }
}
