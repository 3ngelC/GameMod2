namespace SpaceGame.Characters;

using SpaceGame.Enums;
using SpaceGame.Interfaces;

public class BossNPC : INPC
{
    private readonly string _name;
    private readonly string _description;           
    private readonly Types _weakness;

    public BossNPC(string name, string description, Types weakness)
    {
        _name = name;
        _description = description;        
        _weakness = weakness;            
    }

    public string Name 
    { 
        get { return _name; } 
    }

    public string Description
    {
        get { return _description; }
    }

    public Types Weakness
    {
        get { return _weakness; }
    }                
}
