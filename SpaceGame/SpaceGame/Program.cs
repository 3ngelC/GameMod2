using SpaceGame.Constants;
using SpaceGame.Core;
using Spectre.Console;
//using static SpaceGame.Constants;
//using SpaceGame.AnsiConsoleGame;

namespace SpaceGame
{
    using SpaceGame.AnsiConsoleGame;
    public class Program
    {
        static void Main(string[] args)
        {
           GameEngine game = new GameEngine();
           game.GetIntroductionGame();

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
