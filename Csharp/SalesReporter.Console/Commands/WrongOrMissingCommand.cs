namespace SalesReporterKata;

public class WrongOrMissingCommand : ICommand
{
    public string HelpMessage;
    public void Execute()
    {
        Console.Write(HelpMessage);
    }

    public WrongOrMissingCommand(string helpMessage)
    {
        HelpMessage = helpMessage;
    }
}