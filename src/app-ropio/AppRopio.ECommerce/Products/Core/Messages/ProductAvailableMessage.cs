using System;
using MvvmCross.Plugins.Messenger;

namespace AppRopio.ECommerce.Products.Core.Messages
{
    public class ProductAvailableMessage : MvxMessage
    {
        public bool ProductAvailable { get; }

        public ProductAvailableMessage(object sender, bool productAvailable)
            : base(sender)
        {
            ProductAvailable = productAvailable;
        }
    }
}
