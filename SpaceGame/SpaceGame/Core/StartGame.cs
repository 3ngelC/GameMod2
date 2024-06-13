namespace SpaceGame.Core;

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
