using Route.GYM.BLL.DTOs.SessionDTO;

namespace Route.GYM.BLL.Services.Sessions
{
    public interface ISessionService
    {
        // Get All Sessions
        IEnumerable<SessionDTO> GetAllSessions();

        // Get Sesssion By Id
        SessionDTO? GetSessionById(int seesionId);

        // Create Session
        bool CreateSession(CreateSessionDTO input);

        // Get Session To Update
        UpdateSessionDTO? GetSessionToUpdate(int sessionid);
        // Update Session
        bool UpdateSession(int sessionId ,UpdateSessionDTO input);

        // Delete Session
        bool DeleteSession(int sessionId);
    }
}
