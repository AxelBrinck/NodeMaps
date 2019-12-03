using System.IO;
using NodeMaps.Entities;

namespace NodeMaps.Formatting.Stream
{
    public abstract class StreamNodeMapFormat<T>
    {
        protected readonly System.IO.Stream Stream;
        protected readonly BinaryReader Reader;
        protected readonly BinaryWriter Writer;

        private long _currentId;
        private Node _currentNode;
        
        public StreamNodeMapFormat(System.IO.Stream stream)
        {
            Stream = stream;
            Reader = new BinaryReader(Stream);
            Writer = new BinaryWriter(Stream);
        }
        
        public long Id
        {
            get => _currentId;
            set
            {
                _currentNode = null;
                _currentId = value;
            }
        }

        public Node CurrentNode
        {
            get => _currentNode ??= ReadNodeFromAddress(Id);
            set => WriteNodeToAddress(Id, value);
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
        
        public abstract T Data { get; set; }

        protected abstract Node ReadNodeFromAddress(long address);
        protected abstract void WriteNodeToAddress(long address, Node node);
    }
}