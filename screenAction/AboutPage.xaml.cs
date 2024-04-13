using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LMS.Views
{
    public partial class AboutPage : FlyoutPage
    {
        public AboutPage()
        {
            InitializeComponent();
           
        }

        public async void CategoryPage(object obj , EventArgs args) 
        {
           await Navigation.PushAsync(new Category());
        }

        public async void Signout(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());   
        }
    }
}