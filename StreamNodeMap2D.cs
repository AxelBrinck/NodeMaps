using System.IO;

namespace NodeMaps
{
    public class FileNodeMap2D : INodeMap2D
    {
        private const long RootNodeAddress = 0;
        private const long Empty = -1;
        
        private readonly BinaryReader _reader;
        private readonly BinaryWriter _writer;
        private readonly Stream _stream;
        
        public FileNodeMap2D(string path)
        {
            _stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            _reader = new BinaryReader(_stream);
            _writer = new BinaryWriter(_stream);
            
            Initialize();
        }

        public long NodeAddress { get; private set; }
        public long DataAddress { get; set; }
        public long LeftAddress { get; set; }
        public long RightAddress { get; set; }
        public long UpAddress { get; set; }
        public long DownAddress { get; set; }
        public long FileLength => _stream.Length;
        
        public byte[] GetData()
        {
            throw new System.NotImplementedException();
        }

        public void SetData(byte[] data)
        {
            throw new System.NotImplementedException();
        }
        
        public void MoveLeft()
        {
            if (LeftAddress == Empty)
            {
                var newNodeAddress = FileLength;
                WriteNode(Empty, Empty, Empty, Empty, Empty, newNodeAddress);
                LeftAddress = newNodeAddress;
            }
            
        }

        public void MoveRight()
        {
            if (RightAddress == Empty)
            {
                var newNodeAddress = FileLength;
                WriteNode(Empty, Empty, Empty, Empty, Empty, newNodeAddress);
                RightAddress = newNodeAddress;
            }
            
        }

        public void MoveUp()
        {
            if (UpAddress == Empty)
            {
                var newNodeAddress = FileLength;
                WriteNode(Empty, Empty, Empty, Empty, Empty, newNodeAddress);
                UpAddress = newNodeAddress;
            }
            
        }

        public void MoveDown()
        {
            if (DownAddress == Empty)
            {
                var newNodeAddress = FileLength;
                WriteNode(Empty, Empty, Empty, Empty, Empty, newNodeAddress);
                DownAddress = newNodeAddress;
            }
        }
        
        public void Goto(long nodeAddress)
        {
            NodeAddress = nodeAddress;
            _stream.Position = nodeAddress;
            LeftAddress = _reader.ReadInt64();
            RightAddress = _reader.ReadInt64();
            UpAddress = _reader.ReadInt64();
            DownAddress = _reader.ReadInt64();
            DataAddress = _reader.ReadInt64();
        }

        private void Initialize()
        {
            if (_stream.Length == 0)
            {
                WriteNode(Empty, Empty, Empty, Empty, Empty, RootNodeAddress);
            }
            else
            {
                Goto(RootNodeAddress);
            }
        }
        
        private void WriteNode(long left, long right, long up, long down, long value, long position)
        {
            _stream.Position = position;
            _writer.Write(left);
            _writer.Write(right);
            _writer.Write(up);
            _writer.Write(down);
            _writer.Write(value);
            _writer.Flush();
        }
    }
}