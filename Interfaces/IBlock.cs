namespace NodeMaps.Interfaces
{
    public interface IBlock
    {
        byte[] Serialize();
        void Deserialize(byte[] serial);
        int GetSerialLength();
    }
}