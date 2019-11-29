namespace NodeMaps
{
    public interface INavigator1D
    {
        long LeftAddress { get; set; }
        long RightAddress { get; set; }

        void MoveLeft();
        void MoveRight();
    }
}