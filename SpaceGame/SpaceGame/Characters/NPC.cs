namespace SpaceGame.Characters;

using SpaceGame.Interfaces;

public class NPC : INPC
{
    private readonly string _name;
    private readonly string _description;            

    public NPC(string name, string description)
    {
        _name = name;
        _description = description;                    
    }

    public string Name
    {
        get { return _name; }
    }

    public string Description
    {
        get { return _description; }
    }                    
}
