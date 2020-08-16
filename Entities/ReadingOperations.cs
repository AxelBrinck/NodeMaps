﻿using System.IO;
using NodeMaps.Entities.Data;

namespace NodeMaps.Entities
{
    
    /// <summary>
    /// Encapsulates all the reading operations.
    /// </summary>
    public class ReadingOperations
    {
        private readonly BlockReader _reader;

        /// <summary>
        /// Instantiate by providing a stream to read.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        public ReadingOperations(Stream stream)
        {
            _reader = new BlockReader(stream);
        }

        /// <summary>
        /// Reads a data block from the specified stream position.
        /// </summary>
        /// <param name="position">The stream position to read the data block.</param>
        /// <returns>The gathered data block from the stream.</returns>
        public DataBlock ReadDataBlock(long position)
        {
            return _reader.ReadBlock<DataBlock>(position);
        }

        /// <summary>
        /// Reads a gate block from the specified stream position.
        /// </summary>
        /// <param name="position">The stream position to read the gate block.</param>
        /// <returns>The gathered gate block from the stream.</returns>
        public GateBlock ReadGateBlock(long position)
        {
            return _reader.ReadBlock<GateBlock>(position);
        }
    }
}