using System.IO;

namespace NodeMaps
{
    public class NodeDbBasicDriver
    {
        private readonly INodeMap2D _nodeMap2D;
        
        public NodeDbBasicDriver(Stream stream)
        {
            _nodeMap2D = new StreamNodeMap2D(stream);
        }
    }
}