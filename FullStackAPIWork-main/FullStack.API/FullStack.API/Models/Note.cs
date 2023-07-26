namespace FullStack.API.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
        public string  CreatedAt  { get; set;}
    }
}
