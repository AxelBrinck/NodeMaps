namespace NodeMaps.Interfaces
{
    public interface IWarpDbGateBlock : IWarpDbBlock
    {
        int GateCount { get; }
        long GetGateValue(int gateId);
        long SetGateValue(int gateId, long value);
    }
}