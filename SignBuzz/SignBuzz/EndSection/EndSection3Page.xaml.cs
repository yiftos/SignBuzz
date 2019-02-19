using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignBuzz.EndSection
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EndSection3Page : ContentPage
	{
		public EndSection3Page ()
		{
			InitializeComponent ();
		}
        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();

        }
    }
}