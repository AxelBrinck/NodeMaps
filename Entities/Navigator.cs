using System;
using System.IO;
using NodeMaps.Entities.Data;
using NodeMaps.Entities.Data.Block.Definitions;

namespace NodeMaps.Entities
{
    public class Navigator
    {
        private readonly Stream _stream;
        private readonly ReadingOperations _readingOperations;
        private readonly WritingOperations _writingOperations;
        private readonly AccessPermission _permission;
        
        private long[] Gates { get; set; }

        public long[] Portals => Gates[1..];

        public long DataLocation => Gates[0];
        
        public long CurrentPosition { get; set; }
        
        /// <summary>
        /// Instantiate the navigator with a given stream and an <see cref="AccessPermission"/>.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="permission">The access permission.</param>
        public Navigator(Stream stream, AccessPermission permission)
        {
            _stream = stream;
            _readingOperations = new ReadingOperations(stream);
            _writingOperations = new WritingOperations(stream);
            _permission = permission;
            Read(0);
        }
        
        /// <summary>
        /// Sets a stream position as a destination to an specified portal.
        /// </summary>
        /// <param name="portalId">The portal ID to modify its stream position destination.</param>
        /// <param name="position">The stream position to add as portal destination.</param>
        /// <exception cref="InvalidOperationException">Thrown when there is no write permission.</exception>
        public void SetPortalDestination(int portalId, long position)
        {
            if (_permission == AccessPermission.Read) throw new InvalidOperationException("File is read only.");

            Gates[portalId + 1] = position;
            
            _writingOperations.WriteGateBlock(CurrentPosition, new GateBlock(Gates));
        }
        
        /// <summary>
        /// Navigates to another node specifying a portal.
        /// </summary>
        /// <param name="portalId">The portal Id that holds a stream position to navigate to.</param>
        public void Navigate(int portalId)
        {
            Read(Portals[portalId]);
        }
        
        /// <summary>
        /// Gets the data that this node holds.
        /// Returns null if there is no data block referenced.
        /// </summary>
        /// <returns>A byte array representing the data, or null if there is no data block referenced.</returns>
        public byte[] GetData()
        {
            return _readingOperations.ReadDataBlock(DataLocation).Data;
        }

        /// <summary>
        /// Sets the data to this node. If data is null, the data location will be -1.
        /// If the data is not null, it will be appended to the stream. Its location will be the new value for
        /// the data location.
        /// </summary>
        /// <param name="data">The data to write.</param>
        /// <exception cref="InvalidOperationException">Thrown when there is no write permission.</exception>
        public void SetData(byte[] data)
        {
            if (_permission == AccessPermission.Read) throw new InvalidOperationException("File is read only.");
            
            var dataLocation = data == null ? -1 : _stream.Length;

            if (dataLocation == _stream.Length)
            {
                _writingOperations.WriteDataBlock(dataLocation, new DataBlock(data));
            }

            Gates[0] = dataLocation;
            
            _writingOperations.WriteGateBlock(CurrentPosition, new GateBlock(Gates));
        }

        /// <summary>
        /// Reads a gate block from the underlying stream.
        /// Extracts its data location and portals.
        /// </summary>
        /// <param name="position">The stream position to read the gate block.</param>
        private void Read(long position)
        {
            Gates = _readingOperations.ReadGateBlock(position).Gates;
            CurrentPosition = position;
        }
    }
}