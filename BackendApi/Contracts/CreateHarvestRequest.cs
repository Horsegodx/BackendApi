namespace BackendApi.Contracts.Harvest
{
    public class CreateHarvestRequest
    {
        public DateTime HarvestDate { get; set; }
        public int PlantId { get; set; }
    }
}
