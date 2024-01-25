using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session_User_Onboarding.Dtos;
using Session_User_Onboarding.Models;
using Session_User_Onboarding.Services.SessionService;

namespace Session_User_Onboarding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public SessionController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSessionWithDepartments([FromBody] SessionDto request)
        {
            var sessionExists = _sessionService.SessionNameExists(request.Name);

            if (sessionExists != null)
                return Ok("Session Already Exists");

            var session = _mapper.Map<Session>(request);

            if (request.Departments == null)
            {
                session.Departments = new List<Department>();
            }

            foreach (var department in session.Departments)
            {
                _sessionService.AddDepartment(department);
            }

            var sessionCreated = _sessionService.AddSession(session);

            if (!sessionCreated)
            {
                ModelState.AddModelError("", "Something wrong happened when crateing the session");
                return StatusCode(500, ModelState);
            }

            return Ok(request);
        }

        [HttpGet("all-sessions")]
        public IActionResult GetAllSessions()
        {
            var sessions = _mapper.Map<List<SessionGetDto>>(_sessionService.GetAllSessions());
            return Ok(sessions);
        }


        [HttpGet("{sessionId}")]
        public IActionResult GetSession(int sessionId)
        {
            var session = _sessionService.GetSessionById(sessionId);

            var sessionMap = _mapper.Map<SessionDto>(session);

            if (session == null)
                return BadRequest("Session does not exist");

            return Ok(sessionMap);
        }


        [HttpPut("{sessionId}")]
        public IActionResult UpdateSessionName(int sessionId, [FromBody] SessionGetDto request)
        {
            var sessionExists = _sessionService.SessionIdExists(sessionId);

            if (!sessionExists)
                return BadRequest("Session does not exist");

            var sessionMap = _mapper.Map<Session>(request);
            var updateSession = _sessionService.UpdateSession(sessionId, sessionMap);

            if (!updateSession)
            {
                ModelState.AddModelError("", "Something wrong happened when crateing the session");
                return StatusCode(500, ModelState);
            }

            return Ok(request);
        }


        [HttpDelete("{sessionId}")]
        public IActionResult DeleteSession(int sessionId)
        {
            return Ok();
        }

    }
}
