namespace nightfall_hunters.classes;

public class Pronouns
{
    // Idea refined together with ChatGPT
    public Gender Gender { get; init; }

    public string PronounSubject => Gender switch
    {
        Gender.Male => "He",
        Gender.Female => "She",
        _ => "They"
    };

    public string PronounObject => Gender switch
    {
        Gender.Male => "him",
        Gender.Female => "her",
        _ => "them"
    };

    public string PronounPossessive => Gender switch
    {
        Gender.Male => "his",
        Gender.Female => "her",
        _ => "their"
    };
}