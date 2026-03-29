using System;

namespace Studio.CoreInfra
{
    /// <summary>
    /// Contract for any Ads service implementation.
    /// Modules like Module-Ads implement this interface.
    /// The Game project consumes it via the ServiceLocator.
    /// </summary>
    public interface IAdsService : IService
    {
        /// <summary>
        /// Load a banner ad at the specified placement.
        /// </summary>
        void LoadBanner(string placementId);

        /// <summary>
        /// Show an interstitial ad. Invokes the callback on completion.
        /// </summary>
        void ShowInterstitial(string placementId, Action<bool> onComplete);

        /// <summary>
        /// Show a rewarded video ad. Invokes the callback with reward status.
        /// </summary>
        void ShowRewarded(string placementId, Action<bool> onRewarded);

        /// <summary>
        /// Whether a rewarded ad is currently loaded and ready to show.
        /// </summary>
        bool IsRewardedReady(string placementId);
    }
}
