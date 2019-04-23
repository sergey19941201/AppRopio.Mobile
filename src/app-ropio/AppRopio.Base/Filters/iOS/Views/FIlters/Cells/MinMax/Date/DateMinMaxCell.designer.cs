// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.Base.Filters.iOS.Views.Filters.Cells.MinMax.Date
{
    [Register ("DateMinMaxCell")]
    partial class DateMinMaxCell
    {
        [Outlet]
        UIKit.UIView _bottomSeparator { get; set; }

        [Outlet]
        UIKit.UITextField _fromField { get; set; }

        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _fromLabel { get; set; }

        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _name { get; set; }

        [Outlet]
        UIKit.UITextField _toField { get; set; }

        [Outlet]
        AppRopio.Base.iOS.Controls.ARLabel _toLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_bottomSeparator != null) {
                _bottomSeparator.Dispose ();
                _bottomSeparator = null;
            }

            if (_fromField != null) {
                _fromField.Dispose ();
                _fromField = null;
            }

            if (_toField != null) {
                _toField.Dispose ();
                _toField = null;
            }
        }
    }
}