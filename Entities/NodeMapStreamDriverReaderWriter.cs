using System;
using System.IO;

namespace NodeMaps.Entities
{
    public class NodeMapStreamReaderWriter : NodeMapStreamReader
    {
        private readonly StreamWriter _streamWriter;
        
        public NodeMapStreamReaderWriter(Stream streamBase) : base(streamBase)
        {
            _streamWriter = new StreamWriter(streamBase);
        }

        public void Initialize(int referenceCount)
        {
            if (_streamWriter.BaseStream.Length > 0) 
                throw new Exception("Cannot initialize a non-empty stream.");

            WriteEmptyHeader(new NodeMapReferenceAddress(new NodeMapHeaderAddress(0), 0), referenceCount);
        }

        public void Create(NodeMapReferenceAddress address, int referenceCount)
        {
            WriteEmptyHeader(address, referenceCount);
        }

        private void WriteEmptyHeader(NodeMapReferenceAddress address, int referenceCount)
        {
            _streamWriter.BaseStream.Position = address.ReferenceStreamPosition;
            
            _streamWriter.Write((long) -1);
            _streamWriter.Write(referenceCount);
            
            for (var i = 0; i < referenceCount; i++)
                _streamWriter.Write((long) -1);

            _streamWriter.BaseStream.Position = 0;
        }
    }
}