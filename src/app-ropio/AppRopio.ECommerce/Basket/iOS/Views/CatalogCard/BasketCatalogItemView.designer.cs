// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.ECommerce.Basket.iOS.Views.CatalogCard
{
    [Register ("BasketCatalogItemView")]
    partial class BasketCatalogItemView
    {
        [Outlet]
        UIKit.UIButton _buyButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_buyButton != null) {
                _buyButton.Dispose ();
                _buyButton = null;
            }
        }
    }
}