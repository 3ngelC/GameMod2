namespace SpaceGame.Characters;

using SpaceGame.Core;
using SpaceGame.Enums;
using SpaceGame.Interfaces;

public class BossNPC : INPC
{
    private readonly string _name;
    private readonly string _description;
    private readonly List<Item> _items;       
    private readonly Types _weakness;

    public BossNPC(string name, string description, Types weakness)
    {
        _name = name;
        _description = description;
        _items = [];
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

    public List<Item> Items
    {
        get { return _items; }
    }

    public Types Weakness
    {
        get { return _weakness; }
    }                
}
