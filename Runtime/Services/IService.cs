namespace Studio.CoreInfra
{
    /// <summary>
    /// Base interface for all services managed by the ServiceLocator.
    /// Every module service must implement this.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Called once when the service is first registered.
        /// Use this for SDK initialization, configuration loading, etc.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Whether this service has completed initialization.
        /// </summary>
        bool IsInitialized { get; }
    }
}
