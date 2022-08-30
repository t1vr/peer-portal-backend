using Application.IServices;
using Application.Shared.Session;

namespace Application.Services
{
    /// <summary>
    /// Base Service class
    /// </summary>
    public class BaseService : IBaseService
    {
        private readonly UserSession _session;

        /// <summary>
        /// Base Constructor
        /// </summary>
        /// <param name="session"></param>
        public BaseService(UserSession session)
        {
            _session = session;
        }

        /// <summary>
        /// Gets the currently logged in user id
        /// </summary>
        /// <returns>Returns the user id</returns>
        public string GetCurrentUserId()
        {
            return _session.UserId;
        }

        public string GetCurrentUsername()
        {
            return _session.Username;
        }
    }
}
