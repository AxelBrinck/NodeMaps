namespace NodeMaps.Interfaces
{
    public interface IWarpDbReaderWriter: IWarpDbReader
    {
        void WriteGateBlock(IWarpDbGateBlock gateBlock, long address);
        void WriteDataBlock(IWarpDbDataBlock dataBlock, long address);
    }
}