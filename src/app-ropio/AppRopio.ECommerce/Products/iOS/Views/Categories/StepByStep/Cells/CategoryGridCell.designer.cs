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
    [Register ("CategoryGridCell")]
    partial class CategoryGridCell
    {
        [Outlet]
        UIKit.UIImageView _backgroundImage { get; set; }


        [Outlet]
        UIKit.UIView _gradientView { get; set; }


        [Outlet]
        UIKit.UIImageView _image { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _name { get; set; }


        [Outlet]
        UIKit.UIView _separator { get; set; }

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

            if (_image != null) {
                _image.Dispose ();
                _image = null;
            }

            if (_name != null) {
                _name.Dispose ();
                _name = null;
            }

            if (_separator != null) {
                _separator.Dispose ();
                _separator = null;
            }
        }
    }
}