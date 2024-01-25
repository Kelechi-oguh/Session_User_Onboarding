namespace Session_User_Onboarding.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
