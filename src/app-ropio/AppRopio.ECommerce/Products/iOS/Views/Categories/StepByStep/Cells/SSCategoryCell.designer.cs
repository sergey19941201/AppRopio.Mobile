// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.ECommerce.Products.iOS.Views.Categories.StepByStep.Cells
{
    [Register ("SSCategoryCell")]
    partial class SSCategoryCell
    {
        [Outlet]
        UIKit.UIImageView _backgroundImage { get; set; }


        [Outlet]
        UIKit.UIView _gradientView { get; set; }


        [Outlet]
        UIKit.UIImageView _icon { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _name { get; set; }


        [Outlet]
        UIKit.NSLayoutConstraint _stackViewHeight { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_backgroundImage != null) {
                _backgroundImage.Dispose ();
                _backgroundImage = null;
            }

            if (_gradientView != null) {
                _gradientView.Dispose ();
                _gradientView = null;
            }

            if (_icon != null) {
                _icon.Dispose ();
                _icon = null;
            }

            if (_name != null) {
                _name.Dispose ();
                _name = null;
            }

            if (_stackViewHeight != null) {
                _stackViewHeight.Dispose ();
                _stackViewHeight = null;
            }
        }
    }
}