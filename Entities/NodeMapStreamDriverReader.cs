using System.IO;

namespace NodeMaps.Entities
{
    /// <summary>
    /// Provides reading functions to a NodeMap-formatted stream.
    /// </summary>
    public class NodeMapStreamReader
    {
        private readonly BinaryReader _streamReader;

        /// <summary>
        /// Constructs the reader by providing a stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        public NodeMapStreamReader(Stream stream)
        {
            _streamReader = new BinaryReader(stream);
        }

        /// <summary>
        /// Gets the stream position of the data.
        /// Returns -1 if there is no data assigned.
        /// </summary>
        /// <param name="headerStreamPosition">The stream position of an existing header.</param>
        /// <returns>The location of the data in the stream.</returns>
        public long GetDataStreamPosition(long headerStreamPosition)
        {
            _streamReader.BaseStream.Position = headerStreamPosition;
            return _streamReader.ReadInt64();
        }

        /// <summary>
        /// Gets the number of links a given header has.
        /// </summary>
        /// <param name="headerStreamPosition">The stream position of an existing header.</param>
        /// <returns>The number of links this header has.</returns>
        public int GetLinkCount(long headerStreamPosition)
        {
            _streamReader.BaseStream.Position = headerStreamPosition;
            _streamReader.BaseStream.Seek(sizeof(long), SeekOrigin.Current);
            return _streamReader.ReadInt32();
        }

        /// <summary>
        /// Gets the the value of an specified link from an specified header.
        /// </summary>
        /// <param name="headerStreamPosition">The header that has the link to get the value.</param>
        /// <param name="linkId">The number that identifies the link from the header's link array.</param>
        /// <returns>The link value.</returns>
        public long GetReferenceTarget(long headerStreamPosition, int linkId)
        {
            _streamReader.BaseStream.Position = headerStreamPosition;
            _streamReader.BaseStream.Seek(sizeof(long) + sizeof(int) + sizeof(int) * linkId, SeekOrigin.Current);
            return _streamReader.ReadInt64();
        }

        /// <summary>
        /// Retrieves the byte array located in a given stream position.
        /// </summary>
        /// <param name="dataStreamPosition">The stream position to gather the data.</param>
        /// <returns>The byte array representing the data.</returns>
        public byte[] GetData(long dataStreamPosition)
        {
            _streamReader.BaseStream.Position = dataStreamPosition;
            return _streamReader.ReadBytes(_streamReader.ReadInt32());
        }
    }
}