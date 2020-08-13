namespace NodeMaps.Entities
{
    public class ReferenceAddress
    {
        public long HeaderStreamPosition { get; }
        public long ReferenceStreamPosition { get; }

        internal ReferenceAddress(long headerStreamPosition, long referenceStreamPosition)
        {
            HeaderStreamPosition = headerStreamPosition;
            ReferenceStreamPosition = referenceStreamPosition;
        }
    }
}