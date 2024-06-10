using SpaceGame.Core;
using SpaceGame.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Characters
{
    public class Player : ICharacter
    {
        private readonly string _name;        
        private readonly List<Item> _items;
        private int _countItems;

        public Player(string name)
        {
            _name = name;            
            _items = [];
            _countItems = 0;
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
            string title = "Where do you want to go?";
            List<string> options = GameInfo.LevelsAvailable(level);

            string decision = AnsiConsoleGame.AnsiConsoleG.CreateDecisionPlayer(title, options.ToArray());

            return GetLevelSelected(decision);           
        }

        private int GetLevelSelected(string decision)
        {
            Dictionary<int, string> levels = GameInfo.GetAllLevels();

            return levels.FirstOrDefault(x => x.Value == decision).Key;
        }
    }
}
