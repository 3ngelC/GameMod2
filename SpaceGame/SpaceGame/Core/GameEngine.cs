using SpaceGame.AnsiConsoleGame;
using SpaceGame.Characters;
using SpaceGame.Constants;
using SpaceGame.Enums;
using SpaceGame.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpaceGame.Core.GameInfo;

namespace SpaceGame.Core
{
    public class GameEngine
    {
        private readonly List<Location> _locations;
        private readonly List<INPC> _npcs;
        private readonly List<Types> _bossWeakness;
        private readonly List<Item> _items;
        private readonly Player _player1;
        private int _countLocations;
        private int _countBoss;

        public GameEngine(string name)
        {
            _locations = [];
            _npcs = [];
            _bossWeakness = [];
            _items = new List<Item>();
            _player1 = new Player(name);
            _countLocations = 0;
            _countBoss = 0;
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

        public int CountLocations
        {
            get { return _countLocations; }
        }
         
        public INPC GetNPCbyLevel(int level)
        {
            int npcPosition = 0;

            if (level == 7)
            {
                npcPosition = 1;
            }
            if (level == 8)
            {
                npcPosition = 2;
            }
            if (level == 12)
            {
                npcPosition = 3;
            }

            return _npcs[npcPosition];
        }

        public void AddLocation()
        {
            Enumerable.Range(0, 13).ToList().ForEach(i =>
            {
                INPC npc = GetNPCbyLevel(i);
                var location = GameInfo.GetLocationInfo(i);

                _locations.Add(new Location(location, npc));
            });            
        }

        public void CreateNPC()
        {         
            _npcs.Add(new NPC(TextGame.npcName0));                        
        }

        public void CreateBoss()
        {
            Enumerable.Range(1, 3).ToList().ForEach(i =>
            {
                var npcInfo = GameInfo.GetBossInfo(i);

                _npcs.Add(new BossNPC(npcInfo.Name, npcInfo.Description));
            });
        }

        public void DisplayLocation(int level)
        {
            string locationInfo = _locations[level].NameLocation;
            AnsiConsoleG.GetPrintLocationInfo(locationInfo);
        }

        public void CreateItems()
        {
            Enumerable.Range(0, 7).ToList().ForEach(i =>
            {
                var ItemInfo = GameInfo.GetItemInfo(i);

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
            if (level == 7 || level == 8 || level == 12)
            {
                return 0;
            }
            else
            {
                return IteractionNPC(level);
            }
        }

        private int IteractionNPC(int level)
        {
            InfoGame question = GameInfo.GetQuestions(level);
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

        
    }
}
