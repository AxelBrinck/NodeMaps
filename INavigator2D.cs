namespace NodeMaps
{
    public interface INavigator2D : INavigator1D
    {
        long UpAddress { get; set; }
        long DownAddress { get; set; }

        void MoveUp();
        void MoveDown();
    }
}