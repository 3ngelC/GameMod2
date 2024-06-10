using SpaceGame.Constants;
using SpaceGame.Core;
using Spectre.Console;
//using static SpaceGame.Constants;
//using SpaceGame.AnsiConsoleGame;

namespace SpaceGame
{
    using SpaceGame.AnsiConsoleGame;
    using SpaceGame.Characters;

    public class Program
    {
        static void Main(string[] args)
        {
            var player = GameInfo.GameIntroduction();
            var startGame = new GameEngine(player);
            int level = 0;
            startGame.StartGameNPCandItems();

            while (level <= 12)
            {                
                startGame.DisplayLocation(level);
                level = startGame.IteractionPlayerWithNPC(level);                
            }


        }
    }
}
