public class FCLI
{
    public static readonly Dictionary<string, (string description, Action<string> handler)> commands = new()
    {
        ["help"] = ("Lists all commands", HelpCommand.Handler),
        ["exit"] = ("Exit the CLI app", ExitCommand.Handler),
        ["echo"] = ("Echo a message you provide", EchoCommand.Handler)
    };

    private static void Main()
    {
        HelpCommand.Handler(string.Empty);

        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (input == null) continue;

            var parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            var command = parts[0];
            var args = parts.Length > 1 ? parts[1] : string.Empty;

            if (commands.TryGetValue(command.ToLower(), out var cmd)) cmd.handler(args);
            else Console.WriteLine("Command doesn't exist! Run command \"help\" to get a list of commands.");
        }
    }
}