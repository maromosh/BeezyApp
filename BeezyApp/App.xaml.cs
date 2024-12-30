using BeezyApp.Models;
using BeezyApp.Services;
using BeezyApp.View;

namespace BeezyApp
{
    public partial class App : Application
    {
        public User? LoggedInUser { get; set; }
        public BeeKeeper LoggedInUserBeekeeper { get; set; }
        private BeezyWebAPIProxy proxy;
        public App(IServiceProvider serviceProvider, BeezyWebAPIProxy proxy)
        {
            if(LoggedInUser is BeeKeeper)
            {
                LoggedInUserBeekeeper = (BeeKeeper)LoggedInUser;
                this.proxy = proxy;
                InitializeComponent();
                LoggedInUser = null;
                //Start with the Login View
                MainPage = new NavigationPage(serviceProvider.GetService<LoginView>());
            }
            else
            {
                this.proxy = proxy;
                InitializeComponent();
                LoggedInUser = null;
                //Start with the Login View
                MainPage = new NavigationPage(serviceProvider.GetService<LoginView>());
            }
            
        }
        

    }
}
