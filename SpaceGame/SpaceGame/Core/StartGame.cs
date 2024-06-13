namespace SpaceGame.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Timers;




public class StartGame
{
    public static void StartSpaceGame()
    {
        var player = GameInfo.GameIntroduction();
        var startGame = new GameEngine(player);
        int level = 0;
        startGame.StartGameNPCandItems();
        bool game = true;

        while (game)
        {
            startGame.DisplayLocation(level);
            level = startGame.IteractionPlayerWithNPC(level);
            if (level == 13)
            {
                AnsiConsoleGame.AnsiConsoleG.GetFinalDescription();
                game = false;
            }

        }
    }
    
}
