using SpaceGame.Core;
using SpaceGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Characters
{
    internal class BossNPC : INPC
    {
        private readonly string _name;
        private readonly string _description;
        private readonly List<Item> _items;
        private readonly int _countItems;

        public BossNPC(string name, string description)
        {
            _name = name;
            _description = description;
            _items = [];
            _countItems = 0;
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

        public void IntroduceNPC(int locationID)
        {
            
        }

        public void AddItem(int locationID)
        {

        }
    }
}
