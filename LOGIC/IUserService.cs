public interface IUserService
{
    public bool CreateUser(User user);
    public bool CheckUserEmailExists(string email);
    public bool CheckUserPersonalNumberExists(string personalNumber);
}