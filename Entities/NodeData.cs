namespace NodeMaps.Entities
{
    public abstract class NodeSignature
    {
        public long HeaderAddress { get; }

        internal NodeSignature(long headerAddress)
        {
            HeaderAddress = headerAddress;
        }
    }
}