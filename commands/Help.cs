class HelpCommand
{
    public static void Handler(string _)
    {
        foreach (var command in FCLI.commands) Console.WriteLine($"{command.Key} - {command.Value.description}");
    }
}