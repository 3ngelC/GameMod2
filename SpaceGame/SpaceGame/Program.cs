using SpaceGame.Constants;
using SpaceGame.Core;
using Spectre.Console;
using System;

namespace SpaceGame
{
    using SpaceGame.AnsiConsoleGame;
    using SpaceGame.Characters;

    public class Program
    {
        static void Main(string[] args)
        {
            var player = GameInfo.GameIntroduction();
            var startGame = new GameEngine(player.Name, player.Description);
            int level = 0;
            startGame.StartGameNPCandItems();
            bool game = true;

            while (game)
            {
                startGame.DisplayLocation(level);
                level = startGame.IteractionPlayerWithNPC(level);
                if (level == 13)
                {
                    AnsiConsoleG.GetFinalDescription();
                    game = false;
                }
            }
        }   
    }
}
