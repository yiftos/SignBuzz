using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignBuzz.EndSection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignBuzz.Game2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameOnePage : ContentPage
	{
		public GameOnePage (int num)
		{
			InitializeComponent ();
            this.num = num;
        }
        int num;
        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            if (this.num == 5)
            {
                await Navigation.PushAsync(new EndSection.EndSection2Page());

            }
            else
            {
                await Navigation.PushAsync(new GameOnePage(this.num + 1));
            }
        }
    }
}