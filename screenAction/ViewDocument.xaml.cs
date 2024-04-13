using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Firebase.Storage;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using Firebase.Database;
using System.Runtime.InteropServices.ComTypes;
using LMS.Models;
using Firebase.Database.Query;
using System.Net.Http;
using Xamarin.Forms.Shapes;
using Path = System.IO.Path;

namespace LMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewDocument : ContentPage
    {
        ObservableCollection<Item> items;

        static readonly FirebaseClient firebaseclient = new FirebaseClient("https://e-lms-54568-default-rtdb.asia-southeast1.firebasedatabase.app/");
        FirebaseHelper firebaseHelper;
        ObservableCollection<string> uploadedFiles;
        static readonly FirebaseStorage firebaseStorage = new FirebaseStorage("gs://e-lms-54568.appspot.com");
        public ViewDocument()
        {
            InitializeComponent();
             uploadedFiles = new ObservableCollection<string>();
            
            firebaseHelper = new FirebaseHelper();

            string userType = Application.Current.Properties.ContainsKey("UserType") ? (string)Application.Current.Properties["UserType"] : string.Empty;
            bool isTeacher = userType == "Teacher";

            Uploadbtn.IsVisible = isTeacher;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve the uploaded files from Firebase
            var files = await firebaseHelper.GetUploadedFiles();
            FilesCollectionView.ItemsSource = files;
        }

        private async void AddFile(object sender, EventArgs e)
        {

            var file = await FilePicker.PickAsync();

            if (file == null)
                return;

            var task = new FirebaseStorage("e-lms-54568.appspot.com",
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true,
                }).
                Child("files")
                .Child(file.FileName).PutAsync(await file.OpenReadAsync());
            var downloadlink = await task;
            await firebaseclient.Child("fileLink")
                  .PostAsync(new FileLink
                  {
                      FileName = file.FileName,
                      DownloadUrl = downloadlink
                  });
            await DisplayAlert("Success", "File uploaded successfully", "OK");
            var list = (await firebaseclient.Child("fileLink")
                     .OnceAsync<FileLink>()).Select(item => new FileLink
                     {
                         FileName =   item.Object.FileName,
                         DownloadUrl = item.Object.DownloadUrl,
                     }).ToList();
            FilesCollectionView.ItemsSource = list;
        }
        private void myCollectionView(object obj, SelectionChangedEventArgs e)
        {
            var itemSelected = e.CurrentSelection[0] as FileLink;
            LoadPdf(itemSelected.DownloadUrl);

        }
        private async void LoadPdf(string fpath)
        {
           
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "Preview.pdf");
            var pdfPath = fpath;
            var pdfData = await DownloadPdfData(pdfPath);
            if (pdfData != null)
            {
                try
                {
                    File.WriteAllBytes(filePath, pdfData);
                    await Launcher.OpenAsync(new OpenFileRequest
                    {
                        File = new ReadOnlyFile(filePath)
                    });

                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
            }
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                    }

        }
        private async Task<byte[]> DownloadPdfData(string pdfUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    return await httpClient.GetByteArrayAsync(pdfUrl);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                return null;
            }
        }


    }

}