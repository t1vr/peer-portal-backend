namespace Application.IServices
{
    /// <summary>
    /// Base service interface
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// Gets the currently logged in user id
        /// </summary>
        /// <returns>Returns the user id</returns>
        public string GetCurrentUserId();

        /// <summary>
        /// Gets the currently logged in user name
        /// </summary>
        /// <returns>Returns the user id</returns>
        public string GetCurrentUsername();
    }
}
