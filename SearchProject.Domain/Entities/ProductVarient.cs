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
        private ProductVariant() { }
        private ProductVariant(string sku, int quantity, bool isActive)
        {
            Sku = sku;
            Quantity = quantity;
            IsActive = isActive;
        }


        public static ProductVariant Create(string sku, int quantity, bool isActive, List<ProductAttribute> attributes)
        {
            var variant = new ProductVariant(sku, quantity, isActive);
            foreach (var attr in attributes)
                variant.AddAttribute(attr);
            return variant;
        }
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
