using System.IO;

namespace NodeMaps.Entities
{
    public class NodeMapStreamReader
    {
        private readonly BinaryReader _streamReader;

        public long HeaderPosition => _streamReader.BaseStream.Position;

        public NodeMapStreamReader(Stream streamBase)
        {
            _streamReader = new BinaryReader(streamBase);
        }

        public DataAddress GetDataAddress()
        {
            var headerAddress = HeaderPosition;
            var dataAddress = _streamReader.ReadInt64();
            _streamReader.BaseStream.Position = headerAddress;
            return new DataAddress(HeaderPosition, dataAddress);
        }

        public ReferenceCount GetReferenceCount()
        {
            var headerAddress = HeaderPosition;
            _streamReader.BaseStream.Seek(sizeof(long), SeekOrigin.Current);
            var referenceCount = _streamReader.ReadInt32();
            _streamReader.BaseStream.Position = headerAddress;
            return new ReferenceCount(HeaderPosition, referenceCount);
        }

        public ReferenceAddress GetReferenceAddress(int slot)
        {
            var headerAddress = HeaderPosition;
            _streamReader.BaseStream.Seek(sizeof(long) + sizeof(int) * slot, SeekOrigin.Current);
            var referenceStreamPosition = _streamReader.ReadInt64();
            _streamReader.BaseStream.Position = headerAddress;
            return new ReferenceAddress(HeaderPosition, referenceStreamPosition);
        }

        public NodeData GetData(DataAddress dataAddress)
        {
            var headerAddress = HeaderPosition;
            _streamReader.BaseStream.Position = dataAddress.DataStreamPosition;
            var dataLength = _streamReader.ReadInt32();
            var data = _streamReader.ReadBytes(dataLength);
            _streamReader.BaseStream.Position = headerAddress;
            return new NodeData(headerAddress, data);
        }
    }
}