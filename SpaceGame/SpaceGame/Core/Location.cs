using SpaceGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Core
{
    public class Location
    {
        private readonly string _nameLocation;
        private readonly string _descriptionLocation;
        private readonly INPC _character;

        public Location (string name, string description, INPC character)
        {
            _nameLocation = name;
            _descriptionLocation = description;
            _character = character;
        }

        public string NameLocation 
        {  
            get { return _nameLocation; } 
        }

        public string DescriptionLocation
        {
            get { return _descriptionLocation; }
        }

        public INPC Character
        {
            get { return _character; }
        }
    }
}
