using Session_User_Onboarding.Models;

namespace Session_User_Onboarding.Services.SessionService
{
    public interface ISessionService
    {
        bool AddSession(Session session);
        bool AddDepartment(Department department);
        List<Session> GetAllSessions();
        Session GetSessionById(int sessionId);
        Session SessionNameExists(string sessionName);
        bool SessionIdExists(int sessionId);
        bool UpdateSession(int sessionId, Session request);
        bool DeleteSession(Session session);
        bool Save();
    }
}
