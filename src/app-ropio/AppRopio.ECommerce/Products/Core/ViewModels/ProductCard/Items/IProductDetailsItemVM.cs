﻿using System;
using AppRopio.Models.Products.Responses;
using MvvmCross.Core.ViewModels;

namespace AppRopio.ECommerce.Products.Core.ViewModels.ProductCard.Items
{
    public interface IProductDetailsItemVM : IMvxViewModel, IMvxNotifyPropertyChanged
    {
        string Name { get; set; }

        ProductWidgetType WidgetType { get; set; }

        ProductDataType DataType { get; }

        ApplyedProductParameter SelectedValue { get; }

        void ClearSelectedValue();
    }
}
