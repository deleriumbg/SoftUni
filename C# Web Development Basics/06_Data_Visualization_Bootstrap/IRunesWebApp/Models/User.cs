namespace IRunesWebApp.Models
{
    public class User : BaseModel<string>
    {
        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public string Email { get; set; }
    }
}
