using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SignBuzz.StartSection;
using Microsoft.WindowsAzure.MobileServices;

namespace SignBuzz
{
    public partial class MainPage : ContentPage
    {
        // Track whether the user has authenticated.
        bool authenticated = true;

        public MainPage()
        {
            InitializeComponent();
            startLearning.IsVisible = authenticated;

        }
        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MediaPage());
            await Navigation.PushAsync(new StartSectionPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.user != null)
            {
                Console.WriteLine(App.user.UserId);
            }
            nameEntry.IsVisible = false;
            Submit.IsVisible = false;
            // Refresh items only when authenticated.
            if (authenticated == true)
            {

                // Hide the Sign-in button.
                loginButton.IsVisible = false;
                startLearning.IsVisible = true;
                loginButtonFacebook.IsVisible = false;
               

            }
        }
        async void submit(object sender, EventArgs e)
        {
            Busy();
            await MainUserManager.DefaultManager.SaveUserAsync(new User { UserId = App.user.UserId , Name = nameEntry.Text});
            welcomeLabel.Text = "welcome " + nameEntry.Text;
            NotBusy();
            nameEntry.IsVisible = false;
            Submit.IsVisible = false;
            startLearning.IsVisible = true;
            loginButton.IsVisible = false;
            loginButtonFacebook.IsVisible = false;
        }
        async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
            {
                Busy();
                authenticated = await App.Authenticator.Authenticate(true);
                if (authenticated == true)
                {
                    List<User> items = await MainUserManager.DefaultManager.CurrentUserTable
                        .Where(user => user.UserId == App.user.UserId)
                        .ToListAsync();
                    // user first time access the application
                    if (items.Count == 0)
                    {
                        nameEntry.IsVisible = true;
                        Submit.IsVisible = true;
                        startLearning.IsVisible = false;

                    }
                    else
                    {
                        welcomeLabel.Text = "welcome " + items[0].Name;
                        nameEntry.IsVisible = false;
                        Submit.IsVisible = false;
                        startLearning.IsVisible = true;
                    }
                    NotBusy();
                    loginButton.IsVisible = false;
                    loginButtonFacebook.IsVisible = false;
                   

                }
            }
        }
        async void loginButton_Clicked_Facebook(object sender, EventArgs e)
        {
            Busy();
            authenticated = await App.Authenticator.Authenticate(false);
            if (authenticated == true)
            {
                List<User> items = await MainUserManager.DefaultManager.CurrentUserTable
                    .Where(user => user.UserId == App.user.UserId)
                    .ToListAsync();
                // user first time access the application
                if (items.Count == 0)
                {
                    nameEntry.IsVisible = true;
                    Submit.IsVisible = true;
                    startLearning.IsVisible = false;

                }
                else
                {
                    welcomeLabel.Text = "welcome " + items[0].Name;
                    nameEntry.IsVisible = false;
                    Submit.IsVisible = false;
                    startLearning.IsVisible = true;
                }
                NotBusy();
                loginButton.IsVisible = false;
                loginButtonFacebook.IsVisible = false;
            }
        }
        public void Busy()
        {
            uploadIndicator.IsVisible = true;
            uploadIndicator.IsRunning = true;
            nameEntry.IsVisible = false;
            Submit.IsVisible = false;
            startLearning.IsVisible = false;
            loginButton.IsVisible = false;
            loginButtonFacebook.IsVisible = false;
        }

        public void NotBusy()
        {
            uploadIndicator.IsVisible = false;
            uploadIndicator.IsRunning = false;
        }
    }
}
