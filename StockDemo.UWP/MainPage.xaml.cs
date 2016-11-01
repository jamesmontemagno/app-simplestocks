using StockDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StockDemo.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StockViewModel viewModel;
        public MainPage()
        {
            this.InitializeComponent();
            viewModel = new StockViewModel();
            ButtonGetQuote.Click += ButtonGetQuote_Click;
        }
        
        private async void ButtonGetQuote_Click(object sender, RoutedEventArgs e)
        {
            ButtonGetQuote.IsEnabled = false;

            var result = await viewModel.GetQuote(TextTicker.Text);

            if(result)
            {
                TextBlockCompany.Text = viewModel.Data.Company;
                TextBlockQuote.Text = viewModel.Data.CurrentQuote;
            }

            ButtonGetQuote.IsEnabled = true;
            
        }
    }
}
