using NodeMaps.Interfaces;

namespace NodeMaps.Entities
{
    public class DataBlock : IBlock
    {
        public byte[] Data { get; private set; }

        public DataBlock(byte[] data)
        {
            Data = data;
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