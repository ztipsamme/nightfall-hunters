using System.Text.Json;

namespace nightfall_hunters.Quests;

public class QuestHelper
{
    public static T[] LoadFromJson<T>(string path)
    {
        try
        {
            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T[]>(jsonString);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"⚠️ {path} not found.");
            return Array.Empty<T>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Failed to load {path}: {ex.Message}");
            return Array.Empty<T>();
        }
    }

}