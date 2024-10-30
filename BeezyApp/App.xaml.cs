using BeezyApp.Models;
using BeezyApp.Services;
using BeezyApp.View;

namespace BeezyApp
{
    public partial class App : Application
    {
        public User? LoggedInUser { get; set; }
        private BeezyWebAPIProxy proxy;
        public App(IServiceProvider serviceProvider, BeezyWebAPIProxy proxy)
        {
            this.proxy = proxy;
            InitializeComponent();
            LoggedInUser = null;
            //Start with the Login View
            MainPage = new NavigationPage(serviceProvider.GetService<LoginView>());
        }

    }
}
