using SpaceGame.Constants;

namespace SpaceGame.Core;

public class StartGame
{
    public static void StartSpaceGame()
    {
        var player = GameData.GameIntroduction();
        var startGame = new GameEngine(player);        
        startGame.StartGameNPCandItems();
        bool runningGame = true;
        int level = Constants.NumberGameComponents.startLevel;

        while (runningGame)
        {
            startGame.DisplayLocation(level);
            level = startGame.IteractionPlayerWithNPC(level);
            if (level == Constants.NumberGameComponents.endLevel)
            {
                AnsiConsoleGame.AnsiConsoleG.GetFinalDescription();
                runningGame = false;
            }
        }
    }    
}
