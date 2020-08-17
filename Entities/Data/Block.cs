using System;
using System.IO;

namespace NodeMaps.Entities.Data
{
    /// <summary>
    /// This is the abstraction that will need to be implemented by every block.
    /// It requires a signature.
    /// This signature is a byte and it will pre-fix every block in a stream.
    /// When decoding, if the first byte doesnt match the signature: Incorrect block type to read, data corruption.
    /// </summary>
    public abstract class Block
    {
        private byte Signature { get; }

        public Block(byte signature)
        {
            Signature = signature;
        }

        protected abstract void EncodeProcedure(BinaryWriter writer);
        protected abstract void DecodeProcedure(BinaryReader reader);
        
        public void Encode(BinaryWriter writer)
        {
            writer.Write(Signature);
            
            EncodeProcedure(writer);
        }

        public void Decode(BinaryReader reader)
        {
            var identifier = reader.ReadByte();
            if (identifier != Signature) throw new Exception("Block signature is not valid.");

            DecodeProcedure(reader);
        }
    }
}