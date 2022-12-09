using BASE;
namespace DATABASE;
public interface IMatchHandeler
{
     public int LandscapeMatch(User user);
     public List<User> GetUsersByLandscapeAndAge(User user);
     public void CreateMatch(User user, int id);
     public void InsertInterestsChoise(User user, int interests);
     public void InsertAgesChoise(User user, int ages);
     public void InsertLandscapesChoise(User user, int landscapes);
    
}