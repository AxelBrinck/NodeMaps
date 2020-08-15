namespace NodeMaps.Interfaces
{
    public interface IWarpDbDataBlock : IWarpDbBlock
    {
        byte[] Data { get; }
    }
}