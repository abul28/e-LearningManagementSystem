using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Storage;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Firebase.Database.Query;
using LMS.Models;
using System.Linq;

namespace LMS
{
    public class FirebaseHelper
    {

        static readonly FirebaseClient firebaseclient = new FirebaseClient("https://e-lms-54568-default-rtdb.asia-southeast1.firebasedatabase.app/");

        static readonly FirebaseStorage firebaseStorage = new FirebaseStorage("gs://e-lms-54568.appspot.com/");

        static readonly string filesNode = "files";

        static readonly string storagePath = "https://console.firebase.google.com/project/e-lms-54568/storage/e-lms-54568.appspot.com/files";

       /* public static async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var storageReference = firebaseStorage.Child("files").Child(fileName);
            var uploadTask = storageReference.PutAsync(fileStream);
            var downloadUrl = await uploadTask;

            var fileReference = await firebaseclient.Child(filesNode).PostAsync(downloadUrl);
            return fileReference.Key;
        }*/

        public async Task<List<FileLink>> GetUploadedFiles()
        {
            var files = new List<FileLink>();
            try
            {
                files = (await firebaseclient.Child("fileLink")
                   .OnceAsync<FileLink>()).Select(item => new FileLink
                   {
                       FileName = item.Object.FileName,
                       DownloadUrl = item.Object.DownloadUrl,
                   }).ToList();
                

            }
            catch (Exception e)
            {

                throw;
            }
            return files;
        }
    }
}
