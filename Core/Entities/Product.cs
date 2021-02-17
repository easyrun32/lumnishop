namespace Core.Entities
{
    //Create classes for database entities
    public class Product : BaseEntity
    {
        //gonna contain two columns
        //auto generate a new Id with Id
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public int ProductBrandId { get; set; }
    }
}