using System.Text.Json;
using nightfall_hunters.classes;
namespace nightfall_hunters.ui;

public class StoryNode
{
    public string Title { get; set; } = "";
    public string[] Texts { get; set; } = Array.Empty<string>();
    public static StoryNode[] Nodes { get; private set; }
    
    // Static constructor runs once before first use of StoryNode
    static StoryNode()
    {
        LoadNodes();
    }

    private static void LoadNodes()
    {
        try
        {
            string jsonString = File.ReadAllText("story-nodes.json");
            Nodes = JsonSerializer.Deserialize<StoryNode[]>(jsonString);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("fuck");
            Nodes = Array.Empty<StoryNode>();
        }
    }

    public static StoryNode? GetNode(string title)
    {
        return Nodes.FirstOrDefault(x => 
            string.Equals(x.Title, title, StringComparison.OrdinalIgnoreCase));
    }
    
    public void Show(Player player)
    {
        Display.DrawCenterText(Title);
        Display.DrawSpacer();

        foreach (var text in Texts)
        {
            string str = text.Replace("{playerSubject}", player.PronounSubject)
                .Replace("{playerSubject.ToLower()}", player.PronounSubject.ToLower())
                .Replace("{playerObject}", player.PronounObject)
                .Replace("{playerPossessive}", player.PronounPossessive)
                .Replace("{playerName}", player.Name);

            Tell(str);
        }
    }
    
    public static void Tell(string text, int delay = 30)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay); // pause between lines
        }
        Thread.Sleep(400); // pause before continuing
        Display.DrawSpacer();
    }
}
