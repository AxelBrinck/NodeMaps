using NodeMaps.Entities;

namespace NodeMaps.Formatting.Stream
{
    public class BinaryStreamNodeMapFormat : StreamNodeMapFormat<byte[]>
    {
        public BinaryStreamNodeMapFormat(System.IO.Stream stream) : base(stream) { }

        public override void GotoId(long id) => Stream.Position = id;

        public override byte[] GetData()
        {
            Stream.Position = CurrentId;
            Stream.Position = Reader.ReadInt64();
            return Reader.ReadBytes(Reader.ReadInt16());
        }

        public override void SetData(byte[] data)
        {
            Stream.Position = CurrentId;
            var newDataPosition = GetEmptyId();
            Writer.Write(newDataPosition);
            Stream.Position = newDataPosition;
            Writer.Write((short) data.Length);
            Writer.Write(data);
        }

        public override long GetTargetNodeId(Direction direction)
        {
            Stream.Position = CurrentId;
            
            throw new System.NotImplementedException();
        }

        public override void SetTargetNodeId(Direction direction, long nodeId)
        {
            Stream.Position = CurrentId;
            
            throw new System.NotImplementedException();
        }
    }
}