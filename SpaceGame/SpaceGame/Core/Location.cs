namespace SpaceGame.Core;

using SpaceGame.Interfaces;

public class Location
{
    private readonly string _nameLocation;        
    private readonly INPC _character;

    public Location (string name, INPC character)
    {
        _nameLocation = name;            
        _character = character;
    }

    public string NameLocation 
    {  
        get { return _nameLocation; } 
    }        

    public INPC Character
    {
        get { return _character; }
    }        
}
