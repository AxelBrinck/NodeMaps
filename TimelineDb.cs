using System;
using System.IO;
using System.Threading;

namespace NodeMaps
{
    public class TimelineDb
    {
        private readonly INavigator2D _navigator2D;
        private readonly Semaphore _semaphore = new Semaphore(1, 1);
        
        public TimelineDb(Stream stream)
        {
            _navigator2D = new StreamNodeCursor2D(stream);
        }

        public void Add(DateTime time, string entry, string key, byte[] value)
        {
            
        }
    }
}