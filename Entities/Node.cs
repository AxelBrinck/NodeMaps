namespace NodeMaps.Entities
{
    /// <summary>
    /// Describes a single node with all its attributes.
    /// </summary>
    public class Node
    {
        public long Id { get; }
        public long DataId { get; }
        public long LeftId { get; }
        public long RightId { get; }
        public long UpId { get; }
        public long DownId { get; }
        public long FrontId { get; }
        public long BackId { get; }

        public Node(long id, long dataId, long leftId, long rightId, long upId, long downId, long frontId, long backId)
        {
            Id = id;
            DataId = dataId;
            LeftId = leftId;
            RightId = rightId;
            UpId = upId;
            DownId = downId;
            FrontId = frontId;
            BackId = backId;
        }
    }
}