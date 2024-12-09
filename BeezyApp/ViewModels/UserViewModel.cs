using BeezyApp.Models;
using BeezyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeezyApp.ViewModels
{
    public class UserViewModel:ViewModelBase
    {
        private User? currentUser;
        private BeezyWebAPIProxy proxy;
        public UserViewModel(BeezyWebAPIProxy proxy)
        {
            this.proxy = proxy;

            //איתחול כל התכונות מתוך אובייקט המשתמש שעשה לוג אין
            currentUser = ((App)Application.Current).LoggedInUser;
            Name = currentUser.UserName;
            Email = currentUser.UserEmail;
            PhoneNumber = currentUser.UserPhone;

            if (currentUser is BeeKeeper)
            {
                BeeKeeper b = (BeeKeeper)currentUser;
                BeekeeperIsActive = b.BeekeeperIsActive;
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private bool beekeeperIsActive;
        public bool BeekeeperIsActive
        {
            get => beekeeperIsActive;
            set
            {
                beekeeperIsActive = value;
                OnPropertyChanged("BeekeeperIsActive");
            }
        }

        public bool IsBeeKeeper
        {
            get => (currentUser is BeeKeeper);
        }

        public Command UpdateActiveCommand
        {
            get { return new Command(UpdateActive); }
        }

        private void UpdateActive()
        {
            if (currentUser is BeeKeeper)
            {
                BeeKeeper b = (BeeKeeper)currentUser;
                b.BeekeeperIsActive = !b.BeekeeperIsActive;

                proxy.UpdateUser(b);

            }
        }
    }
}
