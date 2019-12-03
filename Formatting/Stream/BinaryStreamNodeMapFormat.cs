using System.IO;
using NodeMaps.Entities;

namespace NodeMaps.Formatting.Stream
{
    public class BinaryStreamNodeMapFormat : StreamNodeMapFormat<byte[]>
    {
        public BinaryStreamNodeMapFormat(System.IO.Stream stream) : base(stream) {}

        public override byte[] Data
        {
            get
            {
                Stream.Position = CurrentNode.Data;
                var length = Reader.ReadInt16();
                return Reader.ReadBytes(length);
            }
            set
            {
                Stream.Position = CurrentNode.Data;
                Writer.Write((short) value.Length);
                Writer.Write(value);
                Writer.Flush();
            }
        }

        protected override Node ReadNodeFromAddress(long address)
        {
            Stream.Position = address;
            return new Node(
                address,
                Reader.ReadInt64(),
                Reader.ReadInt64(),
                Reader.ReadInt64(),
                Reader.ReadInt64(),
                Reader.ReadInt64(),
                Reader.ReadInt64(),
                Reader.ReadInt64());
        }

        protected override void WriteNodeToAddress(long address, Node node)
        {
            Stream.Position = address;
            Writer.Write(node.Data);
            Writer.Write(node.Left);
            Writer.Write(node.Right);
            Writer.Write(node.Up);
            Writer.Write(node.Down);
            Writer.Write(node.Front);
            Writer.Write(node.Back);
            Writer.Flush();
        }

        
    }
}