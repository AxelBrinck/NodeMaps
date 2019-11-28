namespace NodeMaps
{
    public interface INodeMap
    {
        long NodeAddress { get; }
        long DataAddress { get; set; }
        byte[] GetData();
        void SetData(byte[] data);
        void Goto(long nodeAddress);
    }
}