namespace SalesReporterKata;

public class PrintCommand: ICommand
{
    private string HeaderTitle;
     private List<SaleDTO> _salesList;
     private string rawData;

     public PrintCommand(List<SaleDTO> salesList)
     {
         _salesList = salesList;
     }
     
     private string LineSeparator()
     {
         return "+" + new String('-', HeaderTitle.Length + 2) + "+\n";
     }
     private string DisplayHeader()
     {
         HeaderTitle = String.Join(
             " | ",
             _salesList[0].HeaderItems.Select(val => val.PadLeft(16)));
         rawData += LineSeparator();
         rawData += "| " + HeaderTitle + " |\n";
         rawData += LineSeparator();
         return rawData;
     }

     private string ExtractData()
     {     
         var tableLines = "";
         foreach (var line in _salesList)
         {
             var tableLine = String.Join(
                 " | ",
                 line.GetValues().Select(
                     (val) => val.PadLeft(16)));
             tableLines += $"| {tableLine} |\n";
         }

         return tableLines;
     }
     public void Execute()
     {
         rawData += DisplayHeader();
         rawData += ExtractData();
         rawData += LineSeparator();

         Console.Write(rawData);
     }
    
}