using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignBuzz.Game2;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignBuzz.StartSection
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartSection2Page : ContentPage
	{
		public StartSection2Page ()
		{
			InitializeComponent ();
		}
        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GameOnePage(0));
        }
    }
}