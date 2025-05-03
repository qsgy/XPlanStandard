using System.Numerics;

namespace MotionPlanStandard.Models
{
    /// <summary>
    /// 一次点焊任务的数据
    /// </summary>
    public class WeldTaskModel
    {
        
    }
    /// <summary>
    /// 描述机器人
    /// </summary>
    public class WdRobotModel
    {
        public WdJointModel[] joints;
        
    }

    public class WdJointModel
    {
        public double currentValue;
        public double lowerLimit;
        public double upperLimit;
        public WdJointType type;
        public Vector3 axis;
        public Pose pose;
    }
    
    public enum WdJointType
    {
        /// <summary>Rotational joint.</summary>
        Revolute = 1,
        /// <summary>Prismatic joint.</summary>
        Prismatic = 2,
    }

    public class Pose
    {
        public Vector3 position=new Vector3();
        public Vector3 rotationEuler=new Vector3();
    }
}