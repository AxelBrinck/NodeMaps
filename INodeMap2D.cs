namespace NodeMaps
{
    public interface INode2D
    {
        long UpAddress { get; set; }
        long DownAddress { get; set; }

        void MoveUp();
        void MoveDown();
    }
}