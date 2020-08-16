using System.IO;
using NodeMaps.Entities.Data;

namespace NodeMaps.Entities
{
    public class WritingOperations
    {
        private readonly BlockWriter _writer;

        public WritingOperations(Stream stream)
        {
            _writer = new BlockWriter(stream);
        }

        public void WriteDataBlock(long position, DataBlock dataBlock)
        {
            _writer.WriteBlock(position, dataBlock);
        }

        public void WriteGateBlock(long position, GateBlock gateBlock)
        {
            _writer.WriteBlock(position, gateBlock);
        }
    }
}