using System.Text.Json;
using nightfall_hunters.classes;
using nightfall_hunters.helpers;

namespace nightfall_hunters.ui;

public class StoryNode
{
    public string Title { get; set; } = "";
    public string[] Description { get; set; } = Array.Empty<string>();
    internal static StoryNode[] Nodes { get; private set; }
    
    // Static constructor runs once before first use of StoryNode
    static StoryNode()
    {
        LoadFromJson();
    }
    
    private static void LoadFromJson()
    {
        try
        {
            string jsonString = File.ReadAllText("story-nodes.json");
            Nodes = JsonSerializer.Deserialize<StoryNode[]>(jsonString);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("⚠️ story-nodes.json not found.");
            Nodes = Array.Empty<StoryNode>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Failed to load story nodes: {ex.Message}");
            Nodes = Array.Empty<StoryNode>();
        }

    }

    public static StoryNode? GetNode(string title)
    {
        return Nodes.FirstOrDefault(x => 
            string.Equals(x.Title, title, StringComparison.OrdinalIgnoreCase));
    }
    
    public void Show(Player player, Enemy? enemy = null)
    {
        Display.DrawCenterText($"Quest: {Title}");
        Display.DrawSpacer();

        foreach (var text in Description)
        {
            string str = text.Replace("{playerSubject}", player.PronounSubject)
                .Replace("{playerSubject.ToLower()}", player.PronounSubject.ToLower())
                .Replace("{playerObject}", player.PronounObject)
                .Replace("{playerPossessive}", player.PronounPossessive)
                .Replace("{playerName}", player.Name);
            
            if (enemy != null)
            {
                 str = str
                    .Replace("{enemySubject}", enemy.PronounSubject)
                    .Replace("{enemySubject.ToLower()}", enemy.PronounSubject
                        .ToLower())
                    .Replace("{enemyObject}", enemy.PronounObject)
                    .Replace("{enemyPossessive}", enemy.PronounPossessive)
                    .Replace("{enemyName}", enemy.Name);
            }
            
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
