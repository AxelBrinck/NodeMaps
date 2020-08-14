using System.IO;

namespace NodeMaps.Entities
{
    public class NodeMapStreamReader
    {
        private readonly BinaryReader _streamReader;

        public NodeMapStreamReader(Stream stream)
        {
            _streamReader = new BinaryReader(stream);
        }

        public long GetDataAddress(long headerStreamPosition)
        {
            _streamReader.BaseStream.Position = headerStreamPosition;
            return _streamReader.ReadInt64();
        }

        public int GetSlotCount(long headerStreamPosition)
        {
            _streamReader.BaseStream.Position = headerStreamPosition;
            _streamReader.BaseStream.Seek(sizeof(long), SeekOrigin.Current);
            return _streamReader.ReadInt32();
        }

        public long GetSlotValue(long headerStreamPosition, int slot)
        {
            _streamReader.BaseStream.Position = headerStreamPosition;
            _streamReader.BaseStream.Seek(sizeof(long) + sizeof(int) + sizeof(int) * slot, SeekOrigin.Current);
            return _streamReader.ReadInt64();
        }

        public byte[] GetData(long dataAddress)
        {
            _streamReader.BaseStream.Position = dataAddress;
            return _streamReader.ReadBytes(_streamReader.ReadInt32());
        }
    }
}