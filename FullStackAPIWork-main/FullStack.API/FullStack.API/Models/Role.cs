namespace FullStack.API.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanCreate { get; set; }
    }
}
