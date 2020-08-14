namespace NodeMaps.Entities
{
    public abstract class NodeSignature
    {
        public NodeMapHeaderAddress HeaderAddress { get; }

        internal NodeSignature(NodeMapHeaderAddress headerAddress)
        {
            HeaderAddress = headerAddress;
        }
    }
}