namespace SalesReporterKata;
using static SalesReporterKata.Constants;

public class ReportCommand : ICommand
{
    public List<SaleDTO> salesList;
    public SaleReport salesReport;
    public string rawData;
    
    public void Execute()
    {
        salesReport.NumberOfSales = salesList.Count();
        HashSet<string> clients = new HashSet<string>();
        foreach (var line in salesList)
        {
            clients.Add(line.UserName);
            salesReport.TotalItemsSold += line.NumberOfItems; 
            salesReport.TotalSalesAmount += line.TotalOfBasket;  
        }

        salesReport.NumberOfClients = clients.Count;
        salesReport.AverageAmountPerSale = Math.Round(salesReport.TotalSalesAmount / salesReport.NumberOfSales, 2);
        salesReport.AverageItemPrice = Math.Round(salesReport.TotalSalesAmount / salesReport.TotalItemsSold, 2);
        PrintSaleReport();
    }

    private void  PrintSaleReport()
    {
        rawData += $"+{new String('-', 45)}+"+ "\n";
        rawData += $"| {NUMBER_OF_SALES.PadLeft(30)} | {salesReport.NumberOfSales.ToString().PadLeft(10)} |"+ "\n";
        rawData += $"| {NUMBER_OF_CLIENTS.PadLeft(30)} | {salesReport.NumberOfClients.ToString().PadLeft(10)} |"+ "\n";
        rawData += $"| {TOTAL_ITEMS_SOLD.PadLeft(30)} | {salesReport.TotalItemsSold.ToString().PadLeft(10)} |"+ "\n";
        rawData +=
            $"| {TOTAL_SALES_AMOUNT.PadLeft(30)} | {Math.Round(salesReport.TotalSalesAmount, 2).ToString("F").PadLeft(10)} |"+ "\n";
        rawData += $"| {AVERAGE_AMOUNT_PER_SALE.PadLeft(30)} | {salesReport.AverageAmountPerSale.ToString("F").PadLeft(10)} |"+ "\n";
        rawData += $"| {AVERAGE_ITEM_PRICE.PadLeft(30)} | {salesReport.AverageItemPrice.ToString("F").PadLeft(10)} |"+ "\n";
        rawData += $"+{new String('-', 45)}+"+ "\n";
        
        Console.Write(rawData);
    }

    public ReportCommand(List<SaleDTO> sales)
    {
        salesList = sales;
        salesReport = new SaleReport();
    }
}