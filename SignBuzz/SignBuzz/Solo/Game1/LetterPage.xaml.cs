﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignBuzz.Solo.Game1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LetterPage : ContentPage
    {
        String[] sources = { "ex_a.png", "ex_b.png", "ex_c.png", "ex_d.png", "ex_e.png", "ex_f.png", "ex_g.png", "ex_h.png", "ex_i.png", "ex_j.png", "ex_k.png", "ex_l.png", "ex_m.png", "ex_n.png", "ex_o.png", "ex_p.png", "ex_q.png", "ex_r.png", "ex_s.png", "ex_t.png", "ex_u.png", "ex_v.png", "ex_w.png", "ex_x.png", "ex_y.png", "ex_z.png" };
        String[] videoSources = { "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m3s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tvTRZJ-4EyI", "https://www.youtube.com/watch?v=tvTRZJ-4EyI", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s", "https://www.youtube.com/watch?v=tkMg8g8vVUo&t=0m20s" };
        String[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string letter;
        int videoIndex;
        //string source;
        public LetterPage(int vidIndex)
        {
            InitializeComponent();
            this.letter = letters[vidIndex];
            this.letterImage.Source = sources[vidIndex];
            this.videoIndex = vidIndex;

        }
        
            async void takePicture(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MediaPage(letter, null, 0, null, GameOnePage.questions_array));
        }

        //            
        //async void mainPage(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new GameOnePage(0));
        //}
        //async void nextPage(object sender, EventArgs e)
        //{
        //    if (this.letter=="Z")
        //    {
        //        await Navigation.PushAsync(new letterPage(0));
        //    }
        //    else
        //    {
        //        await Navigation.PushAsync(new letterPage(videoIndex + 1));
        //    }
        //}
        //async void previousPage(object sender, EventArgs e)
        //{
        //if (this.letter == "A")
        //{
        //    await Navigation.PushAsync(new letterPage(25));
        //}
        //else
        //{
        //    await Navigation.PushAsync(new letterPage(videoIndex - 1));
        //}
        //}

        protected override void OnAppearing()
        {
            letterHeader.Text = this.letter;
            if(GameOnePage.questions_array[videoIndex] == 1)
            {
                finish.IsVisible = true;
            }
            //letterImage.Source = this.source;
        }
        private void PlayVideo(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var wv = new WebView();
            wv.Source = videoSources[this.videoIndex];
            wv.HeightRequest = 4000;
            wv.WidthRequest = 1000;
            layout.Children.Insert(2, wv);
            //webview.Source = videoSources[this.videoIndex];

        }
    }
}
