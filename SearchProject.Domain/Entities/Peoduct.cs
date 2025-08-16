namespace SearchProject.Domain.Entities
{
    public class Product
    {
        private readonly List<ProductVariant> _variants = new();
        public IReadOnlyCollection<ProductVariant> Variants => _variants.AsReadOnly();
        public int Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public int CategoryId { get; private set; }
        public bool IsDeleted { get; private set; }

        private Product() { }

        private Product(string name, string description, int categoryId)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            IsDeleted = false;
        }

        public static Product Create(string name, string description, int categoryId)
            => new(name, description, categoryId);

        public IReadOnlyCollection<ProductAttribute> GetAllAttributes()
        {
            return _variants
                .SelectMany(v => v.Attributes)
                .DistinctBy(a => (a.Key, a.Value))
                .ToList();
        }

        public void AddVariant(string sku, int quantity, bool isActive, List<ProductAttribute> attributes)
        {
            if (_variants.Any(v => v.Sku == sku))
                throw new InvalidOperationException("Duplicate SKU");

            var variant = ProductVariant.Create(sku, quantity, isActive, attributes);
            _variants.Add(variant);
        }

        public void Update(string name, string description, int categoryId)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }

        public void SoftDelete() => IsDeleted = true;
        public void Restore() => IsDeleted = false;



    }

}
