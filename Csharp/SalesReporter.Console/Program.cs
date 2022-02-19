using SalesReporterKata;
using static SalesReporterKata.Constants;


public static class Program
{
	
	private static void StartProgram()
	{
		Console.WriteLine(SALES_VIEWER);
	}
	
	private static string GetCommand(string[] args)
	{
		return args.Length > 0 ? args[0] : Commands.wrongOrMissingCommand.ToString();
	}
	
	private static string GetFile(string[] args)
	{
		return args.Length >= 2 ? args[1] : "./data.csv";
	}
	
	
	public static void Main(string[] args)
	{
		  
		StartProgram();
		var command = GetCommand(args); 
		var file = GetFile(args);
		CsvParser parser = new CsvParser(file);
		var salesList = parser.GenerateSalesList();

		if (command == Commands.print.ToString())  
		{  
			ICommand print = new PrintCommand(salesList);
			print.Execute();
		} 
		else if (command == Commands.report.ToString())
		{
			ICommand report = new ReportCommand(salesList);
			report.Execute();

		}  
		else
		{
			ICommand help = new WrongOrMissingCommand(HELP_MESSAGE);
			help.Execute();
		}
	}

	
}
