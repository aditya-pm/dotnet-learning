using Spectre.Console;

static class PanelTesting
{
    public static void BasicPanel()
    {
        var panel = new Panel("Hello, World");
        AnsiConsole.Write(panel);
    }

    public static void PanelWithHeaders()
    {
        var panel = new Panel("This Panel has a Header").Header("Information");
        AnsiConsole.Write(panel);

        // header alignment
        var left = new Panel("Left-aligned header")
            .Header("Left", Justify.Left);

        var center = new Panel("Center-aligned header")
            .Header("Center", Justify.Center);

        var right = new Panel("Right-aligned header")
            .Header("Right", Justify.Right);

        AnsiConsole.Write(left);
        AnsiConsole.Write(center);
        AnsiConsole.Write(right);
    }

    public static void PanelBorders()
    {
        var square = new Panel("Square border (default)")
            .SquareBorder();

        var rounded = new Panel("Rounded border")
            .RoundedBorder();

        var heavy = new Panel("Heavy border")
            .HeavyBorder();

        var doubleBorder = new Panel("Double border")
            .DoubleBorder();

        var noBorder = new Panel("Content without border")
            .NoBorder()
            .Header("Still has a header");

        AnsiConsole.Write(square);
        AnsiConsole.Write(rounded);
        AnsiConsole.Write(heavy);
        AnsiConsole.Write(doubleBorder);
        AnsiConsole.Write(noBorder);
    }

    public static void TableInPanel()
    {
        var table = new Table()
            .AddColumn("Name")
            .AddColumn("Status")
            .AddRow("Server 1", "[green]Online[/]")
            .AddRow("Server 2", "[red]Offline[/]");

        var panel = new Panel(table)
            .Header("Server Status")
            .BorderColor(Color.Blue);

        AnsiConsole.Write(panel);
    }

    public static void NestedPanels()
    {
        var inner = new Panel("Inner content")
            .Header("Inner")
            .RoundedBorder()
            .BorderColor(Color.Yellow);

        var outer = new Panel(inner)
            .Header("Outer")
            .DoubleBorder()
            .BorderColor(Color.Blue);

        AnsiConsole.Write(outer);
    }

    public static void FillsAvailableWidth()
    {
        var collapsed = new Panel("Fits content width");
  
        var expanded = new Panel("Fills available width")
            .Expand();
        
        AnsiConsole.Write(collapsed);
        AnsiConsole.Write(expanded);
    }

    public static void CombineMultipleOptions()
    {
        var panel = new Panel("[bold]Important Notice[/]\n\nThis message requires your attention.")
            .Header("[yellow]Warning[/]", Justify.Center)
            .RoundedBorder()
            .BorderColor(Color.Yellow)
            .Padding(2, 1)
            .Expand();
        
        AnsiConsole.Write(panel);
    }
}
