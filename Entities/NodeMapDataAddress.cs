namespace NodeMaps.Entities
{
    public class DataAddress
    {
        public long HeaderStreamPosition { get; }
        public long DataStreamPosition { get; }

        internal DataAddress(long headerStreamPosition, long dataStreamPosition)
        {
            HeaderStreamPosition = headerStreamPosition;
            DataStreamPosition = dataStreamPosition;
        }
    }
}