namespace NodeMaps.Entities
{
    public class ReferenceCount
    {
        public long HeaderStreamPosition { get; }
        public int Count { get; }
        
        internal ReferenceCount(long headerStreamPosition, int count)
        {
            HeaderStreamPosition = headerStreamPosition;
            Count = count;
        }
    }
}