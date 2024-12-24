using BeezyApp.Models;
using BeezyApp.Services;
using BeezyApp.View;
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
            Name = currentUser.UserName ;
            City = currentUser.UserCity;
            PhoneNumber = currentUser.UserPhone;

            if (currentUser is BeeKeeper)
            {
                BeeKeeper b = (BeeKeeper)currentUser;
                BeekeeperIsActive = b.BeekeeperIsActive;
                IsBeeKeeper = true;
            }

            UpdateActiveCommand = new Command(UpdateActive);
        }

        public string ImageProfileURL
        {
            get
            {
                return proxy.GetImagesBaseAddress() + currentUser.ProfileImagePath;
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

        private string city;
        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged("City");
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

        private bool isBeeKeeper;
        public bool IsBeeKeeper
        {
            //get => (currentUser is BeeKeeper);
            get => isBeeKeeper;
            set
            {
                isBeeKeeper = value;
                OnPropertyChanged("IsBeeKeeper");

            }
        }
        
        public Command UpdateActiveCommand
        {
            get; set;
        }

        private async void UpdateActive()
        {
            if (currentUser is BeeKeeper)
            {
                InServerCall = true;
                BeeKeeper b = (BeeKeeper)currentUser;
                b.BeekeeperIsActive = !b.BeekeeperIsActive;
                await proxy.UpdateUser(b);
                OnPropertyChanged("ActiveButtonText");
                InServerCall = false;

            }
        }

        //ActiveButtonText
        public string ActiveButtonText
        {
            get 
            {
                if (IsBeeKeeper)
                {
                    BeeKeeper b = (BeeKeeper)currentUser;
                    if (b.BeekeeperIsActive)
                    {
                        return "שנה ללא פעיל";
                    }
                    else
                    {
                        return "שנה לפעיל";
                    }
                }
                else
                    return "";
            }
        }
        //private async void OnEditProfileClicked(object sender, EventArgs e)
        //{
        //    // Navigate to EditProfileView
        //    await Navigation.PushAsync(new EditProfileView());
        //}
    }
}
