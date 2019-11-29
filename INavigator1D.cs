namespace NodeMaps
{
    public interface INodeCursor1D
    {
        long LeftAddress { get; set; }
        long RightAddress { get; set; }

        void MoveLeft();
        void MoveRight();
    }
}