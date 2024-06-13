namespace SpaceGame.Characters;

using SpaceGame.Core;
using SpaceGame.Interfaces;

public class NPC : INPC
{
    private readonly string _name;
    private readonly string _description;
    private readonly List<Item> _items;        

    public NPC(string name, string description)
    {
        _name = name;
        _description = description;
        _items = [];            
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
}
