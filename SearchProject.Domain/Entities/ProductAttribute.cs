namespace SearchProject.Domain
{
    public class ProductAttribute
    {
        public string Key { get;}
        public string Value { get;}

        public ProductAttribute(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
