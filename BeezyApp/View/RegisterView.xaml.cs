using BeezyApp.ViewModels;

namespace BeezyApp.View;

public partial class RegisterView : ContentPage
{
    public RegisterView(RegisterViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }

}