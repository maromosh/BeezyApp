using BeezyApp.ViewModels;

namespace BeezyApp.View;

public partial class WorkShopView : ContentPage
{
	public WorkShopView(WorkShopVeiwModle vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}
}