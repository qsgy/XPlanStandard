namespace MotionPlanStandard.Models.Net
{
    /// <summary>
    /// 单机路径规划请求
    /// </summary>
    public class SinglePathPlanTask
    {
        public double[] startJoints;
        public double[] endJoints;
        public byte RobotJointCount=6;//通常是6轴
    }
    public class PathJoints
    {
        public double[][] Joints;
    }
    
    public class MotionCheck
    {
        public double[] StartJoint;
        public double[] EndJoint;
        public MotionCheckType type;
    }
    public class StateCheck
    {
        public double[] Joint;
    }
}
