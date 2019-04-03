using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AppRopio.Base.Core;
using AppRopio.Base.Core.Converters;
using AppRopio.Base.Core.Services.ViewLookup;
using AppRopio.Base.iOS;
using AppRopio.Base.iOS.UIExtentions;
using AppRopio.Base.iOS.Views;
using AppRopio.ECommerce.Basket.Core;
using AppRopio.ECommerce.Basket.Core.Services;
using AppRopio.ECommerce.Basket.Core.ViewModels;
using AppRopio.ECommerce.Basket.iOS.Services;
using AppRopio.ECommerce.Basket.iOS.Views.Basket.Cells;
using CoreText;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using UIKit;

namespace AppRopio.ECommerce.Basket.iOS.Views.Basket
{
    public partial class BasketViewController : CommonViewController<IBasketViewModel>
    {
        protected Models.Basket BasketTheme { get { return Mvx.Resolve<IBasketThemeConfigService>().ThemeConfig.Basket; } }

        public BasketViewController()
            : base("BasketViewController", null)
        {

        }

        #region CommonViewController implementation

        protected override void InitializeControls()
        {
            Title = LocalizationService.GetLocalizableString(BasketConstants.RESX_NAME, "Basket_Title");

            RegisterKeyboardActions = true;

            SetupTableView(_tableView);
            SetupNextButton(_nextButton);
            SetupEmptyView(_emptyView, _emptyImage, _emptyTitle, _epmtyText, _goToButton);
            SetupBottomView(_bottomView);
        }



        protected override void BindControls()
        {
            var set = this.CreateBindingSet<BasketViewController, IBasketViewModel>();

            BindTableView(_tableView, set);
            BindNextButton(_nextButton, set);
            BindEmptyView(_emptyView, _goToButton, set);
            BindBottomView(_bottomView, set);
            BindMessage(_messageLabel, _messageView, set);

            if (_loyaltyWrapper.Subviews.Any())
                BindLoyaltyWrapper(_loyaltyWrapper, set);

            set.Apply();
        }

        protected override void CleanUp()
        {
            ReleaseDesignerOutlets();
        }

        #endregion

        #region Discount

        private void HideLargeDisplayMode()
        {
            AutomaticallyLargeTitleDisplayMode = false;
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;
        }

        #endregion

        #region InitializationControls

        protected virtual void SetupBottomView(UIView view)
        {
            view.SetupStyle(BasketTheme.BottomView);
        }

        protected virtual void SetupTableView(UITableView tableView)
        {
            tableView.TableHeaderView = new UIView();
            tableView.TableFooterView = new UIView();

            tableView.RowHeight = BasketTheme.Cell.Size.Height ?? 120;
            tableView.SeparatorColor = (UIColor)Theme.ColorPalette.Separator;
        }

        protected virtual void SetupNextButton(UIButton nextButton)
        {
            nextButton.SetupStyle(BasketTheme.NextButton);
        }

        protected virtual void SetupEmptyView(UIView emptyView, UIImageView emptyImage, UILabel emptyTitle, UILabel emptyText, UIButton goToButton)
        {
            emptyView.Hidden = true;
            emptyView.BackgroundColor = BasketTheme.EmptyView.Background.ToUIColor();

            emptyImage.SetupStyle(BasketTheme.EmptyView.Image);
            emptyTitle.SetupStyle(BasketTheme.EmptyView.Title);
            emptyText.SetupStyle(BasketTheme.EmptyView.Text);

            goToButton.SetupStyle(BasketTheme.EmptyView.CatalogButton);

            emptyTitle.Text = LocalizationService.GetLocalizableString(BasketConstants.RESX_NAME, "Basket_EmptyTitle");
            emptyText.Text = LocalizationService.GetLocalizableString(BasketConstants.RESX_NAME, "Basket_EmptyText");
            goToButton.WithTitleForAllStates(LocalizationService.GetLocalizableString(BasketConstants.RESX_NAME, "Basket_EmptyButton"));
        }

        protected virtual void ResolveAndSetupLoyalty(UIView loyaltyWrapper)
        {
            var config = Mvx.Resolve<IBasketConfigService>().Config;
            if (config.Loyalty != null && Mvx.Resolve<IViewLookupService>().IsRegistered(config.Loyalty.TypeName))
            {
                var loyaltyView = ViewModel.LoyaltyVm == null ? null : Mvx.Resolve<IMvxIosViewCreator>().CreateView(ViewModel.LoyaltyVm) as UIView;
                if (loyaltyView != null)
                {
                    loyaltyWrapper.Hidden = false;
                    loyaltyWrapper.AddSubviewWithFill(loyaltyView);
                    View.UpdateConstraints();
                }
            }
        }

