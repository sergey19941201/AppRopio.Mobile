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
    [Register ("DeliveryTypeCell")]
    partial class DeliveryTypeCell
    {
        [Outlet]
        UIKit.UIImageView _checkImageView { get; set; }


        [Outlet]
        UIKit.UIImageView _disclosureImageView { get; set; }


        [Outlet]
        UIKit.UIView _separatorView { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _titleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_checkImageView != null) {
                _checkImageView.Dispose ();
                _checkImageView = null;
            }

            if (_disclosureImageView != null) {
                _disclosureImageView.Dispose ();
                _disclosureImageView = null;
            }

            if (_separatorView != null) {
                _separatorView.Dispose ();
                _separatorView = null;
            }

            if (_titleLabel != null) {
                _titleLabel.Dispose ();
                _titleLabel = null;
            }
        }
    }
}