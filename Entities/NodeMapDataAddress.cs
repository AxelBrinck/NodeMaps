namespace NodeMaps.Entities
{
    public class NodeMapDataAddress : NodeSignature
    {
        public long DataStreamPosition { get; }

        internal NodeMapDataAddress(long headerStreamPosition, long dataStreamPosition) : base(headerStreamPosition)
        {
            DataStreamPosition = dataStreamPosition;
        }
    }
}