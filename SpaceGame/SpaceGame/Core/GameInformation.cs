using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Core;

public class GameInformation
{
    public struct InfoGame
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public InfoGame(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
