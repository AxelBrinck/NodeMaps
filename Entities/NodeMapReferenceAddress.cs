namespace NodeMaps.Entities
{
    public class NodeMapReferenceAddress : NodeSignature
    {
        public long ReferenceStreamPosition { get; }

        internal NodeMapReferenceAddress(long headerStreamPosition, long referenceStreamPosition) : base(headerStreamPosition)
        {
            ReferenceStreamPosition = referenceStreamPosition;
        }
    }
}