using Spectre.Console;

var banner = new FigletText("RELEASE v2.0")
{
    Color = Color.Green,
    Justification = Justify.Center
};

AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("green dim")));
AnsiConsole.Write(banner);
AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("green dim")));