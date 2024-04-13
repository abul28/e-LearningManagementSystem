using Firebase.Database;
using FirebaseAdmin;
using LMS.Models;
using LMS.Util;
using LMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LMS.Views
{
    public partial class LoginPage : ContentPage
    {
        //public static FirebaseClient firebase = new FirebaseClient(AppConstants.FIREBASE_AUTHENTICATE_URI);
        public LoginPage()
        {
            InitializeComponent();
        }
        public bool IsEmailValid(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            bool isValid = Regex.IsMatch(email, pattern);

            return isValid;
        }
        public async void AboutPage(object obj, EventArgs args)
        {
            if (string.IsNullOrEmpty(emailentry.Text) || string.IsNullOrEmpty(passwordentry.Text))
            {
                await DisplayAlert("Invalid", "FIll the required field!", "OK");
            }
            else
            {
                string email = emailentry.Text;
                bool isValidEmail = IsEmailValid(email);
                if (isValidEmail)
                {

                    await Navigation.PushAsync(new AboutPage());
                }
                else
                {
                    await DisplayAlert("Oops!", "It seems not an email address!!", "OK");
                }
            }
           
        }

        public async void Label_Click(object sender, System.EventArgs e) 
        {
            var label = (Label)sender;
            if (label.Text == "Dont have an account?")
                await Navigation.PushAsync(new Signup());
        }

    }
}