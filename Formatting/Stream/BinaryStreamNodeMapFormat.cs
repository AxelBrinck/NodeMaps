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
                Stream.Position = CurrentNode.DataId;
                var length = Reader.ReadInt16();
                return Reader.ReadBytes(length);
            }
            set
            {
                Stream.Position = CurrentNode.DataId;
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
            Writer.Write(node.DataId);
            Writer.Write(node.LeftId);
            Writer.Write(node.RightId);
            Writer.Write(node.UpId);
            Writer.Write(node.DownId);
            Writer.Write(node.FrontId);
            Writer.Write(node.BackId);
            Writer.Flush();
        }

        
    }
}