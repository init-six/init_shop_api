namespace init_api.Models
{
    public class SpuDetailUpdateDto
    {
        public string? Description { get; set; }
        public string? Specifications { get; set; }
        public string? SpecTemplate { get; set; }
        public string? PackingList { get; set; }
        public string? AfterService { get; set; }
        public SpuDetailUpdateDto()
        {
        }
    }
}
