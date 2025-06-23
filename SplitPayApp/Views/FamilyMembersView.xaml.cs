namespace SplitPayApp.Views;
using SplitPayApp.ViewModels;
using Split_Play_Libraries.Models;
using Split_Pay_Libraries.Models;

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

    public void RemoveMemberButton_Clicked(object sender, EventArgs e)
    {
         if (sender is Button button && button.BindingContext is FamilyMember familyMember)
        {
            // Get the view model and call the delete method with the specific family member
            var viewModel = BindingContext as FamilyMemberViewModel;
            viewModel?.DoDelete(familyMember);
        }
    }
    
    
    
    
    
}