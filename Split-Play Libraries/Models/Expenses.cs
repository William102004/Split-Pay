using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Split_Play_Libraries.Models;

public class Expenses
{
    public int? id { get; set; }
    public string? name { get; set; }
    public double? amount { get; set; }
    public DateTime date { get; set; }
    public int month { get; set; }
    public int year { get; set; }
    public int Day { get; set; }
    public string? category { get; set; }
    public string? description { get; set; }
    public bool Recurring { get; set; }
    public String? frequency { get; set; }

    public bool? split { get; set; }
    public List<int?> SplitMembers { get; set; }

    public double? SplitAmount
    {
        get
        {
            if (SplitMembers != null && SplitMembers.Count > 0)
            {
                return Math.Round((double)amount / SplitMembers.Count, 2);
            }
            else
            {
                return null;
            }
        }
    }






}
