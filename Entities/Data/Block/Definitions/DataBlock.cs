using System.IO;

namespace NodeMaps.Entities.Data.Block.Definitions
{
    /// <summary>
    /// This block represents a byte[] entry in a stream.
    /// Structure:
    ///     -Integer32: The number of bytes the byte array has.
    ///     -Byte[]: The byte array itself.
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

        public DataBlock(byte[] data) : base(Identifier)
        {
            Data = data;
        }
    }
}