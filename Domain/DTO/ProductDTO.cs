using System;
namespace Domain.DTO
{
    public class ProductDTO
    {
        public string SKU { get; set; }
        public int Vintage { get; set; }
        public string ItemName { get; set; }
        public int ListPrice { get; set; }
        public string ImageSmallURL { get; set; }
        public string SpecificAppellation { get; set; }
        public string Varietal { get; set; }
        public int OutOfStockYN { get; set; }
    }
}
