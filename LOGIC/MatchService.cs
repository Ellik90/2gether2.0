
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
}