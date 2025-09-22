using nightfall_hunters.classes;
using nightfall_hunters.helpers;

namespace nightfall_hunters.ui;

public class StoryNode
{
    public string Title { get; set; } = "";
    public string[] Texts { get; set; } = Array.Empty<string>();

    public void Show(Player player)
    {
        Console.Clear();
        Console.WriteLine(Title);

        foreach (var text in Texts)
        {
            string str = text.Replace("{playerSubject}", player.PronounSubject)
                .Replace("{playerSubject.ToLower()}", player.PronounSubject.ToLower())
                .Replace("{playerObject}", player.PronounObject)
                .Replace("{playerPossessive}", player.PronounPossessive);

            StoryNodeHelper.StoryTeller(str);
        }
    }
}
