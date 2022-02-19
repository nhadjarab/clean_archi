namespace SalesReporterKata;

public class CsvParser
{
    public string file;
    public string[] fileContentString;
    public static char DELIMITER = ',';

    public CsvParser(string file)
    {
        this.file = file;
        fileContentString = ReadAllLines();
    }

    public string[] ReadAllLines()
    {
        return File.ReadAllLines(file);
    }

    public IEnumerable<string> DataLines()
    {
        return fileContentString.Skip(1);
    }


    public List<SaleDTO> GenerateSalesList()
    {
        List<SaleDTO> salesList = new List<SaleDTO>();
        foreach (string line in fileContentString.Skip(1))
        {
            var column = line.Split(DELIMITER);
            SaleDTO saleItem = new SaleDTO(
                column[0]
                , column[1]
                , int.Parse(column[2])
                , double.Parse(column[3])
                , DateOnly.Parse(column[4])
            );
            salesList.Add(saleItem);
        }

        return salesList;
    }
}