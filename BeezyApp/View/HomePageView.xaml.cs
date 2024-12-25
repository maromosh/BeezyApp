using BeezyApp.ViewModels;

namespace BeezyApp.View;

public partial class HomePageView : ContentPage
{
	public HomePageView(HomePageVeiwModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}
}