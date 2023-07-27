namespace FretesWebApplication.Interface
{
    public interface IAuthenticationService
    {
        bool UserAuthentication(string username, string password);
    }
}
