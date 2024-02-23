namespace ProductManagementWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public double? OldPrice { get; set; }
        public double? NewPrice { get; set; }
        public int? Discount { get; set; }
        public string? SingleImage { get; set; }
        public List<Thumb>? Thumbs { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }


    }
}
