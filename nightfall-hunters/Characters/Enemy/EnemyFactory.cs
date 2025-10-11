using nightfall_hunters.classes;
using nightfall_hunters.classes.EnemyClasses;

namespace Nightfall_Hunters.Characters;

public class EnemyFactory
{
    public static Enemy[] Enemies =
    {
        new Vampire("Fangs", Gender.Male, 80,
            10), // Main villain and the final boss. Will return and get
        // stronger every time.
        new Vampire("Shadow", Gender.NonBinary, 75, 12),
        new Vampire("Sarah", Gender.Female, 85, 9),
        new Vampire("Dominik", Gender.Male, 90,
            11),
        new Werewolf("Crash", Gender.Male, 120, 8),
        new Werewolf("Tara", Gender.Female, 100, 10),
        new Werewolf("Luke", Gender.Male, 110, 9),
        new Demon("Mazikeen", Gender.Female, 80, 8),
        new Demon("Anyanka", Gender.Female, 90, 8),
        new Vampire("Zyra", Gender.NonBinary, 85, 10),
    };
    
    public static Enemy GetByName(string name)
    {
        var enemy = Enemies.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (enemy == null)
            throw new Exception($"Enemy '{name}' not found.");
        return enemy;
    }

    public static Enemy GetRandom()
    {
        var random = new Random();
        return Enemies[random.Next(Enemies.Length)];
    }
}