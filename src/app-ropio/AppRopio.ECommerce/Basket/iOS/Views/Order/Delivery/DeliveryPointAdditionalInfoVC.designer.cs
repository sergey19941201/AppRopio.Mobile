// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.ECommerce.Basket.iOS.Views.Order.Delivery
{
    [Register ("DeliveryPointAdditionalInfoVC")]
    partial class DeliveryPointAdditionalInfoVC
    {
        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _addressLabel { get; set; }


        [Outlet]
        UIKit.UIImageView _distanceImageView { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _distanceLabel { get; set; }


        [Outlet]
        UIKit.UIStackView _distanceView { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _infoLabel { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _titleLabel { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _workTimeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_addressLabel != null) {
                _addressLabel.Dispose ();
                _addressLabel = null;
            }

            if (_distanceImageView != null) {
                _distanceImageView.Dispose ();
                _distanceImageView = null;
            }

            if (_distanceLabel != null) {
                _distanceLabel.Dispose ();
                _distanceLabel = null;
            }

            if (_distanceView != null) {
                _distanceView.Dispose ();
                _distanceView = null;
            }

            if (_infoLabel != null) {
                _infoLabel.Dispose ();
                _infoLabel = null;
            }

            if (_titleLabel != null) {
                _titleLabel.Dispose ();
                _titleLabel = null;
            }

            if (_workTimeLabel != null) {
                _workTimeLabel.Dispose ();
                _workTimeLabel = null;
            }
        }
    }
}