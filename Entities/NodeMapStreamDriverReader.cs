using System.Collections.Generic;
using System.IO;

namespace NodeMaps.Entities
{
    public class NodeMapStreamReader
    {
        private readonly BinaryReader _streamReader;

        public NodeMapStreamReader(Stream streamBase)
        {
            _streamReader = new BinaryReader(streamBase);
        }
    }
}