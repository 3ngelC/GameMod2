using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceGame.Core;
using Spectre.Console;
using static SpaceGame.Core.GameInfo;

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
            AnsiConsole.MarkupLine($"[green]{text}[/]\n\n");
        }

        public static void GetPrintLocationInfo(string text)
        {
            AnsiConsole.MarkupLine($"\n[green]-------------Location: {text}--------------------[/]\n");
            
        }

        public static string GetPlayerInfo()
        {
            var name = AnsiConsole.Ask<string>("What's your [green]name[/]?");
            AnsiConsole.MarkupLine($"Hello [green]{name}[/]!");

            return name;
        }

        public static string AskPlayer(string question)
        {
            return AnsiConsole.Ask<string>($"[yellow]{question}[/]");
        }

        public static void AnswerNPC(Item item)
        {            
            WaitingForPlayer();
            AnsiConsole.MarkupLine($"\n\n[magenta]You got the following item:[/][yellow] {item.ItemName}[/]\n[magenta]Description:[/][yellow] {item.ItemDescription}[/]\n[magenta]Item Type:[/][yellow] {item.ItemType}[/]\n");
        }

        public static string CreateDecisionPlayer(string title, params string[] options)
        {
            var decisionPlayer1 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title($"[green]\n\n{title}[/]")
                    .PageSize(10)
                    .AddChoices(options));

            return decisionPlayer1.ToString();
        }

        public static Table CreateTable(params string[] columns)
        {
            var table = new Table();
            table.AddColumns(columns);

            return table;
        }

        public static void AddItemsTable(Table table, List<Item> itemsAdd)
        {
            foreach (var item in itemsAdd)
            {
                if (item != null)
                {
                    table.AddRow(item.ItemName, item.ItemDescription, item.ItemType.ToString());
                }
            }
        }

        public static void Animation(string title)
        {
            AnsiConsole.Status()
                .Start(title, ctx =>
                {
                    ctx.Spinner(Spinner.Known.Star);
                    Thread.Sleep(3000);
                });
        }
    }
}
