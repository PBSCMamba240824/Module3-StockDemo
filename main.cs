using System;

// Base Stock class from classes.txt
public class Stock
{
    public decimal CurrentPrice { get; set; } = 123;
    public int SharesOwned { get; set; } = 100;
    public decimal Worth => CurrentPrice * SharesOwned;
    public virtual string GetStockType() => "Common Stock";
}

// Derived class using inheritance from inheritance.txt
public class PreferredStock : Stock
{
    public decimal DividendYield { get; set; } = 0.04m; // 4% dividend
    public override string GetStockType() => "Preferred Stock";
    public decimal GetDividend() => Worth * DividendYield; // Extra money
}

class Program
{
    static void Main(string[] args)
    {
        Stock common = new Stock { CurrentPrice = 150.75m, SharesOwned = 200 };
        Console.WriteLine($"Common Stock Worth: {common.Worth}"); // 30150
        Console.WriteLine($"Stock Type: {common.GetStockType()}"); // Common Stock

        PreferredStock preferred = new PreferredStock { CurrentPrice = 250.00m, SharesOwned = 200 };
        Console.WriteLine($"Preferred Stock Worth: {preferred.Worth}"); // 20050
        Console.WriteLine($"Stock Type: {preferred.GetStockType()}"); // Preferred Stock
        Console.WriteLine($"Dividend: {preferred.GetDividend()}"); // 802 (20050 * 0.04)

        Stock polyStock = preferred; // Upcasting
        Console.WriteLine($"Polymorphic Stock Type: {polyStock.GetStockType()}"); // Preferred Stock
    }
}