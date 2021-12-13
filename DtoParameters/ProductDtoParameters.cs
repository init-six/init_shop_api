namespace init_api.DtoParameters
{
    public class ProductDtoParameters
    {
        private const int MaxPageSize=20;
        public int PageNumber {get;set;}=1;
        public string? ProductName {get;set;}
        private int _pageSize=5;
        public int PageSize
        {
            get=>_pageSize;
            set=>_pageSize=(value>MaxPageSize)?MaxPageSize:value;
        }
    }
}
