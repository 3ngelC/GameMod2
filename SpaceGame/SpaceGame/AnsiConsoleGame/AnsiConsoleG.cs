using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace SpaceGame.AnsiConsoleGame
{
    public class AnsiConsoleG
    {
        public static void WaitingForPlayer()
        {
            AnsiConsole.MarkupLine("[blue]Press any button to continue...[/]");
            System.Console.CursorVisible = false;
            System.Console.ReadKey(true);
            System.Console.CursorVisible = true;
            AnsiConsole.Clear();
        }

        public static void GetPrintGreenText(string text)
        {
            AnsiConsole.MarkupLine($"[green]{text}[/]");
        }
    }
}
