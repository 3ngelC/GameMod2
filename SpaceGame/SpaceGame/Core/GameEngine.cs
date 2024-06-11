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

        public GameEngine(string name, string description)
        {
            _locations = [];
            _npcs = [];
            _bossWeakness = [];
            _items = new List<Item>();
            _player1 = new Player(name, description);            
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
            Enumerable.Range(0, 14).ToList().ForEach(i =>
            {
                INPC npc = GetNPCbyLevel(i);
                var location = GameInfo.GetLocationInfo(i);

                _locations.Add(new Location(location, npc));
            });            
        }

        public void CreateNPC()
        {         
            _npcs.Add(new NPC(TextGame.npcName0, TextGame.npcDescription0));                        
        }

        public void CreateBoss()
        {
            Enumerable.Range(1, 3).ToList().ForEach(i =>
            {
                var npcInfo = GameInfo.GetBossInfo(i);

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
                //BossNPC boss = _npcs[level];
                AnsiConsoleG.GetBossDescription(_locations[level], _locations[level].Character);
            }
            else if (_locations[level].Character is NPC) 
            {
                AnsiConsoleG.GetNPCInstruction();
            }
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
                return IteractionBoss(level);
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
            Dictionary<int, string> levels = GameInfo.GetBossNumber();

            return levels.FirstOrDefault(x => x.Value == bossName).Key;
        }


    }
}
