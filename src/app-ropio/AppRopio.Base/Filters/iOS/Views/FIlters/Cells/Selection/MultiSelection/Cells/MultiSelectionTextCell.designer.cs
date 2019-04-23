// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.Base.Filters.iOS.Views.FIlters.Cells.Selection.MultiSelection.Cells
{
    [Register ("MultiSelectionTextCell")]
    partial class MultiSelectionTextCell
    {
        [Outlet]
        UIKit.UIImageView _crossImageView { get; set; }


        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _name { get; set; }


        [Outlet]
        UIKit.UIView _selectedView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_crossImageView != null) {
                _crossImageView.Dispose ();
                _crossImageView = null;
            }

            if (_selectedView != null) {
                _selectedView.Dispose ();
                _selectedView = null;
            }
        }
    }
}