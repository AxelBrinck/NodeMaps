namespace NodeMaps
{
    public interface INodeMap2D : INodeMap1D
    {
        long UpAddress { get; set; }
        long DownAddress { get; set; }

        void MoveUp();
        void MoveDown();
    }
}