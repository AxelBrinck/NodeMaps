using NodeMaps.Entities;

namespace NodeMaps.Formatting.Stream
{
    public class StringStreamNodeMapFormat : StreamNodeMapFormat<string>
    {
        public StringStreamNodeMapFormat(System.IO.Stream stream) : base(stream) {}

        public override string Data 
        {
            get
            {
                Stream.Position = CurrentNode.DataId;
                return Reader.ReadString();
            }
            set
            {
                Stream.Position = CurrentNode.DataId;
                Writer.Write(value);
                Writer.Flush();
            }
        }
        
        protected override Node ReadNodeFromAddress(long address)
        {
            Stream.Position = address;
            return new Node(
                address,
                long.Parse(Reader.ReadString()),
                long.Parse(Reader.ReadString()),
                long.Parse(Reader.ReadString()),
                long.Parse(Reader.ReadString()),
                long.Parse(Reader.ReadString()),
                long.Parse(Reader.ReadString()),
                long.Parse(Reader.ReadString()));
        }

        protected override void WriteNodeToAddress(long address, Node node)
        {
            Stream.Position = address;
            Writer.Write(node.DataId.ToString());
            Writer.Write(node.LeftId.ToString());
            Writer.Write(node.RightId.ToString());
            Writer.Write(node.UpId.ToString());
            Writer.Write(node.DownId.ToString());
            Writer.Write(node.FrontId.ToString());
            Writer.Write(node.BackId.ToString());
            Writer.Flush();
        }
    }
}