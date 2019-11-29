namespace NodeMaps
{
    public interface INodeCursor
    {
        long NodeAddress { get; }
        long DataAddress { get; set; }
        byte[] GetData();
        void SetData(byte[] data);
        void Goto(long nodeAddress);
    }
}