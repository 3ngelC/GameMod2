using SpaceGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Core
{
    public class Item
    {
        private readonly string _itemName;
        private readonly string _itemDescription;
        private readonly Types _itemType;

        public Item(string itemName, string itemDescription, Types itemType)
        {
            _itemName = itemName;
            _itemDescription = itemDescription;
            _itemType = itemType;
        }

        public string ItemName
        {
            get { return _itemName; }
        }

        public string ItemDescription
        {
            get { return _itemDescription; }
        }

        public Types ItemType
        {
            get { return _itemType; }
        }
    }
}
