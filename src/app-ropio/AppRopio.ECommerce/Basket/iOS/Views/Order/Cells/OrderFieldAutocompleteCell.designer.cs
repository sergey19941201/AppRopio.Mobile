// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.ECommerce.Basket.iOS.Views.Order.Cells
{
    [Register ("OrderFieldAutocompleteCell")]
    partial class OrderFieldAutocompleteCell
    {
        [Outlet]
        UIKit.UILabel _valueLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_valueLabel != null) {
                _valueLabel.Dispose ();
                _valueLabel = null;
            }
        }
    }
}