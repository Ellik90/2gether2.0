
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

    public void SetMatches(User user)  //denna sätter matchningarna 
    {
        try
        {
            List<User> users = _matchHandeler.GetUsersByLandscapeAndAge(user);
            List<User> usersToMatches = new();
            foreach (User matches in users)
            {
                int id = _matchHandeler.CheckIfMatchesExists(user, matches.Id);
                if(id < 1)
                {
                    usersToMatches.Add(matches);
                }
            }
            //DOM SOM EJ ÄR I MATCHES ÄN
            foreach (User u in usersToMatches)
            {
                _matchHandeler.CreateMatch(user, u.Id);
            }
            //hämta MATCHES som returneras till ui
            //när matchningarna är satta i matches
            //då kommer en metod select matchninarna i matches istället för denna för att se alla matchninar
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public List<User> GetMatches(User user)
    {
        List<User> myMatches = new();
       myMatches = _matchHandeler.GetMatches(user);
        return myMatches;
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
    public void SetTheYesAndNO(User user, string word)
    {
        List<User> matches = _matchHandeler.GetUsersByLandscapeAndAge(user);
        foreach (User item in matches)
        {
            _matchHandeler.SayYesOrNoToMatch(user, item.Id);
        }

    }
    public void InsertInterestsChoise(User user, List<int> interests)
    {
        foreach (int item in interests)
        {
            _matchHandeler.InsertInterestsChoise(user, item);
        }

    }

    public void InsertAgesChoise(User user, List<int> ages)
    {
        foreach (int item in ages)
        {
            _matchHandeler.InsertAgesChoise(user, item);
        }

    }

    public void InsertLandscapesChoise(User user, List<int> landsScapes)
    {
        foreach (int item in landsScapes)
        {
            _matchHandeler.InsertLandscapesChoise(user, item);
        }

    }
}