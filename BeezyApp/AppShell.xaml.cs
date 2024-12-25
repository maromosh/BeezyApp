using BeezyApp.View;
using BeezyApp.ViewModels;

namespace BeezyApp
{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel vm)
        {
            this.BindingContext = vm;
            InitializeComponent();
            RegisterRoutes();
        }


        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(EditProfileView), typeof(EditProfileView));

        }


    }
}

