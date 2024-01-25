namespace Session_User_Onboarding.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
