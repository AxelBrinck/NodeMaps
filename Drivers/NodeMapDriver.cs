using NodeMaps.Entities;
using NodeMaps.Formatting;

namespace NodeMaps.Drivers
{
    public class NodeMapDriver<T>
    {
        private readonly INodeMapFormat<T> _format;

        private void Move(long id)
        {
            _format.Id = id;
            CurrentNode = _format.CurrentNode;
        }

        public NodeMapDriver(INodeMapFormat<T> format)
        {
            _format = format;
            _format.Id = 0;
            CurrentNode = _format.CurrentNode;
        }
        
        public Node CurrentNode { get; private set; }

        public void MoveLeft()
        {
            Move(CurrentNode.LeftId);
        }

        public void MoveRight()
        {
            Move(CurrentNode.RightId);
        }

        public void MoveUp()
        {
            Move(CurrentNode.UpId);
        }

        public void MoveDown()
        {
            Move(CurrentNode.DownId);
        }

        public void MoveFront()
        {
            Move(CurrentNode.FrontId);
        }

        public void MoveBack()
        {
            Move(CurrentNode.BackId);
        }

        public void CreateNodeLeft(Node node)
        {
            CurrentNode = new Node(
                CurrentNode.Id,
                CurrentNode.DataId,
                node.Id,
                CurrentNode.RightId,
                CurrentNode.UpId,
                CurrentNode.DownId,
                CurrentNode.FrontId,
                CurrentNode.BackId);
            _format.CurrentNode = CurrentNode;
        }

        public void CreateNodeRight(Node node)
        {
            CurrentNode = new Node(
                CurrentNode.Id,
                CurrentNode.DataId,
                CurrentNode.LeftId,
                node.Id,
                CurrentNode.UpId,
                CurrentNode.DownId,
                CurrentNode.FrontId,
                CurrentNode.BackId);
            _format.CurrentNode = CurrentNode;
        }

        public void CreateNodeUp(Node node)
        {
            CurrentNode = new Node(
                CurrentNode.Id,
                CurrentNode.DataId,
                CurrentNode.LeftId,
                CurrentNode.RightId,
                node.Id,
                CurrentNode.DownId,
                CurrentNode.FrontId,
                CurrentNode.BackId);
            _format.CurrentNode = CurrentNode;
        }

        public void CreateNodeDown(Node node)
        {
            CurrentNode = new Node(
                CurrentNode.Id,
                CurrentNode.DataId,
                CurrentNode.LeftId,
                CurrentNode.RightId,
                CurrentNode.UpId,
                node.Id,
                CurrentNode.FrontId,
                CurrentNode.BackId);
            _format.CurrentNode = CurrentNode;
        }

        public void CreateNodeFront(Node node)
        {
            CurrentNode = new Node(
                CurrentNode.Id,
                CurrentNode.DataId,
                CurrentNode.LeftId,
                CurrentNode.RightId,
                CurrentNode.UpId,
                CurrentNode.DownId,
                node.Id,
                CurrentNode.BackId);
            _format.CurrentNode = CurrentNode;
        }

        public void CreateNodeBack(Node node)
        {
            CurrentNode = new Node(
                CurrentNode.Id,
                CurrentNode.DataId,
                CurrentNode.LeftId,
                CurrentNode.RightId,
                CurrentNode.UpId,
                CurrentNode.DownId,
                CurrentNode.FrontId,
                node.Id);
            _format.CurrentNode = CurrentNode;
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