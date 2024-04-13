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
    public partial class Category : ContentPage
    {
        public Category()
        {
            InitializeComponent();
            SelectYear.Items.Add("Sem 1");
            SelectYear.Items.Add("Sem 2");
            SelectYear.Items.Add("Sem 3");
            SelectYear.Items.Add("Sem 4");
            SelectYear.Items.Add("Sem 5");
            SelectYear.Items.Add("Sem 6");
            SelectYear.Items.Add("Sem 7");
            SelectYear.Items.Add("Sem 8");

            SelectRegulation.Items.Add("2017");
            SelectRegulation.Items.Add("2021");

        }

        public async void Calculator(object obj, EventArgs args) 
        {
            await Navigation.PushAsync(new Calculator());
        }

        public async void ViewDocument(object obj, EventArgs args)
        {
            var SelectedOption1 = SelectYear.SelectedItem as string;
            var SelectedOption2 = SelectRegulation.SelectedItem as string;

            if(SelectedOption1 != null && SelectedOption2 != null)
            {
                await Navigation.PushAsync(new ViewDocument());
            }
            else
            {
                await DisplayAlert("Info", "Please Select The Sem and Regulation", "OK");
            }

        }

    }
}