namespace FullStack.API.Models
{
    public class User
    {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Nickname { get; set; }
            public string Picture { get; set; }
            public string Auth0Id { get; set; }

    }
}
