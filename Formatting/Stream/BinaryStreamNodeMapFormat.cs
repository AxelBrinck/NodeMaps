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

        protected override void SetLeftNodeId(long id)
        {
            Stream.Position += sizeof(long) * 0;
            Writer.Write(id);
        }

        protected override void SetRightNodeId(long id)
        {
            Stream.Position += sizeof(long) * 1;
            Writer.Write(id);
        }

        protected override void SetUpNodeId(long id)
        {
            Stream.Position += sizeof(long) * 2;
            Writer.Write(id);
        }

        protected override void SetDownNodeId(long id)
        {
            Stream.Position += sizeof(long) * 3;
            Writer.Write(id);
        }

        protected override void SetFrontNodeId(long id)
        {
            Stream.Position += sizeof(long) * 4;
            Writer.Write(id);
        }

        protected override void SetBackNodeId(long id)
        {
            Stream.Position += sizeof(long) * 5;
            Writer.Write(id);
        }
    }
}