        #endregion

        #region BindingControls

        protected virtual BasketTableSource SetupTableViewDataSource(UITableView tableView)
        {
            return new BasketTableSource(tableView, BasketCell.Key, BasketCell.Key);
        }

        protected virtual void BindTableView(UITableView tableView, MvxFluentBindingDescriptionSet<BasketViewController, IBasketViewModel> set)
        {
            var dataSource = SetupTableViewDataSource(tableView);

            set.Bind(dataSource).To(vm => vm.Items);
            set.Bind(dataSource).For(s => s.SelectionChangedCommand).To(vm => vm.SelectionChangedCommand);
            set.Bind(dataSource).For(s => s.DeleteItemCommand).To(vm => vm.DeleteItemCommand);

            set.Bind(tableView).For("Visibility").To(vm => vm.Items.Count).WithConversion("Visibility");

            tableView.Source = dataSource;
            tableView.ReloadData();
        }

        private void BindMessage(UILabel label, UIView view, MvxFluentBindingDescriptionSet<BasketViewController, IBasketViewModel> set)
        {
            HideLargeDisplayMode();
            //_StackTopConstraint.Constant = this.NavigationController.NavigationBar.Frame.Size.Height + UIApplication.SharedApplication.StatusBarFrame.Size.Height;
            set.Bind(label).For(v => v.AttributedText).To(vm => vm.Message)
                   .WithConversion(new StringFormatParameterATTTTTTTR());

            set.Bind(view).For("Visibility").To(vm => vm.Message).WithConversion("Visibility");
            ResolveAndSetupLoyalty(_loyaltyWrapper);
        }



        protected virtual void BindNextButton(UIButton nextButton, MvxFluentBindingDescriptionSet<BasketViewController, IBasketViewModel> set)
        {
            set.Bind(nextButton)
               .For("Title")
               .To(vm => vm.Amount)
               .WithConversion(
                   "StringFormat",
                   new StringFormatParameter
                   {
                       StringFormat = (arg) =>
                        {
                            var str = $"{LocalizationService.GetLocalizableString(BasketConstants.RESX_NAME, "Basket_OrderBy")} {((decimal)arg).ToString(AppSettings.CurrencyFormat, AppSettings.SettingsCulture.NumberFormat)}";
                            return BasketTheme.NextButton.UppercaseTitle ? str.ToUpperInvariant() : str;
                        }
                   });

            set.Bind(nextButton).To(vm => vm.NextCommand);
            set.Bind(nextButton).For(s => s.Enabled).To(vm => vm.CanGoNext);

            set.Bind(nextButton).For("Visibility").To(vm => vm.Items.Count).WithConversion("Visibility");
        }

        protected virtual void BindBottomView(UIView bottomView, MvxFluentBindingDescriptionSet<BasketViewController, IBasketViewModel> set)
        {
            set.Bind(bottomView).For("Visibility").To(vm => vm.Items.Count).WithConversion("Visibility");
        }

        protected virtual void BindEmptyView(UIView emptyView, UIButton goToButton, MvxFluentBindingDescriptionSet<BasketViewController, IBasketViewModel> set)
        {
            set.Bind(emptyView).For("Visibility").To(vm => vm.IsEmpty).WithConversion("Visibility");
            set.Bind(goToButton).To(vm => vm.CatalogCommand);
        }

        protected virtual void BindLoyaltyWrapper(UIView loyaltyWrapper, MvxFluentBindingDescriptionSet<BasketViewController, IBasketViewModel> set)
        {
            set.Bind(loyaltyWrapper).For("Visibility").To(vm => vm.Items.Count).WithConversion("Visibility");
        }

        #endregion
    }

    public class StringFormatParameterATTTTTTTR : MvxValueConverter<string, NSMutableAttributedString>
    {
        protected override NSMutableAttributedString Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var BoldString = new NSMutableAttributedString(value);

            var BoldTextAttributes = new UIStringAttributes
            {
                Font = UIFont.FromName("Helvetica-Bold", 17f)
            };

            var discountStartIndexes = ekfkkefkfke.AllIndexesOf(value.ToLower(), "скидка");

            for (int i = 0; i < discountStartIndexes.Count; i++)
            {
                var currentIndex = discountStartIndexes[i];
                for (int y = currentIndex; y < value.Length; y++)
                {
                    if (value[y] == '%')
                    {
                        BoldString.SetAttributes(BoldTextAttributes.Dictionary, new NSRange(currentIndex, y - currentIndex + 1));
                        break;
                    }
                }
            }

            return BoldString;
        }
    }

    public static class ekfkkefkfke
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}

