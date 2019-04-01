// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.ECommerce.Basket.iOS.Views.Basket
{
    [Register ("BasketViewController")]
    partial class BasketViewController
    {
        [Outlet]
        UIKit.UIView _bottomView { get; set; }


        [Outlet]
        UIKit.UIImageView _emptyImage { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _emptyTitle { get; set; }


        [Outlet]
        UIKit.UIView _emptyView { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _epmtyText { get; set; }


        [Outlet]
        UIKit.UIButton _goToButton { get; set; }


        [Outlet]
        UIKit.UIView _loyaltyWrapper { get; set; }


        [Outlet]
        UIKit.UIButton _nextButton { get; set; }


        [Outlet]
        UIKit.UITableView _tableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _messageLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _messageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_bottomView != null) {
                _bottomView.Dispose ();
                _bottomView = null;
            }

            if (_emptyImage != null) {
                _emptyImage.Dispose ();
                _emptyImage = null;
            }

            if (_emptyTitle != null) {
                _emptyTitle.Dispose ();
                _emptyTitle = null;
            }

            if (_emptyView != null) {
                _emptyView.Dispose ();
                _emptyView = null;
            }

            if (_epmtyText != null) {
                _epmtyText.Dispose ();
                _epmtyText = null;
            }

            if (_goToButton != null) {
                _goToButton.Dispose ();
                _goToButton = null;
            }

            if (_loyaltyWrapper != null) {
                _loyaltyWrapper.Dispose ();
                _loyaltyWrapper = null;
            }

            if (_messageLabel != null) {
                _messageLabel.Dispose ();
                _messageLabel = null;
            }

            if (_messageView != null) {
                _messageView.Dispose ();
                _messageView = null;
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