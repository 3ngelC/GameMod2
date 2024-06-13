namespace SpaceGame.AnsiConsoleGame;

using SpaceGame.Constants;
using SpaceGame.Core;
using SpaceGame.Interfaces;
using Spectre.Console;

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

    public static void GetBossDescription(Location locationInfo, INPC boss)
    {
        AnsiConsole.MarkupLine($"\n[green]-------------Location: {locationInfo.NameLocation}--------------------[/]\n");
        AnsiConsole.MarkupLine($"Name:[blue] {boss.Name}[/]\n");
        AnsiConsole.MarkupLine($"[cyan]Description: {boss.Description}[/]\n\n\n");
    }

    public static void GetNPCInstruction(Location locationInfo)
    {
        AnsiConsole.MarkupLine($"\n[green]-------------Location: {locationInfo.NameLocation}--------------------[/]\n");
        AnsiConsole.MarkupLine($"\n[green]it would be best if you had the answer to the following question...[/]\n");
    }

    public static string GetPlayerInfo()
    {
        var name = AnsiConsole.Ask<string>("What's your [green]name[/]?");
        AnsiConsole.Clear();
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

    public static void CheckVictory(bool checkItem)
    {
        AnsiConsole.Clear();
        Animation("Fighting...");

        if (checkItem)
        {
            AnsiConsole.MarkupLine("[yellow] You defeated the Alien[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]\nYOU LOSE\nGAME OVER[/]");
            Environment.Exit(0);
        }
    }

    public static void GetFinalDescription()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine($"[green]{TextGame.finalDescription}[/]");
        WaitingForPlayer();
        AnsiConsole.WriteLine(TextGame.finalMessage);
    }
}
