using nightfall_hunters.ui;

namespace nightfall_hunters.helpers;

public static class InputHelper
{
    public static T AskUntilValid<T>(string prompt, string errMessage, Func<string, bool> validate, Func<string, T> convert)
    {
        while (true)
        {
            Console.Write($"{prompt} ");
            string input = Console.ReadLine() ?? "";
            if (validate(input))
                return convert(input);

            Console.WriteLine(errMessage);
        }
    }
    
    public static T ShowMenu<T>(string prompt, IEnumerable<T> options)
    {
        var optionList = options.ToList();
        Console.WriteLine(prompt);

        for (int i = 0; i < optionList.Count; i++)
            Console.WriteLine($"[{i + 1}] {optionList[i]}");
        ui.Display.DrawSpacer();

        return AskUntilValid<T>(
            "Select option:",
            $"Must be int between 1 and {optionList.Count}",
            input => int.TryParse(input, out int opt) && opt > 0 && opt <= optionList.Count,
            input => optionList[int.Parse(input) - 1]
        );
    }
    public static T ShowMenu<T>(string prompt) where T : Enum
    {
        return ShowMenu(prompt, Enum.GetValues(typeof(T)).Cast<T>());
    }
    
    public static string ShowMenu(string prompt, List<MenuItem> options)
    {
        List<MenuItem> optionList = options.ToList();
        Console.WriteLine(prompt);

        for (int i = 0; i < optionList.Count; i++)
        {
            string key = optionList[i].HotKey ?? (i + 1).ToString();
            Console.WriteLine($"[{key}] {optionList[i].Title}");
        }

        ui.Display.DrawSpacer();

        return InputHelper.AskUntilValid(
            "Select option:",
            $"Must be a number between 1 and {options.Count} or a valid hotkey",
            input =>
            {
                return options.Any(opt =>
                           opt.HotKey?.Equals(input,
                               StringComparison.OrdinalIgnoreCase) == true)
                       || (int.TryParse(input, out int num) && num > 0 &&
                           num <= options.Count);
            },
            input => input
        );
    }
}