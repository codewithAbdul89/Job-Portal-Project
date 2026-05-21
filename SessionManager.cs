using JobPortalSystemProject.DataBase;
using JobPortalSystemProject.Models;

namespace JobPortalSystemProject
{
    public static class SessionManager
    {
        // CURRENT LOGGED-IN USER
        public static User CurrentUser;

        // REFRESH USER DATA
        public static void RefreshUser()
        {
            // REPOSITORY OBJECT
            UserRepository repository =
                new UserRepository();

            // GET LATEST USER
            CurrentUser =
                repository.GetUserById(
                    CurrentUser.Id
                );
        }
    }
}