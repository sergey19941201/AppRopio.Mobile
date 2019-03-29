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
    [Register ("DeliveryOnAddressVC")]
    partial class DeliveryOnAddressVC
    {
        [Outlet]
        UIKit.UIView _bottomView { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _deliveryPriceLabel { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _deliveryPriceTitle { get; set; }


        [Outlet]
        UIKit.UIButton _nextButton { get; set; }


        [Outlet]
        UIKit.UITableView _tableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_bottomView != null) {
                _bottomView.Dispose ();
                _bottomView = null;
            }

            if (_deliveryPriceLabel != null) {
                _deliveryPriceLabel.Dispose ();
                _deliveryPriceLabel = null;
            }

            if (_deliveryPriceTitle != null) {
                _deliveryPriceTitle.Dispose ();
                _deliveryPriceTitle = null;
            }

            if (_nextButton != null) {
                _nextButton.Dispose ();
                _nextButton = null;
            }

            if (_tableView != null) {
                _tableView.Dispose ();
                _tableView = null;
            }
        }
    }
}