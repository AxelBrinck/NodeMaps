using System.IO;

namespace NodeMaps
{
    public class NodeDbBasicDriver
    {
        private readonly INodeCursor2D _nodeCursor2D;
        
        public NodeDbBasicDriver(Stream stream)
        {
            _nodeCursor2D = new StreamNodeCursor2D(stream);
        }
    }
}