using System.Globalization;

namespace SalesReporterKata;

public class SaleDTO
{
    public string OrderId { get; set; }
    public string UserName { get; set; }
    public int NumberOfItems { get; set; }
    public double TotalOfBasket { get; set; }
    public DateOnly DateOfBuy { get; set; }
    
    public List<string> HeaderItems { get; }

    public List<string> GetValues()
    {
        return new List<string> 
        {
                                OrderId,
                                UserName,
                                NumberOfItems.ToString(),
                                TotalOfBasket.ToString("F"),
                                DateOfBuy.ToString("yyyy-MM-dd")
                                
        };
    }
    
    public SaleDTO()
    {
        HeaderItems = new List<string> {"orderid", "userName", "numberOfItems", "totalOfBasket", "dateOfBuy"};
    }

    public SaleDTO(string orderId, string userName, int numberOfItems, double totalOfBasket, DateOnly dateOfBuy) : this()
    {
        OrderId = orderId;
        UserName = userName;
        NumberOfItems = numberOfItems;
        TotalOfBasket = totalOfBasket;
        DateOfBuy = dateOfBuy;
    }
}