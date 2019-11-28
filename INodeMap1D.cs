namespace NodeMaps
{
    public interface INodeMap1D : INodeMap
    {
        long LeftAddress { get; set; }
        long RightAddress { get; set; }

        void MoveLeft();
        void MoveRight();
    }
}