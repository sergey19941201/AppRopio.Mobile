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
    [Register ("OrderFieldCell")]
    partial class OrderFieldCell
    {
        [Outlet]
        UIKit.UIButton _actionButton { get; set; }


        [Outlet]
        UIKit.UIImageView _iconImageView { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARTextField _textField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_actionButton != null) {
                _actionButton.Dispose ();
                _actionButton = null;
            }

            if (_iconImageView != null) {
                _iconImageView.Dispose ();
                _iconImageView = null;
            }

            if (_textField != null) {
                _textField.Dispose ();
                _textField = null;
            }
        }
    }
}