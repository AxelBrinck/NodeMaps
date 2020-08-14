using System.IO;

namespace NodeMaps.Entities
{
    public class NodeMapStreamReader
    {
        private readonly BinaryReader _streamReader;

        public NodeMapHeaderAddress HeaderAddress => new NodeMapHeaderAddress(_streamReader.BaseStream.Position);

        public NodeMapStreamReader(Stream streamBase)
        {
            _streamReader = new BinaryReader(streamBase);
        }

        public NodeMapDataAddress GetDataAddress()
        {
            var headerAddress = HeaderAddress;
            var dataAddress = _streamReader.ReadInt64();
            _streamReader.BaseStream.Position = headerAddress.HeaderAddress;
            return new NodeMapDataAddress(HeaderAddress, dataAddress);
        }

        public NodeMapReferenceCount GetReferenceCount()
        {
            var headerAddress = HeaderAddress;
            _streamReader.BaseStream.Seek(sizeof(long), SeekOrigin.Current);
            var referenceCount = _streamReader.ReadInt32();
            _streamReader.BaseStream.Position = headerAddress.HeaderAddress;
            return new NodeMapReferenceCount(HeaderAddress, referenceCount);
        }

        public NodeMapReferenceAddress GetReferenceAddress(int slot)
        {
            var headerAddress = HeaderAddress;
            _streamReader.BaseStream.Seek(sizeof(long) + sizeof(int) * slot, SeekOrigin.Current);
            var referenceStreamPosition = _streamReader.ReadInt64();
            _streamReader.BaseStream.Position = headerAddress.HeaderAddress;
            return new NodeMapReferenceAddress(HeaderAddress, referenceStreamPosition);
        }

        public NodeMapNodeData GetData(NodeMapDataAddress nodeMapDataAddress)
        {
            var headerAddress = HeaderAddress;
            _streamReader.BaseStream.Position = nodeMapDataAddress.DataStreamPosition;
            var dataLength = _streamReader.ReadInt32();
            var data = _streamReader.ReadBytes(dataLength);
            _streamReader.BaseStream.Position = headerAddress.HeaderAddress;
            return new NodeMapNodeData(HeaderAddress, data);
        }
    }
}