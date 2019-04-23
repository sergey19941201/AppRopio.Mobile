// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.Base.Filters.iOS.Views.Filters
{
    [Register ("FiltersViewController")]
    partial class FiltersViewController
    {
        [Outlet]
        UIKit.UIButton _applyBtn { get; set; }


        [Outlet]
        UIKit.UITableView _tableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_applyBtn != null) {
                _applyBtn.Dispose ();
                _applyBtn = null;
            }

            if (_tableView != null) {
                _tableView.Dispose ();
                _tableView = null;
            }
        }
    }
}