using System;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.AppCompat;
using Split_Pay_Libraries.Models;
using Split_Play_Libraries.Services;

namespace SplitPayApp.ViewModels;

public class FamilyMemberViewModel : BaseViewModel
{
    private FamilyMember? CachedFamilyMember { get; set; }
    public FamilyMember? FamilyMember { get; set; }

    public string? Name
    {
        get
        {
            return FamilyMember?.Name ?? string.Empty;
        }
        set
        {
            if(FamilyMember != null && FamilyMember.Name != value)
            {
                FamilyMember.Name = value;
            }
        }
    }
    public string? Email
    {
        get
        {
            return FamilyMember?.email ?? string.Empty;
        }
        set
        {
            if(FamilyMember != null && FamilyMember.email != value)
            {
                FamilyMember.email = value;
            }
        }
    }
    public string? Phone
    {
        get
        {
            return FamilyMember?.phone ?? string.Empty;
        }
        set
        {
            if(FamilyMember != null && FamilyMember.phone != value)
            {
                FamilyMember.phone = value;
            }
        }
    }
    public string? Address
    {
        get
        {
            return FamilyMember?.address ?? string.Empty;
        }
        set
        {
            if(FamilyMember != null && FamilyMember.address != value)
            {
                FamilyMember.address = value;
            }
        }
    }
    public double Balance
    {
        get
        {
            return FamilyMember?.Balance ?? 0.0;
        }
        set
        {
            if(FamilyMember != null && FamilyMember.Balance != value)
            {
                FamilyMember.Balance = value;
            }
        }
    }
    

    public FamilyMemberViewModel()
    {
        FamilyMember = new FamilyMember();
        CachedFamilyMember = null;
    }

    public FamilyMemberViewModel(FamilyMember familyMember)
    {
        FamilyMember = familyMember;
        if (familyMember != null)
        {
            CachedFamilyMember = new FamilyMember(familyMember.id, familyMember.Name, familyMember.email, familyMember.phone, familyMember.address, familyMember.Balance ?? 0.0);
        }
    }
}
