namespace NodeMaps.Entities
{
    public class NodeMapHeaderAddress
    {
        public long HeaderAddress { get; }

        internal NodeMapHeaderAddress(long headerAddress)
        {
            HeaderAddress = headerAddress;
        }
    }
}