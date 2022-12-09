using LOGIC;
using DATABASE;
using BASE;

public class MatchOperator
{
    IUserService _userService;
    ILoginService _loginService;
    IMatchService _matchService;

    public MatchOperator(IUserService userService, ILoginService loginService, IMatchService matchService)
    {
        _userService = userService;
        _loginService = loginService;
        _matchService = matchService;
    }
    public MatchOperator() { }

    public void ChooseCriterias(User user)
    {
        List<int> myInterests = new List<int>();
        List<int> agespans = new List<int>();
        List<int> landscapes = new List<int>();

        ShowAgeSpan();
        int age = ConsoleInput.GetInt("Vilket åldersspann är du intresserad av? ");
        UserOperator op = new();
        agespans.Add(age);
        _matchService.InsertAgesChoise(user,agespans);
        op.ShowLandscapes();
        int landScape = ConsoleInput.GetInt("Choose landscapes: ");
        landscapes.Add(landScape);
        _matchService.InsertLandscapesChoise(user, landscapes);
        ShowInterests();
        int interests = ConsoleInput.GetInt("Choose interests: ");
        myInterests.Add(interests);
        _matchService.InsertInterestsChoise(user, myInterests);


    }
    public void ShowAgeSpan()
    {
        Dictionary<int, string> Ages = new Dictionary<int, string>();
        Ages.Add(1, "18-25");
        Ages.Add(2, "26-33");
        Ages.Add(3, "34-41");
        Ages.Add(4, "42-49");
        Ages.Add(5, "50-57");
        Ages.Add(6, "58-65");
        Ages.Add(7, "66-73");
        Ages.Add(8, "74-81");
        Ages.Add(9, "82-90");
        foreach (KeyValuePair<int, string> age in Ages)
        {
            Console.WriteLine($"[{age.Key}] {age.Value}");
        }
    }
    public void ShowInterests()
    {
        int index = 1;

        foreach (string name in Enum.GetNames(typeof(Interests)))
        {
            Console.WriteLine($"[{index}] {name}");
            index++;
        }
    }
    public enum Interests
    {
        Hemmamysarn = 1,
        Resenären = 2,
        Friluftslevaren = 3,
        Festprissen = 4
    }

}