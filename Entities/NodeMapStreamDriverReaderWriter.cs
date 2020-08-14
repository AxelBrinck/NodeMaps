using System.IO;

namespace NodeMaps.Entities
{
    /// <summary>
    /// Provides writing functions to create and/or modify a NodeMap-formatted stream.
    /// </summary>
    public class NodeMapStreamReaderWriter : NodeMapStreamReader
    {
        private readonly StreamWriter _streamWriter;
        
        /// <summary>
        /// Constructs the writer providing a stream.
        /// </summary>
        /// <param name="stream">The provided stream.</param>
        public NodeMapStreamReaderWriter(Stream stream) : base(stream)
        {
            _streamWriter = new StreamWriter(stream);
        }

        /// <summary>
        /// Creates an empty header in the stream with a given number of disabled links (pointing to -1).
        /// </summary>
        /// <param name="linkCount">The number of initial disabled links this header will have.</param>
        /// <returns>The stream position of the newly-created header.</returns>
        public long CreateHeader(int linkCount)
        {
            var headerAddress = _streamWriter.BaseStream.Length;
            
            _streamWriter.BaseStream.Position = headerAddress;
            
            _streamWriter.Write((long) -1);
            _streamWriter.Write(linkCount);
            
            for (var i = 0; i < linkCount; i++)
                _streamWriter.Write((long) -1);

            return headerAddress;
        }
    }
}