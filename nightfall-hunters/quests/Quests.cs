using nightfall_hunters.classes;
using nightfall_hunters.ui;

namespace nightfall_hunters.quests;

public static class Quests
{
    public static QuestManager CreateQuests(Player player)
    {
        var questManager = new QuestManager();
        
        // Quest: Meet the main enemy. Learn about the enemy.
        // questManager.AddQuest(new BattleQuest(
        //     "Alley Ambush",
        //     player,
        //     Enemy.Enemies[3]
        // ));
        
        
        // Quest: Encounter and fight 2 newly turned's that were looking for a key at the library. Learn about the key.
        // questManager.AddQuest(new BattleQuest(
        //     "Alley Ambush",
        //     player,
        //     Enemy.Enemies[3]
        // ));

        // Quest: Figure out the password to the liberarians computer. reverse a string and guess a number. Find out about seacret event at the nightclub.
        // Quest: Find the hidden chest and unlock it. get some important item.
        
        // Quest: Call and gather the team for the secret nightclub event.
        // Quest: Enter the date for the secret event at the nightclub. correct date = Return amount of days till then. wrong date = no one shows up on the right day. mission failed.
        
        //
        
        // Quest: Enter the nightclub by calculating date. Show real id = fail. Show fake id (must bye in scetchy shop) = success.
        // Quest: The group counts the amount of enemies at the nightclub. Kenny sees 2, Meike sees 1 and you see 3. How amy enemies are there?
        // Quest: Fight enemies a nightclub.
        
        // Quest: Enemy flees town. Calculate the radius of where they could have gone and send a search party.
        
        
        // Quest: Calculate square root
        // Quest: find the smaller num
        // Quest: check for palindrome
        
        

        return questManager;
    }
}