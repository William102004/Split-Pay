using System;

namespace SplitPayApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void CreateHouseholdButton_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPageView");
	}
}

