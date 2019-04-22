using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppRopio.Base.Core.Attributes;
using AppRopio.Base.Core.Extentions;
using AppRopio.Base.Core.ViewModels;
using AppRopio.ECommerce.Products.Core.Messages;
using AppRopio.ECommerce.Products.Core.Models.Bundle;
using AppRopio.ECommerce.Products.Core.Services;
using AppRopio.ECommerce.Products.Core.ViewModels.ProductCard.Items;
using AppRopio.ECommerce.Products.Core.ViewModels.ProductCard.Items.ShortInfo;
using AppRopio.ECommerce.Products.Core.ViewModels.ProductCard.Services;
using AppRopio.Models.Products.Responses;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace AppRopio.ECommerce.Products.Core.ViewModels.ProductCard
{
    [Deeplink("product")]
    public class ProductCardViewModel : BaseViewModel, IProductCardViewModel
    {
        #region Fields

        #endregion

        #region Commands

        private IMvxCommand _selectionChangedCommand;
        public IMvxCommand SelectionChangedCommand => _selectionChangedCommand ?? (_selectionChangedCommand = new MvxCommand<IMvxViewModel>(OnItemSelected));

        private IMvxCommand _markCommand;
        public IMvxCommand MarkCommand => _markCommand ?? (_markCommand = new MvxCommand(OnMarkExecute));

        private IMvxCommand _shareCommand;
        public IMvxCommand ShareCommand => _shareCommand ?? (_shareCommand = new MvxCommand(OnShareExecute, () => !ShareLoading));

        #endregion

        #region Properties

        protected Product Model { get; set; }

        protected string GroupId { get; set; }

        protected string ProductId { get; set; }

        protected CancellationTokenSource DelayCTS { get; set; }

        protected CancellationTokenSource ProductParameterCTS { get; set; }

        // Retrieve value from badge to assign in to Items.
        private Items.Multiline.MultilinePciVm DiscountValueFromBadgeObject { get; set; }
        private ObservableCollection<IProductDetailsItemVM> dataSource { get; set; }

        private bool _reloadingByParameter;
        protected bool ReloadingByParameter
        {
            get => _reloadingByParameter;
            set
            {
                _reloadingByParameter = value;
                Messenger.Publish(new ProductDetailsReloadingByParameterMessage(this, value));
            }
        }

        private bool _productAvailable;
        protected bool ProductAvailable
        {
            get => _productAvailable;
            set
            {
                _productAvailable = value;
                Messenger.Publish(new ProductAvailableMessage(this, value));
            }
        }

        private MvxObservableCollection<IMvxViewModel> _items;
        public MvxObservableCollection<IMvxViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value, nameof(Items));
        }

        private bool _marked;
        public bool Marked
        {
            get => _marked;
            set => SetProperty(ref _marked, value, nameof(Marked));
        }

        private bool _markedLoading;
        public bool MarkedLoading
        {
            get => _markedLoading;
            set => SetProperty(ref _markedLoading, value, nameof(MarkedLoading));
        }

        private bool _shareLoading;
        public bool ShareLoading
        {
            get => _shareLoading;
            set => SetProperty(ref _shareLoading, value, nameof(ShareLoading));
        }

        public bool MarkEnabled { get; }


        public IMvxViewModel BasketBlockViewModel { get; protected set; }

        #endregion

        #region Services

        protected IProductCardVmService VmService => Mvx.Resolve<IProductCardVmService>();

        protected IMarkProductVmService MarkProductVmService => Mvx.Resolve<IMarkProductVmService>();

        protected IProductsNavigationVmService NavigationVmService => Mvx.Resolve<IProductsNavigationVmService>();

        protected IProductsShareVmService ShareVmService => Mvx.Resolve<IProductsShareVmService>();

        protected IProductConfigService ConfigService => Mvx.Resolve<IProductConfigService>();

        #endregion

        #region Constructor

        public ProductCardViewModel()
        {
            Items = new MvxObservableCollection<IMvxViewModel>();

            MarkEnabled = ConfigService.Config.MarkedEnabled;
        }

        #endregion

        #region Private

        private void InitProductProperties()
        {
            Marked = Model.IsMarked;

            if (BasketBlockViewModel is IMvxViewModel<IMvxBundle> parameterVM)
                parameterVM.Prepare(new ProductCardBundle(Model, Base.Core.Models.Navigation.NavigationType.InsideScreen));
            else
                BasketBlockViewModel?.Init(new ProductCardBundle(Model, Base.Core.Models.Navigation.NavigationType.InsideScreen));
        }

        private async Task LoadContent()
        {
            await LoadBasicContent();

            await LoadDetailsContent();
        }

        private async Task LoadBasicContent()
        {
            if (Model == null || (Model != null && Model.NeedsReload))
            {
                Model = await VmService.LoadProductShortInfo(GroupId, ProductId);

                InitProductProperties();
            }

            var dataSource = await VmService.LoadBasicProductCardItems(Model);

            InvokeOnMainThread(() => Items.AddRange(dataSource));
        }

        private async Task LoadDetailsContent()
        {
            Loading = true;

            var dataSource = await VmService.LoadDetailsProductCardItems(GroupId, ProductId);

            dataSource.ForEach(item => item.PropertyChanged += OnSelectedValueChanged);

            InvokeOnMainThread(() => Items.AddRange(dataSource));

            await ReloadProductByParameters();

            Loading = false;
        }

        private async void OnSelectedValueChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedValue")
                OnParameterChanged();
            //await CheckReload();
        }

        private void OnItemSelected(IMvxViewModel viewModel)
        {
            var selectableItem = viewModel as ISelectableProductCardItemVM;
            if (selectableItem != null)
                selectableItem.OnSelected();
        }

        private async Task CheckReload()
        {
            if (Model != null)//&& (Model.NeedsReload))
            {
                if (DiscountValueFromBadgeObject == null)
                    DiscountValueFromBadgeObject = (Items.Multiline.MultilinePciVm)Items[3];
                if (dataSource?.Count > 3)
                    InvokeOnMainThread(() => Items[3] = DiscountValueFromBadgeObject);
            }
        }

        private async Task ReloadProductByParameters()
        {
            var applyedParameters = Items.Where(x => x is IProductDetailsItemVM && (x as IProductDetailsItemVM).SelectedValue != null)
                                         .Select(y => (y as IProductDetailsItemVM).SelectedValue);

            if (applyedParameters == null)
            {
                ReloadingByParameter = false;
                return;
            }

            var newProductInfo = await VmService.ReloadProductByParameters(GroupId, ProductId, applyedParameters);

            await CheckReload();

            if (newProductInfo != null)
            {
                Model = newProductInfo;

                InitProductProperties();

                GroupId = Model.GroupId;
                ProductId = Model.Id;

                //TODO 
                #region Discount value copy from badge
                var newItems = await VmService.LoadBasicProductCardItems(newProductInfo);
                var _newItems = newItems as ObservableCollection<IProductBasicItemVM>;
                var discountObject = _newItems[1] as IShortInfoProductsPciVm;
                DiscountValueFromBadgeObject.Name = discountObject.Badges[0].Name;
                DiscountValueFromBadgeObject.Text = discountObject.Badges[0].Name + ", подробности при оформлении заказа";
                #endregion Discount value copy from badge

                ProductAvailable = true;

                Items.ReplaceRange(newItems, 0, Items.Count(x => x is IProductBasicItemVM));
            }
            else
                ProductAvailable = false;

            ReloadingByParameter = false;
        }

        #endregion

        #region Protected

        protected virtual void OnParameterChanged()
        {
            if (DelayCTS != null && !DelayCTS.IsCancellationRequested)
            {
                DelayCTS.Cancel();
                DelayCTS = new CancellationTokenSource();
            }

            if (ProductParameterCTS != null && !ProductParameterCTS.IsCancellationRequested)
            {
                ProductParameterCTS.Cancel();
                ProductParameterCTS = null;
            }

            try
            {
                DelayCTS = new CancellationTokenSource();

                ReloadingByParameter = true;

                Task.Run(async () =>
                {
                    try
                    {
                        //await Task.Delay(1000, DelayCTS.Token);
                        await ReloadProductByParameters();
                    }
                    catch (OperationCanceledException)
                    {

                    }
                }, DelayCTS.Token);
            }
            catch (OperationCanceledException)
            {

            }
        }

        protected virtual void OnMarkExecute()
        {
            if (!MarkedLoading)
            {
                MarkedLoading = true;
                //MarkCommand.RaiseCanExecuteChanged();

                Marked = !Marked;

                Task.Run(async () =>
                {
                    var result = await MarkProductVmService.MarkProductAsFavorite(GroupId, ProductId, Marked);
                    if (!result)
                        InvokeOnMainThread(() => Marked = !Marked);

                    InvokeOnMainThread(() =>
                    {
                        Messenger.Publish(new ProductCardMarkedMessage(this, Model, Marked));

                        MarkedLoading = false;
                        //MarkCommand.RaiseCanExecuteChanged();
                    });
                });
            }
        }

        protected virtual void OnShareExecute()
        {
            ShareLoading = true;

            ShareCommand.RaiseCanExecuteChanged();

            Task.Run(async () =>
            {
                await ShareVmService.ShareProduct(GroupId, ProductId);

                InvokeOnMainThread(() =>
                {
                    ShareLoading = false;
                    ShareCommand.RaiseCanExecuteChanged();
                });
            });
        }

        #region Init

        public override void Prepare(IMvxBundle parameter)
        {
            base.Prepare(parameter);

            var productCardBundle = parameter.ReadAs<ProductCardBundle>();
            this.InitFromBundle(productCardBundle);
        }

        protected virtual void InitFromBundle(ProductCardBundle parameters)
        {
            VmNavigationType = parameters.NavigationType == Base.Core.Models.Navigation.NavigationType.None ? Base.Core.Models.Navigation.NavigationType.Push : parameters.NavigationType;

            GroupId = parameters.Product?.GroupId ?? parameters.GroupId;
            ProductId = parameters.Product?.Id ?? parameters.ProductId;

            Model = parameters.Product;

            BasketBlockViewModel = VmService.LoadBasketBlock();

            if (Model != null)
                InitProductProperties();
        }

        #endregion

        #endregion

        #region Public

        public override Task Initialize()
        {
            return LoadContent();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            if (BasketBlockViewModel is IMvxViewModel<IMvxBundle> parameterVM)
                parameterVM.Prepare(new ProductCardBundle(Model, Base.Core.Models.Navigation.NavigationType.InsideScreen));
            else
                BasketBlockViewModel?.Init(new ProductCardBundle(Model, Base.Core.Models.Navigation.NavigationType.InsideScreen));
        }

        public override void Unbind()
        {
            (BasketBlockViewModel as IBaseViewModel)?.Unbind();

            base.Unbind();
        }

        #endregion
    }
}

