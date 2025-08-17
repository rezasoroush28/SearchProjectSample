namespace SearchProject.Domain.Entities
{
    public class Category
    {
        public readonly List<Category> ChildCategories = new();
        
        public int Id { get; private set; }
        public string Name { get; private set; } = null!;
        public int? ParentCategoryId {  get; private set; }
        public Category? ParentCategory { get; private set; }


        private Category() { }
        public Category(string name, int? parentId = null)
        {
            Name = name;
            ParentCategoryId = parentId;
        }

        public void Update(string name, int? parentId)
        {
            Name = name;
            ParentCategoryId = parentId;
        }
    }

}
