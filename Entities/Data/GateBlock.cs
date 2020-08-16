using System.IO;

namespace NodeMaps.Entities.Data
{
    /// <summary>
    /// This block represents a data entry in a stream.
    /// </summary>
    public class GateStreamByteBlock : StreamByteBlock
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

        public GateStreamByteBlock() : base(Identifier) { }
    }
}