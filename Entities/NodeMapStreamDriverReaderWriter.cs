using System.IO;

namespace NodeMaps.Entities
{
    public class NodeMapStreamReaderWriter : NodeMapStreamReader
    {
        private readonly StreamWriter _streamWriter;
        
        public NodeMapStreamReaderWriter(Stream stream) : base(stream)
        {
            _streamWriter = new StreamWriter(stream);
        }

        public long CreateHeader(int referenceCount)
        {
            var headerAddress = _streamWriter.BaseStream.Length;
            
            _streamWriter.BaseStream.Position = headerAddress;
            
            _streamWriter.Write((long) -1);
            _streamWriter.Write(referenceCount);
            
            for (var i = 0; i < referenceCount; i++)
                _streamWriter.Write((long) -1);

            return headerAddress;
        }
    }
}