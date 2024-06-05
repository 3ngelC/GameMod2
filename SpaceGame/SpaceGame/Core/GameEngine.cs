using SpaceGame.Characters;
using SpaceGame.Constants;
using SpaceGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Core
{
    public class GameEngine
    {
        private readonly Location[] _locations;
        private readonly Types[] _bossWeakness;
        private readonly Player _player1;
        private int _countLocations;
        private int _countBoss;

        public GameEngine()
        {
            _locations = new Location[12];
            _bossWeakness = new Types[3];
            _player1 = new Player("John", "test");
            _countLocations = 0;
            _countBoss = 0;
        }

        public Location[] Locations
        {
            get { return _locations; }
        }

        public Player Player1
        {
            get { return _player1; }
        }

        public int CountLocations
        {
            get { return _countLocations; }
        }

        public void GetIntroductionGame()
        {
            Console.WriteLine(TextGame.gameTitle);
            AnsiConsoleGame.WaitingForPlayer();
            AnsiConsoleGame.GetPrintGreenText(SpaceGame.Constants.TextGame.introGame1);
            AnsiConsoleGame.WaitingForPlayer();
            AnsiConsoleGame.GetPrintGreenText(SpaceGame.Constants.TextGame.introGame2);
            AnsiConsoleGame.WaitingForPlayer();
            AnsiConsoleGame.GetPrintGreenText(SpaceGame.Constants.TextGame.introGame3);
        }
    }
}
