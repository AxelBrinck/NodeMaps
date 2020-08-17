namespace NodeMaps.Entities
{
    /// <summary>
    /// This will set a navigation mode for traversing nodes with the <see cref="NodeOperations"/> object.
    /// </summary>
    public enum NavigationMode
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