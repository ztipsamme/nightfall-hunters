namespace nightfall_hunters;

public static class Helper
{
    // Solutions discussed, improved and co-designed with ChatGPT
    private static Random _rng = new Random();

    public static T AskUntilValid<T>(string prompt, string errMessage,
        Func<string, bool> validate = null, Func<string, T> convert = null)
    {
        // defaults if non provided
        validate ??= input => !string.IsNullOrWhiteSpace(input);
        convert ??= input => (T)Convert.ChangeType(input, typeof(T));

        while (true)
        {
            Console.Write($"{prompt}: ");
            int startline = Ui.GetStartLine;

            string? input = Console.ReadLine() ?? "";

            if (validate(input)) return convert(input);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{errMessage} Try again.");
            Thread.Sleep(1200);

            Console.ResetColor();
            Ui.Clear(startline);
        }
    }

    public static int ShowAndUseMenu(string[] options, string prompt = "Select")
    {
        if (options.Length == 0)
            throw new ArgumentException("No options where provided.");

        Console.WriteLine($"{prompt}: ");

        for (int i = 0; i < options.Length; i++)
            Console.WriteLine($"{i + 1}: {options[i]}");


        var selected = AskUntilValid("Select",
            $"Must be between 1 and {options.Length}.",
            validate: input =>
                int.TryParse(input, out int opt) && opt >= 1 &&
                opt <= options.Length,
            convert: input => int.Parse(input)
        );

        return selected;
    }

    public static void ShowAndUseMenu(List<(string, Action)> options,
        string prompt = "Select")
    {
        List<(string, Action)> optionList = options.ToList();
        int startLine = Ui.GetStartLine;

        Console.WriteLine($"{prompt}: ");
        for (int i = 0; i < optionList.Count; i++)
            Console.WriteLine($"{i + 1}: {optionList[i].Item1}");


        var selected = AskUntilValid<(string, Action)>("Select",
            $"Must be between 1 and {optionList.Count}.",
            input => int.TryParse(input, out int opt) && opt > 0 &&
                     opt <= optionList.Count,
            input => optionList[int.Parse(input) - 1]
        );

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

        return AskUntilValid<T>(
            "Select",
            $"Must be int between 1 and {optionList.Count}",
            input => int.TryParse(input, out int opt) && opt > 0 &&
                     opt <= optionList.Count,
            input => optionList[int.Parse(input) - 1]
        );
    }

    public static int RollDice(int sides = 8)
    {
        return _rng.Next(1, sides + 1);
    }
}