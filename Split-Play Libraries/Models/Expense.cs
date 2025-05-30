using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Split_Play_Libraries.Models;

public class Expense
{
    public int? id { get; set; }
    public string? name { get; set; }
    public double? amount { get; set; }
    public int month { get; set; }
    public int year { get; set; }
    public int Day { get; set; }
    public string? category { get; set; }
    public string? description { get; set; }
    public bool Recurring { get; set; }
    public String? frequency { get; set; }
    


    public String? Display
    {
        get
        {
            return $"{id}.{name}: ${amount} on {month},{Day},{year}, Category: {category}, Description: {description}, Recurring: {Recurring}, Frequency: {frequency}";
        }
    }

    public Expense()
    {
        name = string.Empty;
        amount = 0.0;
        month = DateTime.Now.Month;
        year = DateTime.Now.Year;
        Day = DateTime.Now.Day;
        category = string.Empty;
        description = string.Empty;
        Recurring = false;
        frequency = string.Empty;
       
    }
    public Expense(int Id, string Name, double Amount, int Month, int Year, int day, string Category, string Description, bool recurring, string Frequency)
    {
        id = Id;
        name = Name;
        amount = Amount;
        month = Month;
        year = Year;
        Day = day;
        category = Category;
        description = Description;
        Recurring = recurring;
        if (recurring)
        {
            frequency = Frequency;
        }
        else
        {
            frequency = string.Empty;
        }

    }


}
