using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Interfaces
{
    public interface INPC : ICharacter
    {
        void IntroduceNPC(int locationID);
        void AddItem(int locationID);
    }
}
