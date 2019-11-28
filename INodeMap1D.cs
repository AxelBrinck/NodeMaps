namespace NodeMaps
{
    public interface INode1D
    {
        long LeftAddress { get; set; }
        long RightAddress { get; set; }

        void MoveLeft();
        void MoveRight();
    }
}