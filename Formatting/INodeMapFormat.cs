using NodeMaps.Entities;

namespace NodeMaps.Formatting
{
    public interface INodeMapFormat<T>
    {
        long Id { get; set; }
        Node CurrentNode { get; set; }
        long LeftNodeId { get; set; }
        long RightNodeId { get; set; }
        long UpNodeId { get; set; }
        long DownNodeId { get; set; }
        long FrontNodeId { get; set; }
        long BackNodeId { get; set; }
        T Data { get; set; }
        long GetEmptyId();
    }
}