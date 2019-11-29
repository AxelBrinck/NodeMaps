using System;
using System.IO;

namespace NodeMaps
{
    public class TimelineDb
    {
        private readonly INavigator2D _navigator2D;
        
        public TimelineDb(Stream stream)
        {
            _navigator2D = new StreamNodeCursor2D(stream);
        }

        public void Add(DateTime time, string entry, string key, byte[] value)
        {
            
        }
    }
}