namespace NodeMaps
{
    public interface INodeMap3D : INodeMap2D
    {
        long AheadAddress { get; set; }
        long BehindAddress { get; set; }

        void MoveAhead();
        void MoveBehind();
    }
}