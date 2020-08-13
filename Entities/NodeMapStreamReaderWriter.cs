using System.IO;

namespace NodeMaps.Entities
{
    public class NodeMapStreamReaderWriter : NodeMapStreamReader
    {
        protected readonly StreamWriter StreamWriter;
        
        public NodeMapStreamReaderWriter(Stream stream) : base(stream)
        {
            StreamWriter = new StreamWriter(stream);
        }
    }
}