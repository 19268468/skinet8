namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; } // if you want to call the id something else, you can use the [Key] attribute placed above 
        public string Name { get; set; }
    }
}