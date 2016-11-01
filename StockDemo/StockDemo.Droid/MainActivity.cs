using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using StockDemo.ViewModel;

namespace StockDemo.Droid
{
	[Activity (Label = "Stocks", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        StockViewModel viewModel;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			var button = FindViewById<Button> (Resource.Id.button_getquote);
            var edittext = FindViewById<EditText>(Resource.Id.edittext_ticker);

            var quote = FindViewById<TextView>(Resource.Id.text_quote);
            var company = FindViewById<TextView>(Resource.Id.text_company);

            viewModel = new StockViewModel();

            button.Click += async (sender, args) =>
            {
                button.Enabled = false;

                var result = await viewModel.GetQuote(edittext.Text);

                if (!result)
                    Toast.MakeText(this, "Unable to get quote", ToastLength.Short).Show();
                else
                {
                    quote.Text = viewModel.Data?.CurrentQuote ?? string.Empty;
                    company.Text = viewModel.Data?.Company ?? string.Empty;
                }

                button.Enabled = true;

            };
            
		}
	}
}


