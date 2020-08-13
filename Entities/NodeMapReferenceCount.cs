namespace NodeMaps.Entities
{
    public class NodeMapReferenceCount : NodeSignature
    {
        public int ReferenceCount { get; }
        
        internal NodeMapReferenceCount(long headerStreamPosition, int referenceCount) : base(headerStreamPosition)
        {
            ReferenceCount = referenceCount;
        }
    }
}