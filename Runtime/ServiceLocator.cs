using System;
using System.Collections.Generic;
using UnityEngine;

namespace Studio.CoreInfra
{
    /// <summary>
    /// A simple Service Locator pattern.
    /// The Game project registers concrete implementations at startup.
    /// Any code that depends on Core-Infra can then resolve services by interface.
    /// 
    /// Usage:
    ///   ServiceLocator.Register&lt;IAdsService&gt;(new UnityAdsService());
    ///   var ads = ServiceLocator.Get&lt;IAdsService&gt;();
    ///   ads.ShowRewarded("placement_1", rewarded => { ... });
    /// </summary>
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        /// <summary>
        /// Register a service implementation for the given interface type.
        /// Automatically calls Initialize() on the service.
        /// </summary>
        public static void Register<T>(T service) where T : IService
        {
            var type = typeof(T);

            if (_services.ContainsKey(type))
            {
                Debug.LogWarning($"[ServiceLocator] Overwriting existing service for {type.Name}");
            }

            _services[type] = service;
            service.Initialize();
            Debug.Log($"[ServiceLocator] Registered and initialized: {type.Name}");
        }

        /// <summary>
        /// Retrieve a registered service by its interface type.
        /// Throws if the service has not been registered.
        /// </summary>
        public static T Get<T>() where T : IService
        {
            var type = typeof(T);

            if (_services.TryGetValue(type, out var service))
            {
                return (T)service;
            }

            throw new InvalidOperationException(
                $"[ServiceLocator] Service not found: {type.Name}. " +
                $"Make sure to call ServiceLocator.Register<{type.Name}>() at startup.");
        }

        /// <summary>
        /// Check if a service is registered without throwing.
        /// </summary>
        public static bool Has<T>() where T : IService
        {
            return _services.ContainsKey(typeof(T));
        }

        /// <summary>
        /// Remove all registered services. Useful for testing or scene reloads.
        /// </summary>
        public static void Clear()
        {
            _services.Clear();
            Debug.Log("[ServiceLocator] All services cleared.");
        }
    }
}
