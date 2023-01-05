using BASE;
namespace DATABASE;
public interface IMatchHandeler
{
   
     public List<User> GetUsersByLandscapeAndAgeAndInterests(User user);
     public void CreateMatch(User user, int id);
     public void InsertInterestsChoise(User user, int interests);
     public void InsertAgesChoise(User user, int ages);
     public void InsertLandscapesChoise(User user, int landscapes);
     public void SayYesOrNoToMatch(User user, int id);
     public List<User> GetMatches(User user);
     public int CheckIfMatchesExists(User user, int otherUserId);
    
    
}