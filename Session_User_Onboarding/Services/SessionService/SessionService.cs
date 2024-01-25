using Microsoft.EntityFrameworkCore;
using Session_User_Onboarding.Data;
using Session_User_Onboarding.Models;

namespace Session_User_Onboarding.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly DataContext _context;

        public SessionService(DataContext context)
        {
            _context = context;
        }

        public bool AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            
            // cannot call Save() here because the Session must be added first before saving to db
            return true;
        }

        public bool AddSession(Session session)
        {
            _context.Sessions.Add(session);
            return Save();
        }

        public bool DeleteSession(Session session)
        {
            _context.Sessions.Remove(session);
            return Save();
        }

        public List<Session> GetAllSessions()
        {
            return _context.Sessions.ToList();
        }

        public Session GetSessionById(int sessionId)
        {
            return _context.Sessions.Where(s => s.Id == sessionId).Include(s => s.Departments).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool SessionIdExists(int sessionId)
        {
            return _context.Sessions.Any(s=> s.Id == sessionId);
        }

        public Session SessionNameExists(string sessionName)
        {
            return _context.Sessions.FirstOrDefault(s=> s.Name == sessionName);
        }

        public bool UpdateSession(int sessionId, Session request)
        {
            var dbSession = _context.Sessions.Find(sessionId);

            dbSession.Name = request.Name;

            return Save();
        }
    }
}
