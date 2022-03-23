namespace init_api.Models.Product
{
    public class SpuDetailDto
    {
        public string? Description { get; set; }
        public string? SpecTemplate { get; set; }
        public string? PackingList { get; set; }
        public string? AfterService { get; set; }
        public string? ProductDetails { get; set; }
        public string? FeatureAndBenefits { get; set; }
        public SpuDetailDto()
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
