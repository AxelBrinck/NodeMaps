using System;
using System.IO;

namespace NodeMaps
{
    public class TimelineDb
    {
        private readonly INodeCursor2D _nodeCursor2D;
        
        public TimelineDb(Stream stream)
        {
            _nodeCursor2D = new StreamNodeCursor2D(stream);
        }

        public void Add(DateTime time, string entry, string key, byte[] value)
        {
            
        }
    }
}