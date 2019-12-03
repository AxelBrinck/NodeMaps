using System;
using NodeMaps.Entities;
using NodeMaps.Formatting;

namespace NodeMaps.Drivers
{
    public class NodeMapDriver<T>
    {
        private readonly INodeMapFormat<T> _format;
        
        public NodeMapDriver(INodeMapFormat<T> format)
        {
            _format = format;
            GotoNodeId(0);
        }

        public void GotoNodeId(long nodeId) => _format.GotoNodeId(nodeId);

        public T GetData() => _format.GetData();

        public void Move(Direction direction, bool force = false)
        {
            if (force && _format.GetTargetNodeId(direction) == -1)
            {
                CreateNode(direction);
            }
            
            _format.GotoNodeId(_format.GetTargetNodeId(direction));
        }

        public void CreateNode(Direction direction)
        {
            var sourceId = _format.CurrentId;
            var createdId = _format.CreateEmptyNode();
            _format.SetTargetNodeId(DirectionTools.GetOpposite(direction), sourceId);
            GotoNodeId(sourceId);
            _format.SetTargetNodeId(direction, createdId);
        }
    }
}