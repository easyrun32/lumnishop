namespace Core.Specifications
{
    //Pagination limit size
    public class ProductSpecParams
    {

        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            // stop us from returning more than 50 results
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;

        }


        //optional with ?
        public int? BrandId { get; set; }


        public int? TypeId { get; set; }

        public string Sort { get; set; }

        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }


    }
}