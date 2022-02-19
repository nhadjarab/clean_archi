using SalesReporterKata;
using static SalesReporterKata.Constants;


public static class Program
{
	
	private static void StartProgram()
	{	
		//add a title to our app
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
		var sales = parser.GenerateSalesList();

		if (command == Commands.print.ToString())  
		{  
			ICommand print = new PrintCommand(sales);
			print.Execute();
		} 
		else if (command == Commands.report.ToString())  
		{  
		 //get all the lines without the header in the first line  
		 var dataLines = parser.DataLines();  
			 //declare variables for our conters  
			 int numberOfSales = 0, totalItemsSold = 0;  
			 double averageAmountPerSale = 0.0, averageItemPrice = 0.0, totalSalesAmount = 0;  
			 HashSet<string> clients = new HashSet<string>();  
			 DateTime last = DateTime.MinValue;  
			 //do the counts for each line  
			 foreach (var line in dataLines)  
			 { //get the cell values for the line  
	 			var columns = line.Split(',');  
	 			numberOfSales++;//increment the total of sales  
	 			//to count the number of clients, we put only distinct names in a hashset //then we'll count the number of entries if (!clients.Contains(cells[1])) clients.Add(cells[1]);  
	 			totalItemsSold += int.Parse(columns[2]);//we sum the total of items sold here  
	 			totalSalesAmount += double.Parse(columns[3]);//we sum the amount of each sell  
	 			//we compare the current cell date with the stored one and pick the higher last = DateTime.Parse(cells[4]) > last ? DateTime.Parse(cells[4]) : last;  
			 } 
			 //we compute the average basket amount per sale  
			 averageAmountPerSale = Math.Round(totalSalesAmount / numberOfSales,2);  
			 //we compute the average item price sold  
			 averageItemPrice = Math.Round(totalSalesAmount / totalItemsSold,2);  
			 Console.WriteLine($"+{new String('-',45)}+");
			 Console.WriteLine($"| {NUMBER_OF_SALES.PadLeft(30)} | {numberOfSales.ToString().PadLeft(10)} |");
			 Console.WriteLine($"| {NUMBER_OF_CLIENTS.PadLeft(30)} | {clients.Count.ToString().PadLeft(10)} |");
			 Console.WriteLine($"| {TOTAL_ITEMS_SOLD.PadLeft(30)} | {totalItemsSold.ToString().PadLeft(10)} |");
			 Console.WriteLine($"| {TOTAL_SALES_AMOUNT.PadLeft(30)} | {Math.Round(totalSalesAmount,2).ToString().PadLeft(10)} |");
			 Console.WriteLine($"| {AVERAGE_AMOUNT_PER_SALE.PadLeft(30)} | {averageAmountPerSale.ToString().PadLeft(10)} |");
			 Console.WriteLine($"| {AVERAGE_ITEM_PRICE.PadLeft(30)} | {averageItemPrice.ToString().PadLeft(10)} |");
			 Console.WriteLine($"+{new String('-',45)}+");
		}  
		else
		{
			ICommand help = new WrongOrMissingCommand(HELP_MESSAGE);
			help.Execute();
		}
	}

	
}
