using SpaceGame.AnsiConsoleGame;
using SpaceGame.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Core
{
    public class GameInfo
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
            Console.WriteLine(TextGame.gameTitle);
            AnsiConsoleG.WaitingForPlayer();

            var playerName = AnsiConsoleG.GetPlayerInfo();
            
            AnsiConsoleG.GetPrintGreenText(SpaceGame.Constants.TextGame.introGame1);
            AnsiConsoleG.WaitingForPlayer();
            AnsiConsoleG.GetPrintGreenText(SpaceGame.Constants.TextGame.introGame2);
            AnsiConsoleG.WaitingForPlayer();
            AnsiConsoleG.GetPrintGreenText($"{playerName}{SpaceGame.Constants.TextGame.introGame3}");

            return playerName;
        }

        public static InfoGame GetBossInfo(int level)
        {
            Dictionary<int, InfoGame> npcName = new Dictionary<int, InfoGame>
            {
                {1, new InfoGame(Constants.TextGame.npcName1, Constants.TextGame.npcDescription1)},
                {2, new InfoGame(Constants.TextGame.npcName1, Constants.TextGame.npcDescription1)},
                {3, new InfoGame(Constants.TextGame.npcName1, Constants.TextGame.npcDescription1)}                
            };

            return npcName[level];
        }

        public static string GetLocationInfo(int level)
        {
            Dictionary<int, string> locationName = new Dictionary<int, string>
            {
                {0, Constants.TextGame.location0 },
                {1, Constants.TextGame.location1 },
                {2, Constants.TextGame.location2 },
                {3, Constants.TextGame.location3 },
                {4, Constants.TextGame.location4 },
                {5, Constants.TextGame.location5 },
                {6, Constants.TextGame.location6 },
                {7, Constants.TextGame.location7 },
                {8, Constants.TextGame.location8 },
                {9, Constants.TextGame.location9 },
                {10, Constants.TextGame.location10 },
                {11, Constants.TextGame.location11 },
                {12, Constants.TextGame.location12 },
            };

            return locationName[level];
        }

        public static InfoGame GetItemInfo(int level)
        {
            Dictionary<int, InfoGame> itemInformation = new Dictionary<int, InfoGame>
            {
                {0,  new InfoGame(Constants.TextGame.itemName0, Constants.TextGame.itemDescription0)},
                {1,  new InfoGame(Constants.TextGame.itemName1, Constants.TextGame.itemDescription1)},
                {2,  new InfoGame(Constants.TextGame.itemName2, Constants.TextGame.itemDescription2)},
                {3,  new InfoGame(Constants.TextGame.itemName3, Constants.TextGame.itemDescription3)},
                {4,  new InfoGame(Constants.TextGame.itemName4, Constants.TextGame.itemDescription4)},
                {5,  new InfoGame(Constants.TextGame.itemName5, Constants.TextGame.itemDescription5)},
                {6,  new InfoGame(Constants.TextGame.itemName6, Constants.TextGame.itemDescription6)},
            };

            return itemInformation[level];
        }

        public static InfoGame GetQuestions(int level)
        {
            Dictionary<int, InfoGame> questions = new Dictionary<int, InfoGame>
            {
                {0, new InfoGame(Constants.TextGame.question0, Constants.TextGame.answer0)},
                {1, new InfoGame(Constants.TextGame.question1, Constants.TextGame.answer1)},
                {2, new InfoGame(Constants.TextGame.question2, Constants.TextGame.answer2)},
                {3, new InfoGame(Constants.TextGame.question3, Constants.TextGame.answer3)},
                {4, new InfoGame(Constants.TextGame.question4, Constants.TextGame.answer4)},
                {5, new InfoGame(Constants.TextGame.question5, Constants.TextGame.answer5)},
                {6, new InfoGame(Constants.TextGame.question6, Constants.TextGame.answer6)},
                {9, new InfoGame(Constants.TextGame.question9, Constants.TextGame.answer9)},
                {10, new InfoGame(Constants.TextGame.question10, Constants.TextGame.answer10)},                
            };

            return questions[level];
        }

        public static List<string> LevelsAvailable(int level)
        {
            Dictionary<int, List<string>> levelsAvailable = new Dictionary<int, List<string>>
            {
                {0, new List<string>{ Constants.TextGame.location1, Constants.TextGame.location2} },
                {1, new List<string>{ Constants.TextGame.location3, Constants.TextGame.location5} },
                {2, new List<string>{ Constants.TextGame.location4, Constants.TextGame.location6} },
                {3, new List<string>{ Constants.TextGame.location7} },
                {5, new List<string>{ Constants.TextGame.location7} },
                {4, new List<string>{ Constants.TextGame.location8} },
                {6, new List<string>{ Constants.TextGame.location8} },
                {7, new List<string>{ Constants.TextGame.location9} },
                {8, new List<string>{ Constants.TextGame.location10} },
                {9, new List<string>{ Constants.TextGame.location11, Constants.TextGame.location12} },
                {10, new List<string>{ Constants.TextGame.location12} },
            };

            return levelsAvailable[level];
        }

        public static Dictionary<int, string> GetAllLevels()
        {
            Dictionary<int, string> locationName = new Dictionary<int, string>
            {
                {0, Constants.TextGame.location0 },
                {1, Constants.TextGame.location1 },
                {2, Constants.TextGame.location2 },
                {3, Constants.TextGame.location3 },
                {4, Constants.TextGame.location4 },
                {5, Constants.TextGame.location5 },
                {6, Constants.TextGame.location6 },
                {7, Constants.TextGame.location7 },
                {8, Constants.TextGame.location8 },
                {9, Constants.TextGame.location9 },
                {10, Constants.TextGame.location10 },
                {11, Constants.TextGame.location11 },
                {12, Constants.TextGame.location12 },
            };

            return locationName;
        }
    }
}
