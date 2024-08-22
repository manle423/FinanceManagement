/*
 * How to use this Class 
 * 
 * * * * Set the user session
 * 
 * UserSession.Instance.SetUser(userId, username);
 *
 *
 * * * * Get the user ID from the session
 * 
 * int userId = UserSession.Instance.UserId;
 * string username = UserSession.Instance.Username;
 * 
 * 
 * * * * Clear the user session
 * UserSession.Instance.ClearSession();
 */


namespace FinanceManagement.Services
{
    public class UserSession
    {
        private static UserSession _instance;

        public int UserId { get; private set; }
        public string Username { get; private set; }

        private UserSession() { }

        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserSession();
                }
                return _instance;
            }
        }

        public void SetUser(int userId, string username)
        {
            UserId = userId;
            Username = username;
        }

        public void ClearSession()
        {
            UserId = 0;
            Username = string.Empty;
        }
    }

}