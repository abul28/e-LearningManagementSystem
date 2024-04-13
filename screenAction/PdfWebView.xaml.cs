using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfWebView : ContentPage
    {
        public PdfWebView()
        {
            InitializeComponent();
            
            browser.Source = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf";
        }
        
        
    }
}