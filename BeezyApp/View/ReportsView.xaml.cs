using BeezyApp.ViewModels;

namespace BeezyApp.View;

public partial class ReportsView : ContentPage
{
	public ReportsView(ReportsVeiwModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}
}