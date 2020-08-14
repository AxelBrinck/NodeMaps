namespace NodeMaps.Entities
{
    public class NodeMapReferenceAddress : NodeSignature
    {
        public long ReferenceStreamPosition { get; }

        internal NodeMapReferenceAddress(NodeMapHeaderAddress headerStreamPosition, long referenceStreamPosition) : base(headerStreamPosition)
        {
            ReferenceStreamPosition = referenceStreamPosition;
        }
    }
}