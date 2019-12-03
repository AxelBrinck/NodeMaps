using NodeMaps.Entities;

namespace NodeMaps.Formatting
{
    public interface INodeMapFormat<T>
    {
        long CurrentId { get; }
        void GotoNodeId(long id);
        T GetData();
        void SetData(T data);
        long GetTargetNodeId(Direction direction);
        void SetTargetNodeId(Direction direction, long nodeId);
        long CreateEmptyNode();
    }
}