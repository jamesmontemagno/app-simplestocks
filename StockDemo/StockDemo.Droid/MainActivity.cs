
using Android.App;
using Android.Widget;
using Android.OS;
using StockDemo.ViewModel;

namespace StockDemo.Droid
{
    [Activity (Label = "Stocks", 
        MainLauncher = true, 
        Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        StockViewModel viewModel;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


            viewModel = new StockViewModel();

            // Get our button from the layout resource,
            // and attach an event to it

            var ticker = FindViewById<EditText>(Resource.Id.edittext_ticker);
            var button = FindViewById<Button>(Resource.Id.button_getquote);
            var labelQuote = FindViewById<TextView>(Resource.Id.text_quote);
            var labelCompany = FindViewById<TextView>(Resource.Id.text_company);

            button.Click += async (sender, args) =>
            {
                button.Enabled = false;

                var result = await viewModel.GetQuote(ticker.Text);
                if(result)
                {
                    labelCompany.Text = viewModel.Data.Company;
                    labelQuote.Text = viewModel.Data.CurrentQuote;
                }
                else
                {
                    labelCompany.Text = string.Empty;
                    labelQuote.Text = string.Empty;
                }

                button.Enabled = true;
            };
            
		}
	}
}


