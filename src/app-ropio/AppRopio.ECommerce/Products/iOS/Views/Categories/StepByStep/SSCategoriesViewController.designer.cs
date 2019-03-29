// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.ECommerce.Products.iOS.Views.Categories.StepByStep
{
    [Register ("SSCategoriesViewController")]
    partial class SSCategoriesViewController
    {
        [Outlet]
        UIKit.UICollectionView _bottomCollection { get; set; }


        [Outlet]
        UIKit.UICollectionView _collectionView { get; set; }


        [Outlet]
        UIKit.UISearchBar _searchBar { get; set; }


        [Outlet]
        UIKit.UIButton _searchButton { get; set; }


        [Outlet]
        UIKit.UIView _searchView { get; set; }


        [Outlet]
        UIKit.UIStackView _stackView { get; set; }


        [Outlet]
        UIKit.UITableView _tableView { get; set; }


        [Outlet]
        UIKit.UICollectionView _topCollection { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_bottomCollection != null) {
                _bottomCollection.Dispose ();
                _bottomCollection = null;
            }

            if (_collectionView != null) {
                _collectionView.Dispose ();
                _collectionView = null;
            }

            if (_searchBar != null) {
                _searchBar.Dispose ();
                _searchBar = null;
            }

            if (_searchButton != null) {
                _searchButton.Dispose ();
                _searchButton = null;
            }

            if (_searchView != null) {
                _searchView.Dispose ();
                _searchView = null;
            }

            if (_stackView != null) {
                _stackView.Dispose ();
                _stackView = null;
            }

            if (_tableView != null) {
                _tableView.Dispose ();
                _tableView = null;
            }

            if (_topCollection != null) {
                _topCollection.Dispose ();
                _topCollection = null;
            }
        }
    }
}