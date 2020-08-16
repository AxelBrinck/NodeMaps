using System.IO;
using NodeMaps.Interfaces;

namespace NodeMaps.Entities
{
    public class BlockReader
    {
        private readonly BinaryReader _reader;
        
        public BlockReader(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }

        public TBlock ReadBlock<TBlock>(long address, TBlock block) where TBlock : IBlock
        {
            _reader.BaseStream.Position = address;
            block.Deserialize(_reader.ReadBytes(block.GetSerialLength()));
            return block;
        }
    }
}