namespace SpaceGame.Core;

using SpaceGame.AnsiConsoleGame;
using SpaceGame.Constants;


public class GameData
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

    public static string GameIntroduction()
    {
        Console.WriteLine(IntroductionGameData.gameTitle);
        AnsiConsoleG.WaitingForPlayer();

        var playerName = AnsiConsoleG.GetPlayerInfo();
        
        AnsiConsoleG.GetPrintGreenText(SpaceGame.Constants.IntroductionGameData.introGame1);
        AnsiConsoleG.WaitingForPlayer();
        AnsiConsoleG.GetPrintGreenText(SpaceGame.Constants.IntroductionGameData.introGame2);
        AnsiConsoleG.WaitingForPlayer();
        AnsiConsoleG.GetPrintGreenText($"{playerName}{SpaceGame.Constants.IntroductionGameData.introGame3}");
        AnsiConsoleG.WaitingForPlayer();

        return playerName;
    }

    public static InfoGame GetBossInfo(int level)
    {
        var npcName = new Dictionary<int, InfoGame>
        {
            {1, new InfoGame(Constants.NPCData.npcName1, Constants.NPCData.npcDescription1)},
            {2, new InfoGame(Constants.NPCData.npcName2, Constants.NPCData.npcDescription2)},
            {3, new InfoGame(Constants.NPCData.npcName3, Constants.NPCData.npcDescription3)}                
        };

        return npcName[level];
    }

    public static string GetLocationInfo(int level)
    {
        Dictionary<int, string> locationName = new Dictionary<int, string>
        {
            {0, Constants.LocationsData.location0 },
            {1, Constants.LocationsData.location1 },
            {2, Constants.LocationsData.location2 },
            {3, Constants.LocationsData.location3 },
            {4, Constants.LocationsData.location4 },
            {5, Constants.LocationsData.location5 },
            {6, Constants.LocationsData.location6 },
            {7, Constants.LocationsData.location7 },
            {8, Constants.LocationsData.location8 },
            {9, Constants.LocationsData.location9 },
            {10, Constants.LocationsData.location10 },
            {11, Constants.LocationsData.location11 },
            {12, Constants.LocationsData.location12 },
            {13, Constants.LocationsData.location13 },
        };

        return locationName[level];
    }

    public static InfoGame GetItemInfo(int level)
    {
        Dictionary<int, InfoGame> itemInformation = new Dictionary<int, InfoGame>
        {
            {0,  new InfoGame(Constants.ItemsData.itemName0, Constants.ItemsData.itemDescription0)},
            {1,  new InfoGame(Constants.ItemsData.itemName1, Constants.ItemsData.itemDescription1)},
            {2,  new InfoGame(Constants.ItemsData.itemName2, Constants.ItemsData.itemDescription2)},
            {3,  new InfoGame(Constants.ItemsData.itemName3, Constants.ItemsData.itemDescription3)},
            {4,  new InfoGame(Constants.ItemsData.itemName4, Constants.ItemsData.itemDescription4)},
            {5,  new InfoGame(Constants.ItemsData.itemName5, Constants.ItemsData.itemDescription5)},
            {6,  new InfoGame(Constants.ItemsData.itemName6, Constants.ItemsData.itemDescription6)},
        };

        return itemInformation[level];
    }

    public static InfoGame GetQuestions(int level)
    {
        Dictionary<int, InfoGame> questions = new Dictionary<int, InfoGame>
        {
            {0, new InfoGame(Constants.QuestionsNPC.question0, Constants.QuestionsNPC.answer0)},
            {1, new InfoGame(Constants.QuestionsNPC.question1, Constants.QuestionsNPC.answer1)},
            {2, new InfoGame(Constants.QuestionsNPC.question2, Constants.QuestionsNPC.answer2)},
            {3, new InfoGame(Constants.QuestionsNPC.question3, Constants.QuestionsNPC.answer3)},
            {4, new InfoGame(Constants.QuestionsNPC.question4, Constants.QuestionsNPC.answer4)},
            {5, new InfoGame(Constants.QuestionsNPC.question5, Constants.QuestionsNPC.answer5)},
            {6, new InfoGame(Constants.QuestionsNPC.question6, Constants.QuestionsNPC.answer6)},
            {9, new InfoGame(Constants.QuestionsNPC.question9, Constants.QuestionsNPC.answer9)},
            {10, new InfoGame(Constants.QuestionsNPC.question10, Constants.QuestionsNPC.answer10)},
            {11, new InfoGame(Constants.QuestionsNPC.question11, Constants.QuestionsNPC.answer11)},
        };

        return questions[level];
    }

    public static List<string> LevelsAvailable(int level)
    {
        Dictionary<int, List<string>> levelsAvailable = new Dictionary<int, List<string>>
        {
            {0, new List<string>{ Constants.LocationsData.location1, Constants.LocationsData.location2} },
            {1, new List<string>{ Constants.LocationsData.location3, Constants.LocationsData.location5} },
            {2, new List<string>{ Constants.LocationsData.location4, Constants.LocationsData.location6} },
            {3, new List<string>{ Constants.LocationsData.location7} },
            {5, new List<string>{ Constants.LocationsData.location7} },
            {4, new List<string>{ Constants.LocationsData.location8} },
            {6, new List<string>{ Constants.LocationsData.location8} },
            {7, new List<string>{ Constants.LocationsData.location2, Constants.LocationsData.location9} },
            {8, new List<string>{ Constants.LocationsData.location10} },
            {9, new List<string>{ Constants.LocationsData.location11, Constants.LocationsData.location12} },
            {10, new List<string>{ Constants.LocationsData.location12} },
            {11, new List<string>{ Constants.LocationsData.location13} },
            {12, new List<string>{ Constants.LocationsData.location13} },
        };

        return levelsAvailable[level];
    }

    public static Dictionary<int, string> GetAllLevels()
    {
        var locationName = new Dictionary<int, string>
        {
            {0, Constants.LocationsData.location0 },
            {1, Constants.LocationsData.location1 },
            {2, Constants.LocationsData.location2 },
            {3, Constants.LocationsData.location3 },
            {4, Constants.LocationsData.location4 },
            {5, Constants.LocationsData.location5 },
            {6, Constants.LocationsData.location6 },
            {7, Constants.LocationsData.location7 },
            {8, Constants.LocationsData.location8 },
            {9, Constants.LocationsData.location9 },
            {10, Constants.LocationsData.location10 },
            {11, Constants.LocationsData.location11 },
            {12, Constants.LocationsData.location12 },
            {13, Constants.LocationsData.location13 },
        };

        return locationName;
    }

    public static Dictionary<int, string> GetBossNumber()
    {
        var bossNumber = new Dictionary<int, string>
        {
            {0, Constants.NPCData.npcName1},
            {1, Constants.NPCData.npcName1},
            {2, Constants.NPCData.npcName1}
        };

        return bossNumber;
    }

    public static Dictionary <int, int> GetNPCPositionbyLevel()
    {
        var NPCbyLevel = new Dictionary<int, int>
        {
            {0, Constants.NumberGameComponents.NPCPosition },
            {7, Constants.NumberGameComponents.BossLevel7Position },
            {8, Constants.NumberGameComponents.BossLevel8Position },
            {12, Constants.NumberGameComponents.BossLevel12Position }
        };

        return NPCbyLevel;
    }
}
