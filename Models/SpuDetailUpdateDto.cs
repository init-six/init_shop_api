namespace init_api.Models
{
    public class SpuDetailUpdateDto
    {
        public string? Description { get; set; }
        public string? SpecTemplate { get; set; }
        public string? PackingList { get; set; }
        public string? AfterService { get; set; }
        public string? ProductDetails { get; set; }
        public string? FeatureAndBenefits { get; set; }
        public SpuDetailUpdateDto()
        {
            this.Description = "";
            this.SpecTemplate = "";
            this.PackingList = "";
            this.AfterService = "";
            this.ProductDetails = "";
            this.FeatureAndBenefits = "";
        }
    }
}
