namespace NodeMaps
{
    /// <summary>
    /// Describes a single node with all its attributes.
    /// </summary>
    public class Node
    {
        public long Address { get; }
        public long Data { get; }
        public long Left { get; }
        public long Right { get; }
        public long Up { get; }
        public long Down { get; }
        public long Front { get; }
        public long Back { get; }

        public Node(long address, long data, long left, long right, long up, long down, long front, long back)
        {
            Address = address;
            Data = data;
            Left = left;
            Right = right;
            Up = up;
            Down = down;
            Front = front;
            Back = back;
        }
    }
}