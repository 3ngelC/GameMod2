namespace SpaceGame.Core;

using SpaceGame.AnsiConsoleGame;
using SpaceGame.Characters;
using SpaceGame.Constants;
using SpaceGame.Enums;
using SpaceGame.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using static SpaceGame.Core.GameData;

public class GameEngine
{
    private readonly List<Location> _locations;
    private readonly List<INPC> _npcs;
    private readonly List<Types> _bossWeakness;
    private readonly List<Item> _items;
    private readonly Player _player1;        

    public GameEngine(string name)
    {
        _locations = [];
        _npcs = [];
        _bossWeakness = [];
        _items = new List<Item>();
        _player1 = new Player(name);            
    }

    public List<Location> Locations
    {
        get { return _locations; }
    }

    public List<INPC> NPCs 
    { 
        get { return _npcs; } 
    }

    public List<Item> Items 
    { 
        get { return _items; } 
    }

    public Player Player1
    {
        get { return _player1; }
    }        
     
    public INPC GetNPCbyLevel(int level)
    {
        var positions = GameData.GetNPCPositionbyLevel();
        
        int NPCPositionByLevel(int level)
        {
            if (positions.TryGetValue(level, out var position))
            {
                return position;
            }
            else
            {
                return positions[0];
            }
        }        

        return _npcs[NPCPositionByLevel(level)];
    }

    public void AddLocation()
    {
        Enumerable.Range(0, Constants.NumberGameComponents.numberOfLocations).ToList().ForEach(i =>
        {
            INPC npc = GetNPCbyLevel(i);
            var location = GameData.GetLocationInfo(i);

            _locations.Add(new Location(location, npc));
        });            
    }

    public void CreateNPC()
    {         
        _npcs.Add(new NPC(NPCData.npcName0, NPCData.npcDescription0));                        
    }

    public void CreateBoss()
    {
        Enumerable.Range(Constants.NumberGameComponents.startPositionNPCBoss, Constants.NumberGameComponents.numberOfBoss).ToList().ForEach(i =>
        {
            var npcInfo = GameData.GetBossInfo(i);

            _npcs.Add(new BossNPC(npcInfo.Name, npcInfo.Description, Types.Weapon));
            _bossWeakness.Add(Types.Weapon);                
        });
    }

    public void DisplayLocation(int level)
    {
        string locationInfo = _locations[level].NameLocation;
        AnsiConsoleG.GetPrintLocationInfo(locationInfo);
        AnsiConsole.Clear();
        NPCIntroduction(level);
    }

    public void NPCIntroduction(int level)
    {
        if (_locations[level].Character is BossNPC)
        {
            AnsiConsoleG.GetBossDescription(_locations[level], _locations[level].Character);
        }
        else if (_locations[level].Character is NPC) 
        {
            AnsiConsoleG.GetNPCInstruction(_locations[level]);
        }
    }

    public void CreateItems()
    {
        Enumerable.Range(0, Constants.NumberGameComponents.numberOfItems).ToList().ForEach(i =>
        {
            var ItemInfo = GameData.GetItemInfo(i);

            _items.Add(new Item(ItemInfo.Name, ItemInfo.Description, Types.Weapon));
        });
    }

    public void StartGameNPCandItems()
    {
        CreateNPC();
        CreateBoss();
        CreateItems();
        AddLocation();
    }

    public int IteractionPlayerWithNPC(int level)
    {
        if (_locations[level].Character is BossNPC)
        {
            return IteractionBoss(level);
        }
        else
        {
            return IteractionNPC(level);
        }
    }

    private int IteractionNPC(int level)
    {
        InfoGame question = GameData.GetQuestions(level);
        string ask = AnsiConsoleG.AskPlayer(question.Name);
        CheckAnswer(ask, question.Description, level);
        Player1.GetPlayerDecisions();
        AnsiConsole.Clear();

        return Player1.GetLevelDecisionPlayer(level);            
    }

    private void CheckAnswer(string answerPlayer, string correctAnswer, int level)
    {
        if (answerPlayer.ToLower().Contains(correctAnswer.ToLower()))
        {
            _player1.AddItem(_items[level]);
            AnsiConsoleG.AnswerNPC(_items[level]);
        }
    }

    public int IteractionBoss(int level)
    {
        List<string> itemSelected = _player1.SelectItemsPlayer();
        List<Types> itemsTypesSelected = _player1.ChekingItemsType(itemSelected);
        FightingWithBoss(level, itemsTypesSelected);
        Player1.GetPlayerDecisions();
        AnsiConsole.Clear();

        return Player1.GetLevelDecisionPlayer(level);
    }

    private void FightingWithBoss(int level, List<Types> itemsTypeSelected)
    {
        var boss = GetNPCbyLevel(level);            
        int bossNumber = GetBossNumber(boss.Name);
        var bossWeakness = _bossWeakness[bossNumber];
        bool checkItem = false;

        foreach (var item in itemsTypeSelected)
        {
            if (bossWeakness == item)
            {
                checkItem = true;
                break;
            }
        }
        AnsiConsoleG.CheckVictory(checkItem);
    }

    private int GetBossNumber(string bossName)
    {
        Dictionary<int, string> levels = GameData.GetBossNumber();

        return levels.FirstOrDefault(x => x.Value == bossName).Key;
    }
}
