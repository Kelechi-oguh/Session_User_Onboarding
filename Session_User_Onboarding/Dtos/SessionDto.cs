using Session_User_Onboarding.Models;

namespace Session_User_Onboarding.Dtos
{
    public class SessionDto
    {
        public string Name { get; set; }
        public List<DepartmentDto>? Departments { get; set; }
    }
}
