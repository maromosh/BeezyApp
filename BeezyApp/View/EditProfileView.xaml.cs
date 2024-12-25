using BeezyApp.ViewModels;

namespace BeezyApp.View;

public partial class EditProfileView : ContentPage
{
	public EditProfileView(EditProfileViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}
}