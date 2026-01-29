public class FCLI
{
    public static readonly Dictionary<string, (string description, Action handler)> commands = new()
    {
        ["help"] = ("Lists all commands", HelpCommand.Handler),
        ["exit"] = ("Exit the CLI app", ExitCommand.Handler)
    };

    private static void Main()
    {
        HelpCommand.Handler();

        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (input == null) continue;

            if (commands.TryGetValue(input.ToLower(), out var command)) command.handler();
            else Console.WriteLine("Command doesn't exist! Run command \"help\" to get a list of commands.");
        }
    }
}