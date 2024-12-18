using BeezyApp.ViewModels;

namespace BeezyApp.View;

public partial class UserView : ContentPage
{
	public UserView(UserViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}