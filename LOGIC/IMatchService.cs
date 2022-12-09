using BASE;
using DATABASE;
namespace LOGIC;
public interface IMatchService
{
    public List<User> GetMatches(User user);
    public void SetTheMatches(User user);
    public void InsertInterestsChoise(User user, List<int> interests);
    public void InsertAgesChoise(User user, List<int> ages);
    public void InsertLandscapesChoise(User user, List<int> landsScapes);

}