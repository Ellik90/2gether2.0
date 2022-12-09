
using BASE;
using DATABASE;
namespace LOGIC;
public class MatchService : IMatchService
{
    IMatchHandeler _matchHandeler;

    public MatchService(IMatchHandeler matchHandeler)
    {
        _matchHandeler = matchHandeler;
    }

    public List<User> GetMatches(User user)
    {
        try
        {
            List<User> users = _matchHandeler.GetUsersByLandscapeAndAge(user);
            //när matchningarna är satta i matches
            //då kommer en metod select matchninarna i matches istället för denna för att se alla matchninar
            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    public bool LandscapeMatch(User user)
    {
        int rows = 0;
        rows = _matchHandeler.LandscapeMatch(user);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetTheMatches(User user)
    {
        List<User> matches = _matchHandeler.GetUsersByLandscapeAndAge(user);
        foreach (User item in matches)
        {
            _matchHandeler.CreateMatch(user, item.Id);
        }

    }
    public void InsertInterestsChoise(User user, List<int> interests)
    {
        foreach (int item in interests)
        {
            _matchHandeler.InsertInterestsChoise( user,item);
        }        

    }

     public void InsertAgesChoise(User user, List<int> ages)
    {
        foreach (int item in ages)
        {
            _matchHandeler.InsertAgesChoise( user,item);
        }        

    }

       public void InsertLandscapesChoise(User user, List<int> landsScapes)
    {
        foreach (int item in landsScapes)
        {
            _matchHandeler.InsertLandscapesChoise( user,item);
        }        

    }
}