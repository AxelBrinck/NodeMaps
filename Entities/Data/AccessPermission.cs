namespace NodeMaps.Entities.Data
{
    /// <summary>
    /// This will set a navigation mode for traversing nodes with the <see cref="NodeMapManager"/> object.
    /// </summary>
    public enum AccessPermission
    {
        /// <summary>
        /// Will only enable reading without any modification capability.
        /// </summary>
        Read,
        
        /// <summary>
        /// Will be able to read and write nodes.
        /// </summary>
        ReadWrite
    }
}