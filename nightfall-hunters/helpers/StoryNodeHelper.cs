using System.Text.Json;
using nightfall_hunters.ui;

namespace nightfall_hunters.helpers;

public static class StoryNodeHelper
{
    static readonly StoryNode[] StoryNodes = LoadNodes();

    private static StoryNode[] LoadNodes()
    {
        try
        {
            string jsonString = File.ReadAllText("story-nodes.json");
            return JsonSerializer.Deserialize<StoryNode[]>(jsonString) ?? Array.Empty<StoryNode>();
        }
        catch
        {
            return Array.Empty<StoryNode>();
        }
    }

    public static StoryNode? FindNode(string title)
    {
        return StoryNodes.FirstOrDefault(x => x.Title == title);
    }
        
    public static void StoryTeller(string text, int delay = 30)
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
