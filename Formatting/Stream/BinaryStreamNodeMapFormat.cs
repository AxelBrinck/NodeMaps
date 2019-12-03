using System.IO;
using NodeMaps.Entities;

namespace NodeMaps.Formatting.Stream
{
    public class BinaryStreamNodeMapFormat : INodeMapFormat<byte[]>
    {
        private readonly System.IO.Stream _stream;
        private readonly BinaryReader _reader;
        private readonly BinaryWriter _writer;

        private long _currentAddress;
        private Node _currentNode;
        
        public BinaryStreamNodeMapFormat(System.IO.Stream stream)
        {
            _stream = stream;
            _reader = new BinaryReader(_stream);
            _writer = new BinaryWriter(_stream);
        }

        public long Address
        {
            get => _currentAddress;
            set
            {
                _currentNode = null;
                _currentAddress = value;
            }
        }

        public Node CurrentNode
        {
            get => _currentNode ??= ReadNodeFromAddress(Address);
            set => WriteNodeToAddress(Address, value);
        }

        public Node LeftNode
        {
            get => ReadNodeFromAddress(CurrentNode.Left);
            set => WriteNodeToAddress(CurrentNode.Left, value);
        }
        
        public Node RightNode
        {
            get => ReadNodeFromAddress(CurrentNode.Right);
            set => WriteNodeToAddress(CurrentNode.Right, value);
        }
        
        public Node UpNode
        {
            get => ReadNodeFromAddress(CurrentNode.Up);
            set => WriteNodeToAddress(CurrentNode.Up, value);
        }
        
        public Node DownNode
        {
            get => ReadNodeFromAddress(CurrentNode.Down);
            set => WriteNodeToAddress(CurrentNode.Down, value);
        }
        
        public Node FrontNode
        {
            get => ReadNodeFromAddress(CurrentNode.Front);
            set => WriteNodeToAddress(CurrentNode.Front, value);
        }
        
        public Node BackNode
        {
            get => ReadNodeFromAddress(CurrentNode.Back);
            set => WriteNodeToAddress(CurrentNode.Back, value);
        }

        public byte[] Data
        {
            get
            {
                _stream.Position = CurrentNode.Data;
                var length = _reader.ReadInt16();
                return _reader.ReadBytes(length);
            }
            set
            {
                _stream.Position = CurrentNode.Data;
                _writer.Write((short) value.Length);
                _writer.Write(value);
                _writer.Flush();
            }
        }

        private Node ReadNodeFromAddress(long address)
        {
            _stream.Position = address;
            return new Node(
                address,
                _reader.ReadInt64(),
                _reader.ReadInt64(),
                _reader.ReadInt64(),
                _reader.ReadInt64(),
                _reader.ReadInt64(),
                _reader.ReadInt64(),
                _reader.ReadInt64());
        }

        private void WriteNodeToAddress(long address, Node node)
        {
            _stream.Position = address;
            _writer.Write(node.Data);
            _writer.Write(node.Left);
            _writer.Write(node.Right);
            _writer.Write(node.Up);
            _writer.Write(node.Down);
            _writer.Write(node.Front);
            _writer.Write(node.Back);
            _writer.Flush();
        }
    }
}