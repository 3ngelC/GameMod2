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
        private readonly List<Item> _items;
        private int _countItems;

        public NPC(string name)
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

        public void IntroduceNPC(int level)
        {
            
        }

        public void AddItem(int level)
        {

        }
    }
}
