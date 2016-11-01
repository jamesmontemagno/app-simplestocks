using StockDemo.ViewModel;
using System;

using UIKit;

namespace StockDemo.iOS
{
	public partial class ViewController : UIViewController
	{
        StockViewModel viewModel;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            viewModel = new StockViewModel();

            ButtonGetQuote.TouchUpInside += async (sender, args) =>
            {
                ButtonGetQuote.Enabled = false;

                var result = await viewModel.GetQuote(TextFieldTicker.Text);

                if(result)
                {
                    LabelCompany.Text = viewModel.Data.Company;
                    LabelQuote.Text = viewModel.Data.CurrentQuote;
                }
                else
                {
                    new UIAlertView("Error", "Unable to get quote", null, "OK").Show();
                }

                ButtonGetQuote.Enabled = true;

            };
		}

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

