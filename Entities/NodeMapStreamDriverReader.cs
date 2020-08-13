using System.IO;

namespace NodeMaps.Entities
{
    public class NodeMapStreamReader
    {
        private readonly BinaryReader _streamReader;

        public long HeaderAddress => _streamReader.BaseStream.Position;

        public NodeMapStreamReader(Stream streamBase)
        {
            _streamReader = new BinaryReader(streamBase);
        }

        public long GetDataAddress()
        {
            var headerAddress = HeaderAddress;
            var dataAddress = _streamReader.ReadInt64();
            _streamReader.BaseStream.Position = headerAddress;
            return dataAddress;
        }

        public int GetReferenceCount()
        {
            var headerAddress = HeaderAddress;
            _streamReader.BaseStream.Seek(sizeof(long), SeekOrigin.Current);
            var referenceCount = _streamReader.ReadInt32();
            _streamReader.BaseStream.Position = headerAddress;
            return referenceCount;
        }

        public long GetReferenceAddress(int slot)
        {
            var headerAddress = HeaderAddress;
            _streamReader.BaseStream.Seek(sizeof(long) + sizeof(int) * slot, SeekOrigin.Current);
            var referenceAddress = _streamReader.ReadInt64();
            _streamReader.BaseStream.Position = headerAddress;
            return referenceAddress;
        }

        public byte[] GetData()
        {
            var headerAddress = HeaderAddress;
            var dataAddress = _streamReader.ReadInt64();
            _streamReader.BaseStream.Position = dataAddress;
            var dataLength = _streamReader.ReadInt32();
            var data = _streamReader.ReadBytes(dataLength);
            _streamReader.BaseStream.Position = headerAddress;
            return data;
        }
    }
}