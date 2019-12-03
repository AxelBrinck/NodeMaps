using NodeMaps.Entities;

namespace NodeMaps.Formatting
{
    public interface INodeMapFormat<T>
    {
        long Address { get; set; }
        Node CurrentNode { get; set; }
        Node LeftNode { get; set; }
        Node RightNode { get; set; }
        Node UpNode { get; set; }
        Node DownNode { get; set; }
        Node FrontNode { get; set; }
        Node BackNode { get; set; }
        T Data { get; set; }
    }
}