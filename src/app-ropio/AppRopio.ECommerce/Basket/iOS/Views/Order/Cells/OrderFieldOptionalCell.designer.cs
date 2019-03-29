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
    [Register ("OrderFieldOptionalCell")]
    partial class OrderFieldOptionalCell
    {
        [Outlet]
        UIKit.UIView _bottomSeparatorView { get; set; }


        [Outlet]
        UIKit.UIView _middleSeparatorView { get; set; }


        [Outlet]
        UIKit.UISwitch _switch { get; set; }


        [Outlet]
        UIKit.UITextView _textView { get; set; }


        [Outlet]
        UIKit.UIView _textViewLayout { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _titleLabel { get; set; }


        [Outlet]
        UIKit.UIView _titleLayout { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_bottomSeparatorView != null) {
                _bottomSeparatorView.Dispose ();
                _bottomSeparatorView = null;
            }

            if (_middleSeparatorView != null) {
                _middleSeparatorView.Dispose ();
                _middleSeparatorView = null;
            }

            if (_switch != null) {
                _switch.Dispose ();
                _switch = null;
            }

            if (_textView != null) {
                _textView.Dispose ();
                _textView = null;
            }

            if (_textViewLayout != null) {
                _textViewLayout.Dispose ();
                _textViewLayout = null;
            }

            if (_titleLabel != null) {
                _titleLabel.Dispose ();
                _titleLabel = null;
            }

            if (_titleLayout != null) {
                _titleLayout.Dispose ();
                _titleLayout = null;
            }
        }
    }
}