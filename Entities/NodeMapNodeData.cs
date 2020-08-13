namespace NodeMaps.Entities
{
    public class NodeData
    {
        public long HeaderStreamPosition { get; }
        public byte[] Data { get; }

        public NodeData(long headerStreamPosition, byte[] data)
        {
            HeaderStreamPosition = headerStreamPosition;
            Data = data;
        }
    }
}