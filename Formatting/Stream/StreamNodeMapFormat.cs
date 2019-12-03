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
        
        /**
        public Node LeftNode
        {
            get => ReadNodeFromAddress(CurrentNode.LeftId);
            set => WriteNodeToAddress(CurrentNode.LeftId, value);
        }
        
        public Node RightNode
        {
            get => ReadNodeFromAddress(CurrentNode.RightId);
            set => WriteNodeToAddress(CurrentNode.RightId, value);
        }
        
        public Node UpNode
        {
            get => ReadNodeFromAddress(CurrentNode.UpId);
            set => WriteNodeToAddress(CurrentNode.UpId, value);
        }
        
        public Node DownNode
        {
            get => ReadNodeFromAddress(CurrentNode.DownId);
            set => WriteNodeToAddress(CurrentNode.DownId, value);
        }
        
        public Node FrontNode
        {
            get => ReadNodeFromAddress(CurrentNode.FrontId);
            set => WriteNodeToAddress(CurrentNode.FrontId, value);
        }
        
        public Node BackNode
        {
            get => ReadNodeFromAddress(CurrentNode.BackId);
            set => WriteNodeToAddress(CurrentNode.BackId, value);
        }**/
        
        public abstract T Data { get; set; }

        protected abstract Node ReadNodeFromAddress(long address);
        protected abstract void WriteNodeToAddress(long address, Node node);
    }
}