using LMS.Models;
using System;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Firebase.Auth;
using System.Text.RegularExpressions;
using Firebase.Auth.Providers;
using FirebaseAdmin;
using Firebase.Database;
using LMS.Util;

namespace LMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        //public static FirebaseClient firebase = new FirebaseClient(AppConstants.FIREBASE_AUTHENTICATE_KEY);
        public static string WebApiKey = "AIzaSyBR3RM_z0cl0ApLqjmG8UTGFwS7R1ZVmIA";
        public Signup()
        {
            InitializeComponent();

        }

        public bool IsEmailValid(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            bool isValid = Regex.IsMatch(email, pattern);

            return isValid;
        }
        public async void LoginPage(object obj, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmailEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
            {
                await DisplayAlert("Invalid", "FIll the required field!", "OK");
            }
            else
            {
                string email = EmailEntry.Text;

                bool isValidEmail = IsEmailValid(email);
                if (isValidEmail)
                {
                    
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    await DisplayAlert("Oops!", "It seems not an email address!!", "OK");
                }

            }
        }

        

    }
}