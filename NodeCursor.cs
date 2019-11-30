namespace NodeMaps
{
    public class NodeCursor : INodeCursor
    {
        public long NodeAddress { get; }
        public long DataAddress { get; set; }
        public byte[] GetData()
        {
            throw new System.NotImplementedException();
        }

        public void SetData(byte[] data)
        {
            throw new System.NotImplementedException();
        }

        public void Goto(long nodeAddress)
        {
            throw new System.NotImplementedException();
        }
    }
}