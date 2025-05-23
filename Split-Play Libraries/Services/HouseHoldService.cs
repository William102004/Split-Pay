using System;
using Split_Pay_Libraries.Models;

namespace Split_Pay_Libraries.Services;

public class HouseHoldService
{
    private HouseHoldService()
    {
        Household = new List<FamilyMember?>();
    }

    private int LastKey
    {
        get
        {
            if (!Household.Any())
            {
                return 0;
            }

            return Household.Select(f => f?.id ?? 0).Max();
        }
    }
    private static HouseHoldService? instance;
    private static object instanceLock = new object();
    public static HouseHoldService Current
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new HouseHoldService();
                }
            }

            return instance;
        }
    }

    public List<FamilyMember?> Household { get; private set; }

} 
