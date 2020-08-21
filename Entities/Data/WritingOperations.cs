using System.IO;
using NodeMaps.Entities.Data.Block;
using NodeMaps.Entities.Data.Block.Definitions;

namespace NodeMaps.Entities.Data
{
    
    /// <summary>
    /// Encapsulates all the writing operations.
    /// </summary>
    public class WritingOperations
    {
        private readonly BlockWriter _writer;

        /// <summary>
        /// Instantiate by providing a stream to write.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        public WritingOperations(Stream stream)
        {
            _writer = new BlockWriter(stream);
        }

        /// <summary>
        /// Writes a data block to the specified stream position.
        /// </summary>
        /// <param name="position">The stream position to write the data block.</param>
        /// <param name="dataBlock">The data block to write to the stream.</param>
        public void WriteDataBlock(long position, DataBlock dataBlock)
        {
            _writer.WriteBlock(position, dataBlock);
        }

        /// <summary>
        /// Writes a gate block to the specified stream position.
        /// </summary>
        /// <param name="position">The stream position to write the gate block.</param>
        /// <param name="gateBlock">The gate block to write to the stream.</param>
        public void WriteGateBlock(long position, GateBlock gateBlock)
        {
            _writer.WriteBlock(position, gateBlock);
        }

        /// <summary>
        /// Writes a node block to the specified stream position.
        /// </summary>
        /// <param name="position">The stream position to write the node block.</param>
        /// <param name="nodeBlock">The node block to write to the stream.</param>
        public void WriteNodeBlock(long position, NodeBlock nodeBlock)
        {
            _writer.WriteBlock(position, nodeBlock);
        }
    }
}