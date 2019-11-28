using System.IO;

namespace NodeMaps
{
    public class StreamNodeMap2D : INodeMap2D
    {
        private const long RootNodeAddress = 0;
        private const long Empty = -1;
        
        private readonly BinaryReader _reader;
        private readonly BinaryWriter _writer;
        private readonly Stream _stream;

        private long _dataAddress;
        private long _leftAddress;
        private long _rightAddress;
        private long _upAddress;
        private long _downAddress;
        
        public StreamNodeMap2D(Stream stream)
        {
            _stream = stream;
            _reader = new BinaryReader(_stream);
            _writer = new BinaryWriter(_stream);
            
            Initialize();
        }

        public long NodeAddress { get; private set; }

        public long DataAddress
        {
            get => _dataAddress;
            set
            {
                _dataAddress = value;
                WriteNode(LeftAddress, RightAddress, UpAddress, DownAddress, value, NodeAddress);
            }
        }

        public long LeftAddress
        {
            get => _leftAddress;
            set
            {
                _leftAddress = value;
                WriteNode(value, RightAddress, UpAddress, DownAddress, DataAddress, NodeAddress);
            }
        }

        public long RightAddress
        {
            get => _rightAddress;
            set
            {
                _rightAddress = value;
                WriteNode(LeftAddress, value, UpAddress, DownAddress, DataAddress, NodeAddress);
            }
        }

        public long UpAddress
        {
            get => _upAddress;
            set
            {
                _upAddress = value;
                WriteNode(LeftAddress, RightAddress, value, DownAddress, DataAddress, NodeAddress);
            }
        }

        public long DownAddress
        {
            get => _downAddress;
            set
            {
                _downAddress = value;
                WriteNode(LeftAddress, RightAddress, UpAddress, value, DataAddress, NodeAddress);
            }
        }
        
        public long StreamLength => _stream.Length;
        
        public byte[] GetData()
        {
            if (DataAddress == Empty) return null;

            _stream.Position = DataAddress;
            
            return _reader.ReadBytes(_reader.ReadInt16());
        }

        public void SetData(byte[] data)
        {
            DataAddress = StreamLength;

            _stream.Position = DataAddress;
            
            _writer.Write((short) data.Length);
            _writer.Write(data);
            _writer.Flush();
        }
        
        public void MoveLeft()
        {
            if (LeftAddress == Empty)
            {
                var newNodeAddress = StreamLength;
                WriteNode(Empty, Empty, Empty, Empty, Empty, newNodeAddress);
                LeftAddress = newNodeAddress;
            }
            
            Goto(LeftAddress);
        }

        public void MoveRight()
        {
            if (RightAddress == Empty)
            {
                var newNodeAddress = StreamLength;
                WriteNode(Empty, Empty, Empty, Empty, Empty, newNodeAddress);
                RightAddress = newNodeAddress;
            }
            
            Goto(RightAddress);
        }

        public void MoveUp()
        {
            if (UpAddress == Empty)
            {
                var newNodeAddress = StreamLength;
                WriteNode(Empty, Empty, Empty, Empty, Empty, newNodeAddress);
                UpAddress = newNodeAddress;
            }
            
            Goto(UpAddress);
        }

        public void MoveDown()
        {
            if (DownAddress == Empty)
            {
                var newNodeAddress = StreamLength;
                WriteNode(Empty, Empty, Empty, Empty, Empty, newNodeAddress);
                DownAddress = newNodeAddress;
            }
            
            Goto(DownAddress);
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