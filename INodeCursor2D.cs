namespace NodeMaps
{
    public interface INodeCursor2D : INodeCursor1D
    {
        long UpAddress { get; set; }
        long DownAddress { get; set; }

        void MoveUp();
        void MoveDown();
    }
}