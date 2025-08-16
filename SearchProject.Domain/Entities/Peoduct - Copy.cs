namespace SearchProject.Domain.Entities
{
    public class Category
    {
        private readonly List<ProductVariant> _variants = new();
        private readonly List<Category> _childCategories = new();
        public int Id { get; private set; }
        public string Name { get; private set; } = null!;
        public int? ParentCategoryId {  get; private set; }
        public Category ParentCategory {  get; private set; }
        

        private Category() { }
        public Category(string name, int? parentId = null)
        {
            Name = name;
            ParentCategoryId = parentId;
        }

        public IReadOnlyCollection<ProductAttribute> GetAllAttributes()
        {
            return _variants
                .SelectMany(v => v.Attributes)
                .DistinctBy(a => (a.Key, a.Value))
                .ToList();
        }

        public void Update(string name, int? parentId)
        {
            Name = name;
            ParentCategoryId = parentId;
        }
    }

}
