namespace Application.Handlers.Interfaces
{
    public interface IApplicationUserHandler
    {
        void OnUserSignUp(string login, string password);
    }
}
