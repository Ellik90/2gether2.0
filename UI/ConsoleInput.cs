public class ConsoleInput
{
    public static string GetString(string output)
    {
        string input = string.Empty;
        do
        {
            Console.WriteLine(output);
            input = Console.ReadLine();

        } while (string.IsNullOrWhiteSpace(input) == true);
        return input;
    }
    public static int GetInt(string output)
    {
        int inputInt = 0;
        while (true)
        {
            try
            {
                Console.WriteLine(output);
                string input = Console.ReadLine();
                inputInt = int.Parse(input);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a digit.");
            }
        }
        return inputInt;
    }
}