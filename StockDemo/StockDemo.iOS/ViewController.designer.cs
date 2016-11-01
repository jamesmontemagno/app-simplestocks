// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace StockDemo.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonGetQuote { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelCompany { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelQuote { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldTicker { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonGetQuote != null) {
                ButtonGetQuote.Dispose ();
                ButtonGetQuote = null;
            }

            if (LabelCompany != null) {
                LabelCompany.Dispose ();
                LabelCompany = null;
            }

            if (LabelQuote != null) {
                LabelQuote.Dispose ();
                LabelQuote = null;
            }

            if (TextFieldTicker != null) {
                TextFieldTicker.Dispose ();
                TextFieldTicker = null;
            }
        }
    }
}