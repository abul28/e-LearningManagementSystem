using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndexPage : ContentPage
    {
        public IndexPage()
        {
            InitializeComponent();
        }

        public async void OnStudentButtonClicked(object obj, EventArgs args)
        {
            Application.Current.Properties["UserType"] = "Student";
            Application.Current.SavePropertiesAsync();
            await Navigation.PushAsync(new AboutPage());
           
        }

        public async void OnTeacherButtonClicked(object obj, EventArgs args)
        {
            Application.Current.Properties["UserType"] = "Teacher";
            Application.Current.SavePropertiesAsync();
            await Navigation.PushAsync(new LoginPage());
            
        }

    }
}