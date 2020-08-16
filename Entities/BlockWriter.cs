using System.IO;
using NodeMaps.Interfaces;

namespace NodeMaps.Entities
{
    public class BlockWriter
    {
        private readonly BinaryWriter _writer;
        
        public BlockWriter(Stream stream)
        {
            _writer = new BinaryWriter(stream);
        }

        public void WriteBlock(IBlock block)
        {
            _writer.Write(block.Serialize());
        }
    }
}