namespace nightfall_hunters.helpers;

public static class InputHelper
{
    public static T AskUntilValid<T>(string prompt, string errMessage, Func<string, bool> validate, Func<string, T> convert)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            if (validate(input))
                return convert(input);

            Console.WriteLine(errMessage);
        }
    }
    
    public static T AskEnum<T>(string prompt) where T : Enum
    {
        var values = Enum.GetValues(typeof(T));
        Console.WriteLine(prompt);
        for (int i = 0; i < values.Length; i++)
            Console.WriteLine($"[{i + 1}] {values.GetValue(i)}");

        return AskUntilValid<T>(
            "Select option: ",
            $"Must be int between 1 and {values.Length}",
            input => int.TryParse(input, out int opt) && opt > 0 && opt <= values.Length,
            input => (T)values.GetValue(int.Parse(input) - 1)
        );
    }
}