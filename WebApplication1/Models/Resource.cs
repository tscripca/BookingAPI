namespace WebApplication1.Models
{
    public class Resource
    {
        public int Id { get; set; } //primary key
        public string Name { get; set; } = null!; //required
        public string? Description { get; set; } //optional
    }
}
