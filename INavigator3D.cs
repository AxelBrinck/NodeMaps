namespace NodeMaps
{
    public interface INavigator3D : INavigator2D
    {
        long AheadAddress { get; set; }
        long BehindAddress { get; set; }

        void MoveAhead();
        void MoveBehind();
    }
}