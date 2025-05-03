
namespace MotionPlanStandard.Models
{
    public class Node
    {
        public JointValue Joints { get; set; }
        public Node Parent { get; set; }

        public Node(JointValue Joints,  Node parentNode = null)
        {
            this.Joints = Joints;
            Parent = parentNode;
        }
    }
}