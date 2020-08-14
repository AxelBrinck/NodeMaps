namespace NodeMaps.Entities
{
    public class NodeMapNodeData : NodeSignature
    {
        public byte[] NodeData { get; }

        internal NodeMapNodeData(NodeMapHeaderAddress headerStreamPosition, byte[] nodeData) : base(headerStreamPosition)
        {
            NodeData = nodeData;
        }
    }
}