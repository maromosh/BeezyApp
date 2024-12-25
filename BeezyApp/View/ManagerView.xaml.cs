using BeezyApp.ViewModels;

namespace BeezyApp.View;

public partial class ManagerView : ContentPage
{
	public ManagerView(ManagerVeiwModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}
}