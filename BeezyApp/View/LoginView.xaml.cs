using BeezyApp.ViewModels;

namespace BeezyApp.View;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}