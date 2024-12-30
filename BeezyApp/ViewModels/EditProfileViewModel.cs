using BeezyApp.Models;
using BeezyApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeezyApp.ViewModels
{
    public class EditProfileViewModel: ViewModelBase
    {
        private User currentUser;
        private BeezyWebAPIProxy proxy;
        private IServiceProvider serviceProvider;

        public EditProfileViewModel(BeezyWebAPIProxy proxy)
        {

            currentUser = ((App)Application.Current).LoggedInUser;

            this.proxy = proxy;
            EditCommand = new Command(OnEdit);


            Name = currentUser.UserName;
            Password = currentUser.UserPassword;
            Email = currentUser.UserEmail;
            PhoneNumber = currentUser.UserPhone;
            City = currentUser.UserCity;
            Address = currentUser.UserAddress;

            PhotoURL = proxy.GetImagesBaseAddress() + currentUser.ProfileImagePath;

            if (currentUser is BeeKeeper)
            {
                BeeKeeper b = (BeeKeeper)currentUser;
                IsBeekeeper = true;
            }


            //CancelCommand = new Command(OnCancel);
            ShowPasswordCommand = new Command(OnShowPassword);
            UploadPhotoCommand = new Command(OnUploadPhoto);
            UploadTakePhotoCommand = new Command(OnUploadTakePhoto);
            PhotoURL = proxy.GetDefaultProfilePhotoUrl();

            SaveCommand = new Command(OnSave);

            UploadPhotoCommand = new Command(OnUploadPhoto);
            UploadTakePhotoCommand = new Command(OnUploadTakePhoto);


            ShowPasswordCommand = new Command(OnShowPassword);
            IsPassword = true;
            NameError = "שדה השם אינו תקין";
            PhoneNumberError = "שדה הטלפון אינו תקין";
            EmailError = "שדה האימייל אינו תקין";
            PasswordError = "הסיסמה חייבת להיות באורך 4 תווים לפחות ולהכיל אותיות ומספרים";
            CityError = "שדה העיר אינו תקין";
            AddressError = "שדה הכתובת אינו תקין";
            kinds = (new BeeKeeperKinds()).Kinds;
            Kind = Kinds[0];
            //RefreshCommand = new Command(Refresh);
            //ValidateManicurist();


        }

        #region Name
        private bool showNameError;

        public bool ShowNameError
        {
            get => showNameError;
            set
            {
                showNameError = value;
                OnPropertyChanged("ShowNameError");
            }
        }

        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                ValidateName();
                OnPropertyChanged("Name");
            }
        }

        private string nameError;

        public string NameError
        {
            get => nameError;
            set
            {
                nameError = value;
                OnPropertyChanged("NameError");
            }
        }

        private void ValidateName()
        {
            this.ShowNameError = string.IsNullOrEmpty(Name);
        }
        #endregion

        #region Password
        private bool showPasswordError;

        public bool ShowPasswordError
        {
            get => showPasswordError;
            set
            {
                showPasswordError = value;
                OnPropertyChanged("ShowPasswordError");
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                ValidatePassword();
                OnPropertyChanged("Password");
            }
        }

        private string passwordError;

        public string PasswordError
        {
            get => passwordError;
            set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }

        private void ValidatePassword()
        {
            //Password must include characters and numbers and be longer than 4 characters
            if (string.IsNullOrEmpty(password) ||
                password.Length < 4 ||
                !password.Any(char.IsDigit) ||
                !password.Any(char.IsLetter))
            {
                this.ShowPasswordError = true;
            }
            else
                this.ShowPasswordError = false;
        }

        //This property will indicate if the password entry is a password
        private bool isPassword = true;
        public bool IsPassword
        {
            get => isPassword;
            set
            {
                isPassword = value;
                OnPropertyChanged("IsPassword");
            }
        }
        //This command will trigger on pressing the password eye icon
        public Command ShowPasswordCommand { get; }
        //This method will be called when the password eye icon is pressed
        public void OnShowPassword()
        {
            //Toggle the password visibility
            IsPassword = !IsPassword;
        }
        #endregion

        #region Email
        private bool showEmailError;

        public bool ShowEmailError
        {
            get => showEmailError;
            set
            {
                showEmailError = value;
                OnPropertyChanged("ShowEmailError");
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                ValidateEmail();
                OnPropertyChanged("Email");
            }
        }

        private string emailError;

        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value;
                OnPropertyChanged("EmailError");
            }
        }

        private void ValidateEmail()
        {
            this.ShowEmailError = string.IsNullOrEmpty(Email);
            if (!ShowEmailError)
            {
                //check if email is in the correct format using regular expression
                if (!System.Text.RegularExpressions.Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    EmailError = "האימייל אינו תקין";
                    ShowEmailError = true;
                }
                else
                {
                    EmailError = "";
                    ShowEmailError = false;
                }
            }
            else
            {
                EmailError = "שדה האימייל נדרש";
            }
        }
        #endregion

        #region PhoneNumber
        private bool showPhoneNumberError;

        public bool ShowPhoneNumberError
        {
            get => showPhoneNumberError;
            set
            {
                showPhoneNumberError = value;
                OnPropertyChanged("ShowPhoneNumberError");
            }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                ValidatePhoneNumber();
                OnPropertyChanged("PhoneNumber");
            }
        }

        private string phoneNumberError;

        public string PhoneNumberError
        {
            get => phoneNumberError;
            set
            {
                phoneNumberError = value;
                OnPropertyChanged("PhoneNumberError");
            }
        }


        private void ValidatePhoneNumber()
        {
            if (string.IsNullOrEmpty(PhoneNumber) ||
                PhoneNumber.Length != 10)
            {
                this.ShowPhoneNumberError = true;
            }
            else
                this.ShowPhoneNumberError = false;
        }

        #endregion

        #region City
        private bool showcityError;

        public bool ShowCityError
        {
            get => showcityError;
            set
            {
                showcityError = value;
                OnPropertyChanged("ShowCityError");
            }
        }

        private string city;

        public string City
        {
            get => city;
            set
            {
                city = value;
                ValidateCity();
                OnPropertyChanged("City");
            }
        }

        private string cityError;

        public string CityError
        {
            get => cityError;
            set
            {
                cityError = value;
                OnPropertyChanged("CityError");
            }
        }

        private void ValidateCity()
        {
            this.ShowCityError = string.IsNullOrEmpty(City);
        }
        #endregion

        #region Address
        private bool showAddressError;

        public bool ShowAddressError
        {
            get => showAddressError;
            set
            {
                showAddressError = value;
                OnPropertyChanged("ShowAddressError");
            }
        }

        private string address;

        public string Address
        {
            get => address;
            set
            {
                address = value;
                ValidateAddress();
                OnPropertyChanged("Address");
            }
        }

        private string addressError;

        public string AddressError
        {
            get => addressError;
            set
            {
                addressError = value;
                OnPropertyChanged("AddressError");
            }
        }

        private void ValidateAddress()
        {
            this.ShowAddressError = string.IsNullOrEmpty(Address);
        }
        #endregion

        #region Beekeeper Info
        private bool isBeekeeper;
        public bool IsBeekeeper
        {
            get => isBeekeeper;
            set
            {
                isBeekeeper = value;
                OnPropertyChanged("IsBeekeeper");
                ShowBeekeeperFields = value; // Show the additional fields if the user is a beekeeper
            }
        }

        private bool showBeekeeperFields;
        public bool ShowBeekeeperFields
        {
            get => showBeekeeperFields;
            set
            {
                showBeekeeperFields = value;
                OnPropertyChanged("ShowBeekeeperFields");
            }
        }

        private int radius;

        public int Radius
        {
            get => radius;
            set
            {
                Radius = value;
                OnPropertyChanged("Radius");
            }
        }

        private string kind;
        public string Kind
        {
            get => kind;
            set
            {
                kind = value;
                OnPropertyChanged("Kind");
            }
        }

        private List<string> kinds;
        public List<string> Kinds
        {
            get => kinds;
            set
            {
                kinds = value;
                OnPropertyChanged();
            }
        }
        #endregion


        #region Photo

        private string photoURL;

        public string PhotoURL
        {
            get => photoURL;
            set
            {
                photoURL = value;
                OnPropertyChanged("PhotoURL");
            }
        }

        private string localPhotoPath;

        public string LocalPhotoPath
        {
            get => localPhotoPath;
            set
            {
                localPhotoPath = value;
                OnPropertyChanged("LocalPhotoPath");
            }
        }

        public Command UploadPhotoCommand { get; }
        //This method open the file picker to select a photo
        private async void OnUploadPhoto()
        {
            try
            {
                var result = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "בחר תמונה מהגלריה",
                });

                if (result != null)
                {
                    // The user picked a file
                    this.LocalPhotoPath = result.FullPath;
                    this.PhotoURL = result.FullPath;
                }
            }
            catch (Exception ex)
            {

            }

        }
        public Command UploadTakePhotoCommand { get; }
        //This method open the file picker to select a photo
        private async void OnUploadTakePhoto()
        {
            try
            {
                var result = await MediaPicker.Default.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = "Please select a photo",
                });

                if (result != null)
                {
                    // The user picked a file
                    this.LocalPhotoPath = result.FullPath;
                    this.PhotoURL = result.FullPath;
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void UpdatePhotoURL(string virtualPath)
        {
            Random r = new Random();
            PhotoURL = proxy.GetImagesBaseAddress() + virtualPath + "?v=" + r.Next();
            LocalPhotoPath = "";
        }

        #endregion

        
        #region Change
        private bool change;

        public bool Change
        {
            get => change;
            set
            {
                change = value;
                OnPropertyChanged("Change");
            }
        }
        #endregion

        

        public Command EditCommand { get; }

        public void OnEdit()
        {
            Change = true;
        }

        //Define a command for the Save button
        public Command SaveCommand { get; }

        //Define a method that will be called when the register button is clicked
        public async void OnSave()
        {
            ValidateName();
            ValidatePassword();
            ValidateEmail();
            ValidatePhoneNumber();
            ValidateCity();
            ValidateAddress();


            if (!showNameError && !showPasswordError && !ShowEmailError && !ShowPhoneNumberError && !ShowCityError && !ShowAddressError)
            {
                if(IsBeekeeper)
                {
                    //Update AppUser object with the data from the Edit form
                    BeeKeeper theUser = ((App)App.Current).LoggedInUserBeekeeper;
                    theUser.UserName = Name;
                    theUser.UserPassword = Password;
                    theUser.UserEmail = Email;
                    theUser.UserPhone = PhoneNumber;
                    theUser.UserCity = Address;
                    theUser.UserAddress = address;
                    theUser.BeekeeperKind = Kind;
                    theUser.BeekeeperRadius = Radius;


                    //Call the Register method on the proxy to register the new user
                    InServerCall = true;
                    bool success = await proxy.UpdateUser(theUser);

                    Change = false;
                    //If the save was successful, navigate to the login page
                    if (success)
                    {
                        //Upload profile imae if needed
                        if (!string.IsNullOrEmpty(LocalPhotoPath))
                        {
                            User? updatedUser = await proxy.UploadProfileImage(LocalPhotoPath);
                            if (updatedUser == null)
                            {
                                await Shell.Current.DisplayAlert("Save Profile", "User Data Was Saved BUT Profile image upload failed", "ok");
                            }
                            else
                            {
                                theUser.ProfileImagePath = updatedUser.ProfileImagePath;
                                UpdatePhotoURL(theUser.ProfileImagePath);
                            }

                        }
                        InServerCall = false;
                        await Shell.Current.DisplayAlert("Save Profile", "Profile saved successfully", "ok");
                    }
                    else
                    {
                        InServerCall = false;
                        //If the registration failed, display an error message
                        string errorMsg = "Save Profile failed. Please try again.";
                        await Shell.Current.DisplayAlert("Save Profile", errorMsg, "ok");
                    }
                }
                else
                {
                    //Update AppUser object with the data from the Edit form
                    User theUser = ((App)App.Current).LoggedInUser;
                    theUser.UserName = Name;
                    theUser.UserPassword = Password;
                    theUser.UserEmail = Email;
                    theUser.UserPhone = PhoneNumber;
                    theUser.UserCity = Address;
                    theUser.UserAddress = address;

                    //Call the Register method on the proxy to register the new user
                    InServerCall = true;
                    bool success = await proxy.UpdateUser(theUser);

                    Change = false;
                    //If the save was successful, navigate to the login page
                    if (success)
                    {
                        //Upload profile imae if needed
                        if (!string.IsNullOrEmpty(LocalPhotoPath))
                        {
                            User? updatedUser = await proxy.UploadProfileImage(LocalPhotoPath);
                            if (updatedUser == null)
                            {
                                await Shell.Current.DisplayAlert("Save Profile", "User Data Was Saved BUT Profile image upload failed", "ok");
                            }
                            else
                            {
                                theUser.ProfileImagePath = updatedUser.ProfileImagePath;
                                UpdatePhotoURL(theUser.ProfileImagePath);
                            }

                        }
                        InServerCall = false;
                        await Shell.Current.DisplayAlert("Save Profile", "Profile saved successfully", "ok");
                    }
                    else
                    {
                        InServerCall = false;
                        //If the registration failed, display an error message
                        string errorMsg = "Save Profile failed. Please try again.";
                        await Shell.Current.DisplayAlert("Save Profile", errorMsg, "ok");
                    }
                }
            }
        }

        public void OnCancel()
        {
            //Navigate back to the login page
            ((App)(Application.Current)).MainPage.Navigation.PopAsync();
        }
    }
}
