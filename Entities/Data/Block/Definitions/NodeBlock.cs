using System.IO;

namespace NodeMaps.Entities.Data.Block.Definitions
{
    
    /// <summary>
    /// This block represents a node in a stream.
    /// Structure:
    ///     -Integer64: The stream position where a DataBlock is. -1 to non-referenced DataBlock.
    ///     -Integer16: The number of portals that this node stores.
    ///     -Integer64[]: All the portals that points to different stream positions.
    /// </summary>
    public class NodeBlock : Block
    {
        private const byte Identifier = 102;

        public long DataPosition { get; set; }
        
        public long[] Portals { get; set; }
        
        public NodeBlock() : base(Identifier) { }

        protected override void EncodeProcedure(BinaryWriter writer)
        {
            writer.Write(DataPosition);
            writer.Write((short) Portals.Length);
            
            foreach(var portal in Portals)
            {
                writer.Write(portal);
            }
            
        }

        protected override void DecodeProcedure(BinaryReader reader)
        {
            DataPosition = reader.ReadInt64();
            
            var length = reader.ReadInt16();
            
            Portals = new long[length];
            
            for (short i = 0; i < length; i++)
            {
                Portals[i] = reader.ReadInt64();
            }
        }
    }
}