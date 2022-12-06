
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
    public MatchService() { }
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