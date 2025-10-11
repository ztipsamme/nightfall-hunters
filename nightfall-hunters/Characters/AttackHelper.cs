using nightfall_hunters;
using nightfall_hunters.classes;

namespace Nightfall_Hunters.Characters;

public static class AttackHelper
{
    public static void FormatActionMessage(string attackerName, Character opponent, int damage , string actionVerb, string weaponOrAbility = "" )
    {
        Console.Write( $"💥 {attackerName} {actionVerb} {opponent.Name} {weaponOrAbility} for ");
        Ui.TextColor(Ui.DangerColor);
        Console.Write(damage);
        Ui.TextColor();
        Console.WriteLine(" damage!");
    }
}