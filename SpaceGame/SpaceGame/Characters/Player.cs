namespace SpaceGame.Characters;

using SpaceGame.AnsiConsoleGame;
using SpaceGame.Core;
using SpaceGame.Enums;
using SpaceGame.Interfaces;
using Spectre.Console;

public class Player : ICharacter
{
    private readonly string _name;        
    private readonly List<Item> _items;       

    public Player(string name)
    {
        _name = name;
        _items = [];            
    }

    public string Name
    {
        get { return _name; }
    }              

    public List<Item> Items
    {
        get { return _items; }
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void GetPlayerDecisions()
    {
        bool next = false;

        do
        {
            string decisionPlayer1 = PromptPlayerAction();

            Dictionary<string, Action> action = new Dictionary<string, Action>
            {
                {"Display Name",() => DisplayName()},                    
                {"Display Items", () => DisplayItems()},
                {"Continue", () => {AnsiConsoleGame.AnsiConsoleG.Animation("Walking..."); next = true; } }
            };

            action[decisionPlayer1]();

        } while (!next);
    }

    public string PromptPlayerAction()
    {
        return AnsiConsoleGame.AnsiConsoleG.CreateDecisionPlayer("Player information", "Display Name", "Display Items", "Continue");
    }

    public void DisplayName()
    {
        AnsiConsole.WriteLine("\nName:" + Name);
    }

    public void DisplayItems()
    {
        AnsiConsole.WriteLine("\nItems:");

        var table = AnsiConsoleGame.AnsiConsoleG.CreateTable("Item", "Description", "Type");

        AnsiConsoleGame.AnsiConsoleG.AddItemsTable(table, _items);
        AnsiConsole.Write(table);
    }

    public int GetLevelDecisionPlayer(int level)
    {            
        string title = "There is the following path(s) in front of you\n\nWhere do you want to go?";
        List<string> options = GameData.LevelsAvailable(level);

        string decision = AnsiConsoleGame.AnsiConsoleG.CreateDecisionPlayer(title, options.ToArray());

        return GetLevelSelected(decision);           
    }

    private int GetLevelSelected(string decision)
    {
        Dictionary<int, string> levels = GameData.GetAllLevels();

        return levels.FirstOrDefault(x => x.Value == decision).Key;
    }

    public List<string> SelectItemsPlayer()
    {
        AnsiConsole.MarkupLine("[yellow]There is an Alien in fron of you[/]");

        string[] itemOptions = GetItemNamePlayer();

        GetPlayerDecisions();

        if (itemOptions.Length == 0)
        {
            AnsiConsole.MarkupLine("[yellow]There isn't items to select...[/]");
            AnsiConsoleG.WaitingForPlayer();
            AnsiConsoleG.CheckVictory(false);
        }            
        
        var seleccion = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
             .Title("\n\n\n\nSelect items to fight:")
                .PageSize(10)
                .AddChoices(itemOptions));

        AnsiConsole.WriteLine("\nYou selected the following items");
        foreach (var item in seleccion)
        {
            AnsiConsole.WriteLine(item);
        }
        return seleccion;
    }

    public string[] GetItemNamePlayer()
    {
        return _items
                .Where(item => item != null && item.ItemName != null)
                .Select(item => item.ItemName)
                .ToArray();
    }

    public List<Types> ChekingItemsType(List<string> itemsSelected)
    {
        var itemTypesSelected = from item in _items
                                where item != null && item.ItemName != null
                                join itemNames in itemsSelected
                                on item.ItemName equals itemNames
                                select item.ItemType;

        return itemTypesSelected.ToList();
    }
}
