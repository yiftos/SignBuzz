using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignBuzz.StartSection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignBuzz.EndSection
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EndSection2Page : ContentPage
	{
		public EndSection2Page ()
		{
			InitializeComponent ();
		}
        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartSection3Page());
        }
    }
}