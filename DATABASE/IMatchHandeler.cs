using BASE;
namespace DATABASE;
public interface IMatchHandeler
{
     public int LandscapeMatch(User user);
     public List<User> GetUsersByLandscapeAndAge(User user);
     public void CreateMatch(User user, int id);
    
}