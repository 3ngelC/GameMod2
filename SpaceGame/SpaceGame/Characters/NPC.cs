using SpaceGame.Core;
using SpaceGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Characters
{
    internal class NPC : INPC
    {
        private readonly string _name;
        private readonly string _description;
        private readonly Item[] _items;
        private int _countItems;

        public NPC(string name, string description, Item[] items, int countItems)
        {
            _name = name;
            _description = description;
            _items = new Item[5];
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

        public Item[] Items
        {
            get { return _items; }
        }

        public void IntroduceNPC(int level)
        {
            
        }

        public void AddItem(int level)
        {

        }
    }
}
