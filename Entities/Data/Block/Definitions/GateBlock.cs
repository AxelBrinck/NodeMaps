using System.IO;

namespace NodeMaps.Entities.Data.Block.Definitions
{
    /// <summary>
    /// This block represents an index entry in a stream.
    /// Structure:
    ///     -Integer16: The number of Integer64 values included in the index entry.
    ///     -Integer64[]: The array of indexes itself.
    /// </summary>
    public class GateBlock : Block
    {
        private const byte Identifier = 100;
        
        public long[] Gates { get; set; }

        protected override void EncodeProcedure(BinaryWriter writer)
        {
            writer.Write((short) Gates.Length);

            foreach (var l in Gates)
            {
                writer.Write(l);
            }
        }

        protected override void DecodeProcedure(BinaryReader reader)
        {
            var length = reader.ReadInt16();
            
            Gates = new long[length];
            
            for (short i = 0; i < length; i++)
            {
                Gates[i] = reader.ReadInt64();
            }
        }

        public GateBlock() : base(Identifier) { }

        public GateBlock(long[] gates) : base(Identifier)
        {
            Gates = gates;
        }
    }
}