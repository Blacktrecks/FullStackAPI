namespace FullStack.API.Models
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public bool Completed { get; set; }
    }
}
