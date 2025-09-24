using nightfall_hunters.ui;

namespace nightfall_hunters.classes;

public abstract class Quest
{
    public string Name { get; }
    public StoryNode Description { get; }
    
    public bool IsCompleted { get; protected set;  }

    protected Quest(string name)
    {
        Name = name;
        IsCompleted = false;
        Description = StoryNode.GetNode(name);
    }

    public abstract void Start();

}