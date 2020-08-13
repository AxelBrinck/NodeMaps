using System.IO;

namespace NodeMaps.Entities
{
    public class NodeMapStreamReader : NodeMapStreamBase
    {
        protected readonly BinaryReader StreamReader;
        
        public NodeMapStreamReader(Stream stream) : base(stream)
        {
            StreamReader = new BinaryReader(stream);
        }
    }
}