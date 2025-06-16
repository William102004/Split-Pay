namespace SplitPayApp.Views;
using SplitPayApp.ViewModels;
using Split_Play_Libraries.Models;


public partial class FamilyMembersView : ContentView
{

    
    public FamilyMembersView()
    {
        InitializeComponent();
        BindingContext = new FamilyMemberViewModel();
    }

    private void AddMemberButton_Clicked(object sender, EventArgs e)
    {
        (BindingContext as FamilyMemberViewModel)?.AddFamilyMember();
        (BindingContext as FamilyMemberViewModel)?.refreshFamilyMembers();
    }

    private void UpdateBalanceButton_Clicked(object sender, EventArgs e)
    {
        (BindingContext as FamilyMemberViewModel)?.UpdateMemberBalance();
        (BindingContext as FamilyMemberViewModel)?.refreshFamilyMembers();
    }
    private void RemoveMemberButton_Clicked(object sender, EventArgs e)
    {
        //(BindingContext as FamilyMemberViewModel)?.RemoveFamilyMember();
        (BindingContext as FamilyMemberViewModel)?.DoDelete();
        (BindingContext as FamilyMemberViewModel)?.refreshFamilyMembers();  
    }
    
    
    
    
}