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
            _format.Id = 0;
        }

        public Node CurrentNode => _format.CurrentNode;

        public void MoveLeft()
        {
            _format.Id = CurrentNode.LeftId;
        }

        public void MoveRight()
        {
            _format.Id = CurrentNode.RightId;
        }

        public void MoveUp()
        {
            _format.Id = CurrentNode.UpId;
        }

        public void MoveDown()
        {
            _format.Id = CurrentNode.DownId;
        }

        public void MoveFront()
        {
            _format.Id = CurrentNode.FrontId;
        }

        public void MoveBack()
        {
            _format.Id = CurrentNode.BackId;
        }

        public void CreateNodeLeft()
        {
            var sourceId = _format.Id;
            var newId =  _format.GetEmptyId();
            _format.LeftNodeId = newId;
            var node = new Node(newId, -1, -1, _format.Id, -1, -1, -1, -1);
            _format.CurrentNode = node;
            _format.Id = sourceId;
        }

        public void CreateNodeRight()
        {
            var sourceId = _format.Id;
            var newId =  _format.GetEmptyId();
            _format.RightNodeId = newId;
            var node = new Node(newId, -1, _format.Id, -1, -1, -1, -1, -1);
            _format.CurrentNode = node;
            _format.Id = sourceId;
        }

        public void CreateNodeUp()
        {
            var sourceId = _format.Id;
            var newId =  _format.GetEmptyId();
            _format.UpNodeId = newId;
            var node = new Node(newId, -1, -1, -1, -1, _format.Id, -1, -1);
            _format.CurrentNode = node;
            _format.Id = sourceId;
        }

        public void CreateNodeDown()
        {
            var sourceId = _format.Id;
            var newId =  _format.GetEmptyId();
            _format.DownNodeId = newId;
            var node = new Node(newId, -1, -1, -1, _format.Id, -1, -1, -1);
            _format.CurrentNode = node;
            _format.Id = sourceId;
        }

        public void CreateNodeFront()
        {
            var sourceId = _format.Id;
            var newId =  _format.GetEmptyId();
            _format.FrontNodeId = newId;
            var node = new Node(newId, -1, -1, -1, -1, -1, -1, _format.Id);
            _format.CurrentNode = node;
            _format.Id = sourceId;
        }

        public void CreateNodeBack()
        {
            var sourceId = _format.Id;
            var newId =  _format.GetEmptyId();
            _format.BackNodeId = newId;
            var node = new Node(newId, -1, -1, -1, -1, -1, _format.Id, -1);
            _format.CurrentNode = node;
            _format.Id = sourceId;
        }

        public void DeleteNodeLeft()
        {
            
        }

        public void DeleteNodeRight()
        {
            
        }

        public void DeleteNodeUp()
        {
            
        }

        public void DeleteNodeDown()
        {
            
        }

        public void DeleteNodeFront()
        {
            
        }

        public void DeleteNodeBack()
        {
            
        }

        public void IntercalateNodeLeft(Node node)
        {
            
        }

        public void IntercalateNodeRight(Node node)
        {
            
        }

        public void IntercalateNodeUp(Node node)
        {
            
        }

        public void IntercalateNodeDown(Node node)
        {
            
        }

        public void IntercalateNodeFront(Node node)
        {
            
        }

        public void IntercalateNodeBack(Node node)
        {
            
        }

        public void LinkLeft(Node target)
        {
            var sourceId = _format.Id;
            _format.LeftNodeId = target.Id;
            _format.CurrentNode = target;
            _format.RightNodeId = sourceId;
            _format.Id = sourceId;
        }

        public void LinkRight(Node target)
        {
            var sourceId = _format.Id;
            _format.RightNodeId = target.Id;
            _format.CurrentNode = target;
            _format.LeftNodeId = sourceId;
            _format.Id = sourceId;
        }

        public void LinkUp(Node target)
        {
            var sourceId = _format.Id;
            _format.UpNodeId = target.Id;
            _format.CurrentNode = target;
            _format.DownNodeId = sourceId;
            _format.Id = sourceId;
        }

        public void LinkDown(Node target)
        {
            var sourceId = _format.Id;
            _format.DownNodeId = target.Id;
            _format.CurrentNode = target;
            _format.UpNodeId = sourceId;
            _format.Id = sourceId;
        }

        public void LinkFront(Node target)
        {
            var sourceId = _format.Id;
            _format.FrontNodeId = target.Id;
            _format.CurrentNode = target;
            _format.BackNodeId = sourceId;
            _format.Id = sourceId;
        }

        public void LinkBack(Node target)
        {
            var sourceId = _format.Id;
            _format.BackNodeId = target.Id;
            _format.CurrentNode = target;
            _format.FrontNodeId = sourceId;
            _format.Id = sourceId;
        }

        public void UnlinkLeft()
        {
            var sourceId = _format.Id;
            MoveLeft();
            _format.RightNodeId = -1;
            _format.Id = sourceId;
            _format.LeftNodeId = -1;
        }

        public void UnlinkRight()
        {
            var sourceId = _format.Id;
            MoveRight();
            _format.LeftNodeId = -1;
            _format.Id = sourceId;
            _format.RightNodeId = -1;
        }
        
        public void UnlinkUp()
        {
            var sourceId = _format.Id;
            MoveUp();
            _format.DownNodeId = -1;
            _format.Id = sourceId;
            _format.UpNodeId = -1;
        }

        public void UnlinkDown()
        {
            var sourceId = _format.Id;
            MoveDown();
            _format.UpNodeId = -1;
            _format.Id = sourceId;
            _format.DownNodeId = -1;
        }

        public void UnlinkFront()
        {
            var sourceId = _format.Id;
            MoveFront();
            _format.BackNodeId = -1;
            _format.Id = sourceId;
            _format.FrontNodeId = -1;
        }

        public void UnlinkBack()
        {
            var sourceId = _format.Id;
            MoveBack();
            _format.FrontNodeId = -1;
            _format.Id = sourceId;
            _format.BackNodeId = -1;
        }
    }
}