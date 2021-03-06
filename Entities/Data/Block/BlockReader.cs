﻿using System.IO;

namespace NodeMaps.Entities.Data.Block
{
    /// <summary>
    /// Reads stream blocks from a given stream and position.
    /// </summary>
    public class BlockReader
    {
        private readonly BinaryReader _sourceStream;
        
        /// <summary>
        /// Instantiates the reader by providing a stream to read.
        /// </summary>
        /// <param name="stream">The stream to read</param>
        public BlockReader(Stream stream)
        {
            _sourceStream = new BinaryReader(stream);
        }

        /// <summary>
        /// Reads a block from the stream by providing a position and a block type.
        /// </summary>
        /// <param name="position">The position in the stream to seek.</param>
        /// <typeparam name="TBlock">The type of block to read.</typeparam>
        /// <returns>Returns a block with the data decoded or deserialized from the stream.</returns>
        public TBlock ReadBlock<TBlock>(long position) where TBlock : Block, new()
        {
            _sourceStream.BaseStream.Position = position;
            var block = new TBlock();
            block.DecodeFromStream(_sourceStream);
            return block;
        }
    }
}