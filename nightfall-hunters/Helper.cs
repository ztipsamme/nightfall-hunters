using System.Collections;

namespace nightfall_hunters;

public static class Helper
{
    // Solutions discussed, improved and co-designed with ChatGPT
    private static Random _rng = new();

    public static void Prompt(string prompt)
    {
        Ui.TextColor(Ui.PrimaryColor);
        Console.Write(prompt);
        Ui.TextColor(Ui.SecondaryColor);
        Console.Write(" ➤ ");
    }

    public static void DrawMenuOptions(IEnumerable<string> options)
    {
        int i = 1;
        foreach (var option in options)
        {
            Console.WriteLine($"{i}. {option}");
            i++;
        }
    }

    public static T AskUntilValid<T>(string prompt, string errMessage,
        Func<string, bool> validate = null, Func<string, T> convert = null)
    {
        while (true)
        {
            Prompt(prompt);
            int startline = Ui.GetStartLine;

            Ui.TextColor();
            string? input = Console.ReadLine() ?? "";

            if (validate(input)) return convert(input);

            Ui.TextColor(Ui.DangerColor);
            Console.WriteLine($"{errMessage} Try again.");
            Thread.Sleep(1200);

            Ui.TextColor();
            Ui.Clear(startline);
        }
    }

    // ChatGPT helped
    public static int AskFromList<T>(
        IList<T> options,
        string prompt = "Select",
        Func<T, string>? display = null)
    {
        return AskUntilValid(
            prompt,
            $"Must be int between 1 and {options.Count}",
            input => int.TryParse(input, out int opt) && opt > 0 &&
                     opt <= options.Count,
            input => int.Parse(input) - 1
        );
    }

    public static int ShowAndUseMenu(string[] options, string prompt = "Select")
    {
        if (options.Length == 0)
            throw new ArgumentException("No options where provided.");

        Console.WriteLine($"{prompt}: ");
        DrawMenuOptions(options);

        return AskFromList(options);
    }

    public static void ShowAndUseMenu(List<(string, Action)> options,
        string prompt = "Select")
    {
        List<(string, Action)> optionList = options.ToList();
        int startLine = Ui.GetStartLine;

        Console.WriteLine($"{prompt}: ");
        for (int i = 0; i < optionList.Count; i++)
            Console.WriteLine($"{i + 1}. {optionList[i].Item1}");

        var selected = options[AskFromList(options)];

        Ui.Clear(startLine);
        Ui.LoadingAnimation();
        Ui.Clear(startLine);

        selected.Item2();
    }

    public static T ShowAndUseMenu<T>(string prompt)
    {
        var optionList = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        Console.WriteLine($"{prompt}: ");

        for (int i = 0; i < optionList.Count; i++)
            Console.WriteLine($"{i + 1}. {optionList[i]}");

        return optionList[AskFromList(optionList)];
    }


    public static int RollDice(int sides = 8)
    {
        return _rng.Next(1, sides + 1);
    }
}