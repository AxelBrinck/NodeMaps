namespace NodeMaps.Entities
{
    public class NodeMapNodeData : NodeSignature
    {
        public byte[] NodeData { get; }

        public NodeMapNodeData(long headerStreamPosition, byte[] nodeData) : base(headerStreamPosition)
        {
            NodeData = nodeData;
        }
    }
}