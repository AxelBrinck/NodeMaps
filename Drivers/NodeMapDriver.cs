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

        public void SetData(T data) => _format.SetData(data);

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

        public void IntercalateNewNode(Direction direction)
        {
            var sourceId = _format.CurrentId;
            var finalId = _format.GetTargetNodeId(direction);
            var intermediateId = _format.CreateEmptyNode();
            _format.SetTargetNodeId(direction, finalId);
            _format.SetTargetNodeId(DirectionTools.GetOpposite(direction), sourceId);
            GotoNodeId(finalId);
            _format.SetTargetNodeId(DirectionTools.GetOpposite(direction), intermediateId);
            GotoNodeId(sourceId);
            _format.SetTargetNodeId(direction, intermediateId);
        }

        public void Link(Direction direction, long targetNode)
        {
            _format.SetTargetNodeId(direction, targetNode);
        }

        public void Unlink(Direction direction)
        {
            _format.SetTargetNodeId(direction, -1);
        }
    }
}