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
        private readonly INPC _character;

        public Location (string name, INPC character)
        {
            _nameLocation = name;            
            _character = character;
        }

        public string NameLocation 
        {  
            get { return _nameLocation; } 
        }        

        public INPC Character
        {
            get { return _character; }
        }        
    }
}
