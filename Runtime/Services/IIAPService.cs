using System;

namespace Studio.CoreInfra
{
    /// <summary>
    /// Contract for any In-App Purchase service implementation.
    /// Modules like Module-IAP implement this interface.
    /// </summary>
    public interface IIAPService : IService
    {
        /// <summary>
        /// Fetch available products from the store.
        /// </summary>
        void FetchProducts(Action<ProductInfo[]> onFetched);

        /// <summary>
        /// Initiate a purchase for the given product ID.
        /// </summary>
        void Purchase(string productId, Action<bool> onComplete);

        /// <summary>
        /// Restore previously purchased products (iOS requirement).
        /// </summary>
        void RestorePurchases(Action<bool> onComplete);
    }

    /// <summary>
    /// Represents a purchasable product from the store.
    /// </summary>
    [Serializable]
    public class ProductInfo
    {
        public string ProductId;
        public string Title;
        public string Description;
        public string FormattedPrice;
    }
}
