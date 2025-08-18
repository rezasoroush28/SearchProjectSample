namespace SearchProject.Application.Models.Search
{
    public class ProductSearchDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }

        public List<ProductVariantDto> Variants { get; set; } = new();
    }

    public class ProductVariantDto
    {
        public int Id { get; set; }
        public string Sku { get; set; } = null!;
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

        public List<ProductAttributeDto> Attributes { get; set; } = new();
    }

    public class ProductAttributeDto
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
