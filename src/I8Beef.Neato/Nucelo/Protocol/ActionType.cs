namespace I8Beef.Neato.Nucelo.Protocol
{
    /// <summary>
    /// Action type.
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Invalid.
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// House Cleaning.
        /// </summary>
        HouseCleaning = 1,

        /// <summary>
        /// Spot Cleaning.
        /// </summary>
        SpotCleaning = 2,

        /// <summary>
        /// Manual Cleaning.
        /// </summary>
        ManualCleaning = 3,

        /// <summary>
        /// Docking.
        /// </summary>
        Docking = 4,

        /// <summary>
        /// User Menu Active.
        /// </summary>
        UserMenuActive = 5,

        /// <summary>
        /// Suspended Cleaning.
        /// </summary>
        SuspendedCleaning = 6,

        /// <summary>
        /// Updating.
        /// </summary>
        Updating = 7,

        /// <summary>
        /// Copying Logs.
        /// </summary>
        CopyingLogs = 8,

        /// <summary>
        /// Recovering Location.
        /// </summary>
        RecoveringLocation = 9,

        /// <summary>
        /// IEC Test.
        /// </summary>
        IecTest = 10,

        /// <summary>
        /// Map cleaning.
        /// </summary>
        MapCleaning = 11,

        /// <summary>
        /// Exploring map (creating a persistent map).
        /// </summary>
        ExploringMap = 12,

        /// <summary>
        /// Acquiring Persistent Map IDs.
        /// </summary>
        AcquiringPersistentMapIds = 13,

        /// <summary>
        /// Creating & Uploading Map.
        /// </summary>
        CreatingAndUploadingMap = 14,

        /// <summary>
        /// Suspended Exploration.
        /// </summary>
        SuspendedExploration = 15
    }
}
