// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.Base.Filters.iOS.Views.Filters.Cells.Collection.Horizontal.Cells
{
    [Register ("HorizontalTextCell")]
    partial class HorizontalTextCell
    {
        [Outlet]
        UIKit.UIView _colorView { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _valueName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_colorView != null) {
                _colorView.Dispose ();
                _colorView = null;
            }
        }
    }
}