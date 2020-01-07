using System.IO;
using NodeMaps.Entities;

namespace NodeMaps.Formatting.Stream
{
    /// <summary>
    /// A base class defining what every stream format must implement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StreamNodeMapFormat<T> : INodeMapFormat<T>
    {
        protected readonly BinaryReader Reader;
        protected readonly System.IO.Stream Stream;
        protected readonly BinaryWriter Writer;

        protected StreamNodeMapFormat(System.IO.Stream stream)
        {
            Stream = stream;
            Reader = new BinaryReader(Stream);
            Writer = new BinaryWriter(Stream);
        }

        public long CurrentId { get; protected set; }
        
        public abstract void GotoNodeId(long id);

        public abstract T GetData();

        public abstract void SetData(T data);

        public abstract long GetTargetNodeId(Direction direction);

        public abstract void SetTargetNodeId(Direction direction, long nodeId);

        public abstract long CreateEmptyNode();
    }
}
