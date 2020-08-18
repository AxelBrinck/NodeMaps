using System;
using System.IO;

namespace NodeMaps.Entities.Data.Block
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

        /// <summary>
        /// Instantiates the block by providing an identifier.
        /// </summary>
        /// <param name="signature">The identifier to assign to this block type.</param>
        protected Block(byte signature)
        {
            Signature = signature;
        }

        protected abstract void EncodeProcedure(BinaryWriter writer);
        protected abstract void DecodeProcedure(BinaryReader reader);
        
        /// <summary>
        /// Writes to a stream the block.
        /// </summary>
        /// <param name="writer">The stream to write.</param>
        public void EncodeToStream(BinaryWriter writer)
        {
            writer.Write(Signature);
            
            EncodeProcedure(writer);
        }

        /// <summary>
        /// Reads from a given stream the block.
        /// </summary>
        /// <param name="reader">The stream to read.</param>
        /// <exception cref="Exception">Throws exception when the stream doesnt contain a valid block.</exception>
        public void DecodeFromStream(BinaryReader reader)
        {
            var identifier = reader.ReadByte();
            if (identifier != Signature) throw new Exception("Block signature is not valid.");

            DecodeProcedure(reader);
        }
    }
}