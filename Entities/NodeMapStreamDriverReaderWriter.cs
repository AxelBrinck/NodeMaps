using System.IO;

namespace NodeMaps.Entities
{
    /// <summary>
    /// Provides writing functions to create and/or modify a NodeMap-formatted stream.
    /// </summary>
    public class NodeMapStreamReaderWriter : NodeMapStreamReader
    {
        private readonly BinaryWriter _streamWriter;

        private const long UndefinedStreamPosition = 0;

        /// <summary>
        /// Constructs the writer providing a stream.
        /// </summary>
        /// <param name="stream">The provided stream.</param>
        public NodeMapStreamReaderWriter(Stream stream) : base(stream)
        {
            _streamWriter = new BinaryWriter(stream);
        }

        /// <summary>
        /// Creates an empty header in the stream with a given number of disabled links and data pointer.
        /// All the links as well as the data pointer will target <see cref="UndefinedStreamPosition"/>.
        /// </summary>
        /// <param name="linkCount">The number of initial disabled links this header will have.</param>
        /// <returns>The stream position of the newly-created header.</returns>
        public long WriteNewHeaderAndGetItsStreamPosition(int linkCount)
        {
            var headerAddress = _streamWriter.BaseStream.Length;
            
            _streamWriter.BaseStream.Position = headerAddress;
            
            _streamWriter.Write(UndefinedStreamPosition);
            _streamWriter.Write(linkCount);
            
            for (var i = 0; i < linkCount; i++)
                _streamWriter.Write(UndefinedStreamPosition);

            return headerAddress;
        }

        /// <summary>
        /// Writes the provided buffer into the stream representing data.
        /// The stream position where the data is written will be returned.
        /// </summary>
        /// <param name="buffer">The byte array to write.</param>
        /// <returns>The stream position where the data has been written.</returns>
        public long WriteNewDataAndGetItsStreamPosition(byte[] buffer)
        {
            var dataAddress = _streamWriter.BaseStream.Length;
            
            _streamWriter.BaseStream.Position = dataAddress;
            
            _streamWriter.Write(buffer.Length);
            _streamWriter.Write(buffer);
            
            return dataAddress;
        }
    }
}