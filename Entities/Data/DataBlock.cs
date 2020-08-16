using System.IO;

namespace NodeMaps.Entities.Data
{
    /// <summary>
    /// This block represents an index entry in a stream.
    /// </summary>
    public class DataBlock : Block
    {
        private const byte Identifier = 101;
        
        public byte[] Data { get; set; }

        protected override void EncodeProcedure(BinaryWriter writer)
        {
            writer.Write(Data.Length);
            writer.Write(Data);
        }

        protected override void DecodeProcedure(BinaryReader reader)
        {
            var length = reader.ReadInt32();
            Data = reader.ReadBytes(length);
        }

        public DataBlock() : base(Identifier) { }
    }
}