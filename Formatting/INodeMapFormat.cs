using NodeMaps.Entities;

namespace NodeMaps.Formatting
{
    public interface INodeMapFormat<T>
    {
        long Id { get; set; }
        T Data { get; set; }
        long GetEmptyId();
    }
}