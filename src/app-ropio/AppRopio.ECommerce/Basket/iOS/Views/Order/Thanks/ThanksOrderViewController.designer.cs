// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.ECommerce.Basket.iOS.Views.Order.Thanks
{
    [Register ("ThanksOrderViewController")]
    partial class ThanksOrderViewController
    {
        [Outlet]
        UIKit.UIImageView _image { get; set; }


        [Outlet]
        UIKit.UIButton CatalogButton { get; set; }


        [Outlet]
        UIKit.UIButton CloseButton { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel ContinueLabel { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel OrderNumberLabel { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel TitleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_image != null) {
                _image.Dispose ();
                _image = null;
            }

            if (CatalogButton != null) {
                CatalogButton.Dispose ();
                CatalogButton = null;
            }

            if (CloseButton != null) {
                CloseButton.Dispose ();
                CloseButton = null;
            }

            if (ContinueLabel != null) {
                ContinueLabel.Dispose ();
                ContinueLabel = null;
            }

            if (OrderNumberLabel != null) {
                OrderNumberLabel.Dispose ();
                OrderNumberLabel = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }
        }
    }
}