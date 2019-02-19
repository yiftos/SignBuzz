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
	public partial class EndSectionPage : ContentPage
	{
		public EndSectionPage ()
		{
			InitializeComponent ();
		}
        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartSection2Page());
        }
    }
}