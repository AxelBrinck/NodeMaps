namespace NodeMaps.Interfaces
{
    public interface IWarpDbReader
    {
        IWarpDbGateBlock ReadGateBlock(long address);
        IWarpDbDataBlock ReadDataBlock(long address);
    }
}