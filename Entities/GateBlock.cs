using NodeMaps.Interfaces;

namespace NodeMaps.Entities
{
    public class GateBlock : IBlock
    {
        public long[] Gates { get; private set; }

        public GateBlock(long[] gates)
        {
            Gates = gates;
        }

        public byte[] Serialize()
        {
            throw new System.NotImplementedException();
        }

        public void Deserialize(byte[] serial)
        {
            throw new System.NotImplementedException();
        }

        public int GetSerialLength()
        {
            throw new System.NotImplementedException();
        }
    }
}