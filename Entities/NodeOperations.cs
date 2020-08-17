using System.IO;

namespace NodeMaps.Entities
{
    /// <summary>
    /// This will hold the available node operations.
    /// </summary>
    public class NodeOperations
    {
        private readonly ReadingOperations _readingOperations;
        private readonly WritingOperations _writingOperations;
        private readonly NavigationMode _mode;

        public long CurrentPosition { get; set; }

        /// <summary>
        /// Instantiate by providing a stream and a navigation mode.
        /// </summary>
        /// <param name="stream">The stream to navigate through.</param>
        /// <param name="mode">The navigation mode to apply.</param>
        public NodeOperations(Stream stream, NavigationMode mode)
        {
            _readingOperations = new ReadingOperations(stream);
            _writingOperations = new WritingOperations(stream);
            _mode = mode;
        }

        /// <summary>
        /// Returns the number of gates the current node has.
        /// </summary>
        /// <returns>The number of gates the current node has.</returns>
        public int GetGateCount()
        {
            // In order to get the number of gates this current node has:
            // We have to get the total number of gates its gate block has,
            // and subtract one, because this one represents a data stream position
            // and not a actual gate.
            return _readingOperations.ReadGateBlock(CurrentPosition).Gates.Length - 1;
        }

        /// <summary>
        /// Returns the value of an specific gate of the node.
        /// </summary>
        /// <param name="gateIdentifier">The gate in the gate block to take the value from.</param>
        /// <returns>The value from the specified gate in the gate block of the node.</returns>
        public long GetGateValue(int gateIdentifier)
        {
            // The first value of the data block represents the data stream location and not a gate.
            // So we have to avoid the data stream address by adding one to the requested gate identifier.
            return _readingOperations.ReadGateBlock(CurrentPosition).Gates[gateIdentifier + 1];
        }

        /// <summary>
        /// Gets the gate block and writes its back with a gate value changed.
        /// </summary>
        /// <param name="gateIdentifier">The gate in the gate block to change its value</param>
        /// <param name="newGateValue">The new value to set for the gate.</param>
        public void SetGateValue(int gateIdentifier, long newGateValue)
        {
            var gateBlock = _readingOperations.ReadGateBlock(CurrentPosition);
            gateBlock.Gates[gateIdentifier + 1] = newGateValue;
            _writingOperations.WriteGateBlock(CurrentPosition, gateBlock);
        }

        /// <summary>
        /// Returns whether or not the current node has data.
        /// </summary>
        /// <returns>Whether or not the current node has data.</returns>
        public bool IsThereDataReferenced()
        {
            // In order to get whether or not is data assigned to the node:
            // We have to ask the first gate in its gate block.
            // If this gate block is pointing to "-1", then there is no data assigned.
            // Otherwise will indicate us where is a data block located in the stream
            // that is related to this node.
            return _readingOperations.ReadGateBlock(CurrentPosition).Gates[0] != -1;
        }

        public void NavigateThroughReferences(int gateIdentifier)
        {
            CurrentPosition = _readingOperations.ReadGateBlock(CurrentPosition).Gates[gateIdentifier + 1];
        }
        
        public void DereferenceData()
        {
            var gateBlock = _readingOperations.ReadGateBlock(CurrentPosition);
            gateBlock.Gates[0] = -1;
            _writingOperations.WriteGateBlock(CurrentPosition, gateBlock);
        }

        public void ReferenceData(long position)
        {
            var gateBlock = _readingOperations.ReadGateBlock(CurrentPosition);
            gateBlock.Gates[0] = position;
            _writingOperations.WriteGateBlock(CurrentPosition, gateBlock);
        }
    }
}