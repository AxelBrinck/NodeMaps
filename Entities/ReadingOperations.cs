using System.IO;
using NodeMaps.Entities.Data;

namespace NodeMaps.Entities
{
    public class ReadingOperations
    {
        private readonly BlockReader _reader;

        public ReadingOperations(Stream stream)
        {
            _reader = new BlockReader(stream);
        }

        public DataBlock ReadDataBlock(long position)
        {
            return _reader.ReadBlock<DataBlock>(position);
        }

        public GateBlock ReadGateBlock(long position)
        {
            return _reader.ReadBlock<GateBlock>(position);
        }
    }
}