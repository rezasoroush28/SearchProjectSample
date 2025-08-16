namespace SearchProject.Domain.Entities
{
    public class ProductVariant
    {
        private readonly List<ProductAttribute> _attributes = new();
        public IReadOnlyCollection<ProductAttribute> Attributes => _attributes;
        public int Id { get; private set; }
        public string Sku { get; private set; } = null!;
        public int Quantity { get; private set; }
        public bool IsActive { get; private set; }

        public ProductVariant(string sku, int quantity, bool isActive)
        {
            Sku = sku;
            Quantity = quantity;
            IsActive = isActive;
        }
        private ProductVariant() { }

        public void AddAttribute(ProductAttribute attribute)
        {
            _attributes.Add(attribute);
        }

        public void Update(int quantity, bool isActive)
        {
            Quantity = quantity;
            IsActive = isActive;
        }
    }
}
