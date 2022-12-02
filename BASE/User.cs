using System.ComponentModel;
namespace BASE;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string? Gender { get; set; }
    public string Age { get; set; }
    public string Email { get; set; }
    public string PersonalNumber {get;set;}
    public string PassWord { get; set; }
    public string AboutMe { get; set; }
    public LandScape LandScape { get; set; }
    public int LandscapeId{get;set;}

    public User(string name, string lastName, string gender, string age, string email, string personalNumber,string passWord, LandScape landScape)
    {
        Name = name;
        LastName = lastName;
        Gender = gender;
        Age = age;
        Email = email;
        PersonalNumber = personalNumber;
        PassWord = passWord;
        LandScape = landScape;
    }
    public User()
    {

    }
    public enum Landscapes
    {
        Undefined,
        Norrbotten,
        Västerbotten,
        Jämtland,
        Västernorrland,
        Gävleborg,
        Dalarna,
        Uppsala,
        Västmanland,
        Värmland,
        Stockholm,
        Södermanland,
        Örebro,
        Östergötland,
        [Description("Västra Götaland")]VästraGötaland,
        Jönköping,
        Kalmar,
        Kronoberg,
        Gotland,
        Halland,
        Blekinge,
        Skåne


    }
}