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
        }
        
        public Node CurrentNode { get; private set; }

        public void MoveLeft()
        {
            
        }

        public void MoveRight()
        {
            
        }

        public void MoveUp()
        {
            
        }

        public void MoveDown()
        {
            
        }

        public void MoveFront()
        {
            
        }

        public void MoveBack()
        {
            
        }

        public void CreateNodeLeft(Node node)
        {
            
        }

        public void CreateNodeRight(Node node)
        {
            
        }

        public void CreateNodeUp(Node node)
        {
            
        }

        public void CreateNodeDown(Node node)
        {
            
        }

        public void CreateNodeFront(Node node)
        {
            
        }

        public void CreateNodeBack(Node node)
        {
            
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