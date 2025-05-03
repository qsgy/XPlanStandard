using System.Collections.Generic;
using System;
using MotionPlanStandard.Models;
using System.IO;
using System.Threading.Tasks;

namespace MotionPlanStandard.Servies
{
    public interface IPlannerAsync:IPlanner
    {
        Task<PlanResult> SolveAsync(bool resetStart = true, bool resetEnd = true);
        Func<Task> WaitUpdate { get; set; }
    }
    public interface IPlanner
    {
        event Action<int, string> OnIterat;
        List<Node> RrtTreeStart { get; set; }
        List<Node> RrtTreeEnd { get; set; }
        JointValue StartJoint { get; set; }
        JointValue EndJoint { get; set; }
        JointValue MaxJointValue { set; get; }
        JointValue MinJointValue { set; get; }
        int MaxIterationPerPath { get; set; }
        PlanResult Solve(bool resetStart = true, bool resetEnd = true);
        Action<int> WaitFrames { get; set; }
        Func<JointValue,bool> StateCheck { get; set; }
        Func<bool> StopSignal { get; set; }//停止信号
        bool GunPlusOpen { get; set; } //焊枪轴值正方向为开口

        /// <summary>
        /// 返回null代表无碰撞。返回碰撞的JointValue
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="phase"></param>
        /// <returns></returns>
        Func<JointValue, JointValue, MotionCheckPhase, JointValue> MotionCheck { get; set; }



        /// <summary>
        /// 直接优化路径
        /// </summary>
        /// <param name="joints"></param>
        void OptimizePath(List<JointValue> joints);

        void OptimizePath(List<JointValue> joints, int homeIndex);
    }
    public interface IPathSimplifier
    {
        bool ReduceVertices();
    }
}


