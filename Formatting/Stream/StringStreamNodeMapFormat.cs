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
                Stream.Position = CurrentNode.Data;
                return Reader.ReadString();
            }
            set
            {
                Stream.Position = CurrentNode.Data;
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
            Writer.Write(node.Data.ToString());
            Writer.Write(node.Left.ToString());
            Writer.Write(node.Right.ToString());
            Writer.Write(node.Up.ToString());
            Writer.Write(node.Down.ToString());
            Writer.Write(node.Front.ToString());
            Writer.Write(node.Back.ToString());
            Writer.Flush();
        }
    }
}