// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.Base.Filters.iOS.Views.Sort.Cells
{
    [Register ("SortCell")]
    partial class SortCell
    {
        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _name { get; set; }


        [Outlet]
        UIKit.UIImageView _selectionImageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_selectionImageView != null) {
                _selectionImageView.Dispose ();
                _selectionImageView = null;
            }
        }
    }
}