namespace NodeMaps
{
    public interface INode3D
    {
        long AheadAddress { get; set; }
        long BehindAddress { get; set; }

        void MoveAhead();
        void MoveBehind();
    }
}