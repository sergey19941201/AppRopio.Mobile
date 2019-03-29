using System;
using AppRopio.Base.iOS;
using AppRopio.ECommerce.Products.Core.ViewModels.Catalog.Items;
using AppRopio.ECommerce.Products.iOS.Models;
using AppRopio.ECommerce.Products.iOS.Services;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform;
using UIKit;

namespace AppRopio.ECommerce.Products.iOS.Views.Catalog.Cells
{
    public partial class BadgeCell : MvxCollectionViewCell
    {
        protected ProductsThemeConfig ThemeConfig { get { return Mvx.Resolve<IProductsThemeConfigService>().ThemeConfig; } }

        public const float WIDTH = 50f;
        public const float HEIGHT = 24f;
        public static nfloat textWidth, textHeight;


        public static readonly NSString Key = new NSString("BadgeCell");
        public static readonly UINib Nib;

        static BadgeCell()
        {
            Nib = UINib.FromName("BadgeCell", NSBundle.MainBundle);
        }

        protected BadgeCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                InitializeControls();
                BindControls();
            });
        }

        public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes(UICollectionViewLayoutAttributes layoutAttributes)
        {
            var autoLayoutAttributes = base.PreferredLayoutAttributesFittingAttributes(layoutAttributes);
            var targetSize = new CGSize(width: layoutAttributes.Frame.Width, height: 0);
            var autoLayoutSize = ContentView.SystemLayoutSizeFittingSize(targetSize, (float)UILayoutPriority.Required, (float)UILayoutPriority.DefaultLow);
            var autoLayoutFrame = new CGRect(0, 0, textWidth, textHeight);
            autoLayoutAttributes.Frame = autoLayoutFrame;
            return autoLayoutAttributes;
        }

        #region InitializationControls

        protected virtual void InitializeControls()
        {
            SetupBadge(_badgeView, _badge);
        }

        protected virtual void SetupBadge(UIView badgeView, UILabel badgeName)
        {
            badgeView.Layer.SetupStyle(ThemeConfig.Products.ProductCell.Badge.Layer);
            // TODO
            if (badgeName != null)
            {
                ;
                //badgeView.ContentMode.
                badgeView.ClipsToBounds = true;
                badgeView.SizeToFit();
                textWidth = badgeView.Frame.Width;//new NSAttributedString(/*badgeName.Text*/"salesale").Size.Width;
                textHeight = new NSAttributedString(/*badgeName.Text*/"salesale").Size.Height;
            }
            badgeView.Layer.CornerRadius = 8;
            badgeName.SetupStyle(ThemeConfig.Products.ProductCell.Badge);
        }

        #endregion

        #region BindingControls

        protected virtual void BindControls()
        {
            var set = this.CreateBindingSet<BadgeCell, IProductBadgeItemVM>();

            BindBadge(_badgeView, _badge, set);

            set.Apply();
        }

        protected virtual void BindBadge(UIView badge, UILabel badgeName, MvxFluentBindingDescriptionSet<BadgeCell, IProductBadgeItemVM> set)
        {
            set.Bind(badge).For("Visibility").To(vm => vm.Name).WithConversion("Visibility");
            set.Bind(badge).For(b => b.BackgroundColor).To(vm => vm.Color).WithConversion("Color");
            set.Bind(badgeName).To(vm => vm.Name);
        }

        #endregion
    }
}
