using System;
using NodeMaps.Entities;

namespace NodeMaps.Formatting.Stream
{
    public sealed class BinaryStreamNodeMapFormat : StreamNodeMapFormat<byte[]>
    {
        public BinaryStreamNodeMapFormat(System.IO.Stream stream) : base(stream)
        {
            if (Stream.Length == 0)
            {
                CreateEmptyNode();
            }
        }

        public override void GotoNodeId(long id)
        {
            Stream.Position = id;
            CurrentId = id;
        }

        public override byte[] GetData()
        {
            Stream.Position = CurrentId;
            Stream.Position = Reader.ReadInt64();
            return Reader.ReadBytes(Reader.ReadInt16());
        }

        public override void SetData(byte[] data)
        {
            Stream.Position = CurrentId;
            var newDataPosition = Stream.Length;
            Writer.Write(newDataPosition);
            Stream.Position = newDataPosition;
            Writer.Write((short) data.Length);
            Writer.Write(data);
        }

        public override long GetTargetNodeId(Direction direction)
        {
            Stream.Position = CurrentId;

            OffsetToPointerNodeId(direction);

            return Reader.ReadInt64();
        }

        public override void SetTargetNodeId(Direction direction, long nodeId)
        {
            Stream.Position = CurrentId;

            OffsetToPointerNodeId(direction);

            Writer.Write(nodeId);
            Writer.Flush();
        }

        public override long CreateEmptyNode()
        {
            GotoNodeId(Stream.Length);
            Writer.Write((long) -1);
            Writer.Write((long) -1);
            Writer.Write((long) -1);
            Writer.Write((long) -1);
            Writer.Write((long) -1);
            Writer.Write((long) -1);
            Writer.Write((long) -1);
            Writer.Flush();
            return CurrentId;
        }

        private void OffsetToPointerNodeId(Direction direction)
        {
            Stream.Position += direction switch
            {
                Direction.Left => (sizeof(long) * 1),
                Direction.Right => (sizeof(long) * 2),
                Direction.Up => (sizeof(long) * 3),
                Direction.Down => (sizeof(long) * 4),
                Direction.Front => (sizeof(long) * 5),
                Direction.Back => (sizeof(long) * 6),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}