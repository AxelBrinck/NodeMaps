using System.IO;

namespace NodeMaps.Entities
{
    public class NodeMapStreamReaderWriter : NodeMapStreamReader
    {
        private readonly StreamWriter _streamWriter;
        
        public NodeMapStreamReaderWriter(Stream streamBase) : base(streamBase)
        {
            _streamWriter = new StreamWriter(streamBase);
        }
    }
}