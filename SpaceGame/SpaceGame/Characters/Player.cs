using SpaceGame.Core;
using SpaceGame.Interfaces;
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
        private readonly string _description;
        private readonly Item[] _items;
        private int _countItems;

        public Player(string name, string description)
        {
            _name = name;
            _description = description;
            _items = new Item[20];
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
    }
}
