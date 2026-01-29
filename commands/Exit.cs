class ExitCommand
{
    public static void Handler(string _)
    {
        Console.WriteLine("Bye!");
        Environment.Exit(0);
    }
}