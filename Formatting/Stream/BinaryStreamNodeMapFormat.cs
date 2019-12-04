using System;
using NodeMaps.Entities;

namespace NodeMaps.Formatting.Stream
{
    /// <summary>
    /// Most simple binary node format.
    /// 
    /// Its header is fixed width and its composed with seven 64 bit integers:
    ///     1: Data stream position.
    ///     2: Left node stream position.
    ///     3. Right node stream position.
    ///     4. Up node stream position.
    ///     5. Down node stream position.
    ///     6. Front node stream position.
    ///     7. Back node stream position.
    ///
    /// As this format header is fixed, changing a node address on the go means a simple overwrite of that 64 bit value.
    /// Data storage capacity is flexible, so undefined per node.
    /// Very fast reading speed.
    /// </summary>
    public sealed class BinaryStreamNodeMapFormat : StreamNodeMapFormat<byte[]>
    {
        /// <summary>
        /// Initializes the node stream.
        /// It will create an empty "root" node if the stream is empty.
        /// </summary>
        /// <param name="stream">The node stream.</param>
        public BinaryStreamNodeMapFormat(System.IO.Stream stream) : base(stream)
        {
            if (Stream.Length == 0) CreateEmptyNode();
        }

        /// <summary>
        /// Reads a node header at a given position.
        /// CAUTION: Do not provide a non valid node header position!
        /// </summary>
        /// <param name="id">The node header starting position.</param>
        public override void GotoNodeId(long id)
        {
            Stream.Position = id;
            CurrentId = id;
        }

        /// <summary>
        /// Reads the data location header. Then goes to that data location, reads the length of the data array,
        /// finally returns that data.
        /// </summary>
        /// <returns>The byte array stored in the node.</returns>
        public override byte[] GetData()
        {
            Stream.Position = CurrentId;
            var dataPos = Reader.ReadInt64();
            if (dataPos == -1) return null;
            Stream.Position = dataPos;
            return Reader.ReadBytes(Reader.ReadInt16());
        }

        /// <summary>
        /// References the current node to a new byte array created at the end of the stream.
        /// </summary>
        /// <param name="data"></param>
        public override void SetData(byte[] data)
        {
            Stream.Position = CurrentId;
            var newDataPosition = Stream.Length;
            Writer.Write(newDataPosition);
            Stream.Position = newDataPosition;
            Writer.Write((short) data.Length);
            Writer.Write(data);
            Writer.Flush();
        }

        /// <summary>
        /// Gets the target node that the current node is pointing to, given a direction.
        /// </summary>
        /// <param name="direction">The direction to get the pointer.</param>
        /// <returns>The target node header stream position.</returns>
        public override long GetTargetNodeId(Direction direction)
        {
            Stream.Position = CurrentId;

            OffsetToPointerNodeId(direction);

            return Reader.ReadInt64();
        }

        /// <summary>
        /// Given a direction, will overwrite its value to the newly given one.
        /// </summary>
        /// <param name="direction">The direction to be overwrite.</param>
        /// <param name="nodeId">The node header stream position.</param>
        public override void SetTargetNodeId(Direction direction, long nodeId)
        {
            Stream.Position = CurrentId;

            OffsetToPointerNodeId(direction);

            Writer.Write(nodeId);
            Writer.Flush();
        }

        /// <summary>
        /// Creates an empty node and returns its stream position.
        /// </summary>
        /// <returns>The new node header stream position.</returns>
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

        /// <summary>
        /// Utility method to offset to an specific node value. Used to overwrite specific directions correctly.
        /// </summary>
        /// <param name="direction">The direction to offset to.</param>
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