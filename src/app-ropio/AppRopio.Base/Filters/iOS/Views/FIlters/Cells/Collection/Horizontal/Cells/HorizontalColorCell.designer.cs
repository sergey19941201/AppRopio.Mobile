// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AppRopio.Base.Filters.iOS.Views.Filters.Cells.Collection.Horizontal.Cells
{
    [Register("HorizontalColorCell")]
    partial class HorizontalColorCell
    {
        [Outlet]
        UIKit.UIView _colorView { get; set; }

        [Outlet]
        UIKit.UIView _selectedView { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (_colorView != null)
            {
                _colorView.Dispose();
                _colorView = null;
            }

            if (_selectedView != null)
            {
                _selectedView.Dispose();
                _selectedView = null;
            }
        }
    }
}
