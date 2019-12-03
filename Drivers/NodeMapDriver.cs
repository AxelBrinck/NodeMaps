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
            var oldAddress = CurrentNode.Id;
            var newAddress =  _format.GetEmptyId();
            _format.LeftNodeId = newAddress;
            var node = new Node(newAddress, -1, -1, _format.Id, -1, -1, -1, -1);
            _format.CurrentNode = node;
            _format.Id = oldAddress;
        }

        public void CreateNodeRight()
        {
            var oldAddress = CurrentNode.Id;
            var newAddress =  _format.GetEmptyId();
            _format.RightNodeId = newAddress;
            var node = new Node(newAddress, -1, _format.Id, -1, -1, -1, -1, -1);
            _format.CurrentNode = node;
            _format.Id = oldAddress;
        }

        public void CreateNodeUp()
        {
            var oldAddress = CurrentNode.Id;
            var newAddress =  _format.GetEmptyId();
            _format.UpNodeId = newAddress;
            var node = new Node(newAddress, -1, -1, -1, -1, _format.Id, -1, -1);
            _format.CurrentNode = node;
            _format.Id = oldAddress;
        }

        public void CreateNodeDown()
        {
            var oldAddress = CurrentNode.Id;
            var newAddress =  _format.GetEmptyId();
            _format.DownNodeId = newAddress;
            var node = new Node(newAddress, -1, -1, -1, _format.Id, -1, -1, -1);
            _format.CurrentNode = node;
            _format.Id = oldAddress;
        }

        public void CreateNodeFront()
        {
            var oldAddress = CurrentNode.Id;
            var newAddress =  _format.GetEmptyId();
            _format.FrontNodeId = newAddress;
            var node = new Node(newAddress, -1, -1, -1, -1, -1, -1, _format.Id);
            _format.CurrentNode = node;
            _format.Id = oldAddress;
        }

        public void CreateNodeBack()
        {
            var oldAddress = CurrentNode.Id;
            var newAddress =  _format.GetEmptyId();
            _format.BackNodeId = newAddress;
            var node = new Node(newAddress, -1, -1, -1, -1, -1, _format.Id, -1);
            _format.CurrentNode = node;
            _format.Id = oldAddress;
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

        public void LinkLeft(Node node)
        {
            
        }

        public void LinkRight(Node node)
        {
            
        }

        public void LinkUp(Node node)
        {
            
        }

        public void LinkDown(Node node)
        {
            
        }

        public void LinkFront(Node node)
        {
            
        }

        public void LinkBack(Node node)
        {
            
        }

        public void UnlinkLeft()
        {
            
        }

        public void UnlinkRight()
        {
            
        }
        
        public void UnlinkUp()
        {
            
        }

        public void UnlinkDown()
        {
            
        }

        public void UnlinkFront()
        {
            
        }

        public void UnlinkBack()
        {
            
        }
    }
}