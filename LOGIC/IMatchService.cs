using BASE;
using DATABASE;
namespace LOGIC;
public interface IMatchService
{

    public void SetMatches(User user);
    public List<User> GetMatches(User user);
    public void InsertInterestsChoise(User user, List<int> interests);
    public void InsertAgesChoise(User user, List<int> ages);
    public void InsertLandscapesChoise(User user, List<int> landsScapes);
    // public void SayYesOrNOToMatch(User user);
    public void SetTheYesAndNO(User user, string word);

}