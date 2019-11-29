namespace NodeMaps
{
    public interface INodeCursor3D : INodeCursor2D
    {
        long AheadAddress { get; set; }
        long BehindAddress { get; set; }

        void MoveAhead();
        void MoveBehind();
    }
}