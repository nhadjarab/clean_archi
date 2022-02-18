using System;
using System.IO;
using NFluent;
using Xunit;
using exam_sales_reporter_kata.Cli;
namespace exam_sales_reporter_kata.Tests;

public class Tests
{
    [Fact]
    public void SampleData_on_print_command()
    {
        using var writer = new StringWriter();
        Console.SetOut(writer);
        Console.SetError(writer);
        Program.Main(new string[]{"print","./../../../Data/data.csv"});
        var sut = writer.ToString();
        Check.That(sut).IsEqualTo(
            @$"=== Sales Viewer ===
+----------------------------------------------------------------------------------------------+
|          orderid |         userName |    numberOfItems |    totalOfBasket |        dateOfBuy |
+----------------------------------------------------------------------------------------------+
|                1 |            peter |                3 |           123.00 |       2021-11-30 |
|                2 |             paul |                1 |           433.50 |       2021-12-11 |
|                3 |            peter |                1 |           329.99 |       2021-12-18 |
|                4 |             john |                5 |           467.35 |       2021-12-30 |
|                5 |             john |                1 |            88.00 |       2022-01-04 |
+----------------------------------------------------------------------------------------------+
"
        );
    }
    
    [Fact]
    public void SampleData_on_report_command()
    {
        using var writer = new StringWriter();
        Console.SetOut(writer);
        Console.SetError(writer);
        Program.Main(new string[]{"report","./../../../Data/data.csv"});
        var sut = writer.ToString();
        Check.That(sut).IsEqualTo(
            @$"=== Sales Viewer ===
+---------------------------------------------+
|                Number of sales |          5 |
|              Number of clients |          0 |
|               Total items sold |         11 |
|             Total sales amount |    1441.84 |
|            Average amount/sale |     288.37 |
|             Average item price |     131.08 |
+---------------------------------------------+
"
        );
    } 
}