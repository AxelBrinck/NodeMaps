using System.IO;

namespace NodeMaps.Entities
{
    public abstract class NodeMapStreamBase
    {
        private readonly Stream _stream;
        
        public NodeMapStreamBase(Stream stream)
        {
            _stream = stream;
        }
    }
}