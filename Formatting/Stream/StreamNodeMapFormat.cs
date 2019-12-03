using System.IO;
using NodeMaps.Entities;

namespace NodeMaps.Formatting.Stream
{
    public abstract class StreamNodeMapFormat<T> : INodeMapFormat<T>
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

        public long LeftNodeId
        {
            get
            {
                if (_currentNode == null) ReadNodeFromAddress(Id);
                return _currentNode.LeftId;
            }
            set
            {
                Stream.Position = Id;
                SetLeftNodeId(value);
            }
        }

        public long RightNodeId
        {
            get
            {
                if (_currentNode == null) ReadNodeFromAddress(Id);
                return _currentNode.RightId;
            }
            set
            {
                Stream.Position = Id;
                SetRightNodeId(value);
            }
        }

        public long UpNodeId
        {
            get
            {
                if (_currentNode == null) ReadNodeFromAddress(Id);
                return _currentNode.UpId;
            }
            set
            {
                Stream.Position = Id;
                SetUpNodeId(value);
            }
        }

        public long DownNodeId
        {
            get
            {
                if (_currentNode == null) ReadNodeFromAddress(Id);
                return _currentNode.DownId;
            }
            set
            {
                Stream.Position = Id;
                SetDownNodeId(value);
            }
        }

        public long FrontNodeId
        {
            get
            {
                if (_currentNode == null) ReadNodeFromAddress(Id);
                return _currentNode.FrontId;
            }
            set
            {
                Stream.Position = Id;
                SetFrontNodeId(value);
            }
        }

        public long BackNodeId
        {
            get
            {
                if (_currentNode == null) ReadNodeFromAddress(Id);
                return _currentNode.BackId;
            }
            set
            {
                Stream.Position = Id;
                SetBackNodeId(value);
            }
        }

        public long GetEmptyId()
        {
            return Stream.Length;
        }
        
        public abstract T Data { get; set; }

        protected abstract Node ReadNodeFromAddress(long address);
        protected abstract void WriteNodeToAddress(long address, Node node);
        protected abstract void SetLeftNodeId(long id);
        protected abstract void SetRightNodeId(long id);
        protected abstract void SetUpNodeId(long id);
        protected abstract void SetDownNodeId(long id);
        protected abstract void SetFrontNodeId(long id);
        protected abstract void SetBackNodeId(long id);
    }
}