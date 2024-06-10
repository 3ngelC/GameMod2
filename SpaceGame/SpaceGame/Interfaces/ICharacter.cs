using SpaceGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Interfaces
{
    public interface ICharacter
    {
        string Name { get; }        
        List<Item> Items { get; }
    }
}
