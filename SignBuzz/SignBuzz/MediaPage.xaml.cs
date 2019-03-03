using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.Storage;
using System.IO;
using System.Net.Http;

namespace SignBuzz
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaPage : ContentPage
    {
        public MediaPage()
        {
            InitializeComponent();
        }
        private MediaFile _mediaFile;
        private string URL { get; set; }

        //Picture choose from device    
        private async void btnSelectPic_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;
                imageView.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                UploadedUrl.Text = "Image URL:";
            }
        }

        //Upload picture button    
        private async void btnUpload_Clicked(object sender, EventArgs e)
        {
            if (_mediaFile == null)
            {
                await DisplayAlert("Error", "There was an error when trying to get your image.", "OK");
                return;
            }
            else
            {
                UploadImage(_mediaFile.GetStream());
            }
        }

        //Take picture from camera    
        private async void btnTakePic_Clicked(object sender, EventArgs e)
        {

            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":(No Camera available.)", "OK");
                return;
            }
            else
            {
                _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "myImage.jpg"
                });

                if (_mediaFile == null) return;
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                imageView.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                
                UploadedUrl.Text = "Image URL:";
            }
        }
        private async void sendHttp_Clicked(object sender, EventArgs e)
        {
            string newUrl = URL.Replace("/", "`");
            Console.WriteLine("http://13.95.106.120:443/process/img/" + newUrl);
            var responseString = await App.client.GetStringAsync("http://13.95.106.120:443/process/img/" + newUrl);
            Console.WriteLine(responseString);
            UploadedUrl.Text = responseString;
        }
        //Upload to blob function    
        private async void UploadImage(Stream stream)
        {
            Busy();
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=group6;AccountKey=emLbRRuzA5x29nstt/9AU6hIcXYihpQnUsAIcIZvfIFukJxHE9Flm340+rItRN7XfEPsfwZ8pEXoxkIDZXxSHw==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("images");
            await container.CreateIfNotExistsAsync();
            var name = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{name}.png");
            await blockBlob.UploadFromStreamAsync(stream);
            URL = blockBlob.Uri.OriginalString;
            UploadedUrl.Text = URL;
            
            NotBusy();
            await DisplayAlert("Uploaded", "Image uploaded to Blob Storage Successfully!", "OK");
        }

        public void Busy()
        {
            uploadIndicator.IsVisible = true;
            uploadIndicator.IsRunning = true;
            btnSelectPic.IsEnabled = false;
            btnTakePic.IsEnabled = false;
            btnUpload.IsEnabled = false;
        }

        public void NotBusy()
        {
            uploadIndicator.IsVisible = false;
            uploadIndicator.IsRunning = false;
            btnSelectPic.IsEnabled = true;
            btnTakePic.IsEnabled = true;
            btnUpload.IsEnabled = true;
        }
    }
}
