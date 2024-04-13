using LMS.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LMS.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}