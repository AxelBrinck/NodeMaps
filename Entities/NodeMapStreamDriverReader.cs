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

        public NodeMapDataAddress GetDataAddress()
        {
            var headerAddress = HeaderPosition;
            var dataAddress = _streamReader.ReadInt64();
            _streamReader.BaseStream.Position = headerAddress;
            return new NodeMapDataAddress(HeaderPosition, dataAddress);
        }

        public NodeMapReferenceCount GetReferenceCount()
        {
            var headerAddress = HeaderPosition;
            _streamReader.BaseStream.Seek(sizeof(long), SeekOrigin.Current);
            var referenceCount = _streamReader.ReadInt32();
            _streamReader.BaseStream.Position = headerAddress;
            return new NodeMapReferenceCount(HeaderPosition, referenceCount);
        }

        public NodeMapReferenceAddress GetReferenceAddress(int slot)
        {
            var headerAddress = HeaderPosition;
            _streamReader.BaseStream.Seek(sizeof(long) + sizeof(int) * slot, SeekOrigin.Current);
            var referenceStreamPosition = _streamReader.ReadInt64();
            _streamReader.BaseStream.Position = headerAddress;
            return new NodeMapReferenceAddress(HeaderPosition, referenceStreamPosition);
        }

        public NodeMapNodeData GetData(NodeMapDataAddress nodeMapDataAddress)
        {
            var headerAddress = HeaderPosition;
            _streamReader.BaseStream.Position = nodeMapDataAddress.DataStreamPosition;
            var dataLength = _streamReader.ReadInt32();
            var data = _streamReader.ReadBytes(dataLength);
            _streamReader.BaseStream.Position = headerAddress;
            return new NodeMapNodeData(headerAddress, data);
        }
    }
}