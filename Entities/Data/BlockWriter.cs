using System.IO;

namespace NodeMaps.Entities.Data
{
    /// <summary>
    /// Writes blocks to a stream in a specified position.
    /// </summary>
    public class BlockWriter
    {
        private readonly BinaryWriter _writer;
        
        /// <summary>
        /// Instantiates the writer by providing a stream to write.
        /// </summary>
        /// <param name="stream"></param>
        public BlockWriter(Stream stream)
        {
            _writer = new BinaryWriter(stream);
        }

        /// <summary>
        /// Writes a specified type of block in the specified stream's position.
        /// </summary>
        /// <param name="position">The stream position to write.</param>
        /// <param name="block">The instance of block to write.</param>
        /// <typeparam name="TBlock">The type of the provided block.</typeparam>
        public void WriteBlock<TBlock>(long position, TBlock block) where TBlock : StreamByteBlock
        {
            _writer.BaseStream.Position = position;
            block.Encode(_writer);
        }
    }
}