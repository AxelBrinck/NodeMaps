using System;
using System.IO;

namespace NodeMaps.Entities
{
    /// <summary>
    /// This will hold the available node operations.
    /// </summary>
    public class NodeMapManager
    {
        private readonly ReadingOperations _readingOperations;
        private readonly WritingOperations _writingOperations;
        private readonly AccessPermission _mode;

        public long CurrentPosition { get; set; }

        /// <summary>
        /// Instantiate by providing a stream and a navigation mode.
        /// </summary>
        /// <param name="stream">The stream to navigate through.</param>
        /// <param name="mode">The navigation mode to apply.</param>
        public NodeMapManager(Stream stream, AccessPermission mode)
        {
            _readingOperations = new ReadingOperations(stream);
            _writingOperations = new WritingOperations(stream);
            _mode = mode;
        }
    }
}