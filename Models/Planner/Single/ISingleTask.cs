using System;
using System.Collections.Generic;
using MotionPlanStandard.Models;

namespace XPlanStandard.Models.Planner.Single
{
    public interface ISingleTask
    {
        /// <summary>
        /// 关节最大硬限位.软限位作碰撞处理。
        /// </summary>
        JointValue MaxHardLimit { set; get; }
        /// <summary>
        /// 关节最小硬限位.软限位作碰撞处理。
        /// </summary>
        JointValue MinHardLimit { set; get; }
        /// <summary>
        /// 每条路径的最大迭代次数。设置0或负数，不启用.默认启用。
        /// </summary>
        int MaxIterationPerPath { get; set; }
        /// <summary>
        /// 每条路径的最大计算时长。设置Zero或负数不启用。默认不启用
        /// </summary>
        TimeSpan MaxComputeTimePerPath { get; set; }
    }

    public class SinglePathTask4PDPS : SinglePathTaskBase
    {
        /// <summary>
        /// 返回null代表无碰撞。返回碰撞的JointValue。
        /// 建议使用PS的simulatePlay来进行检验。最好支持RCS。
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="phase"></param>
        /// <returns></returns>
        public Func<JointValue, JointValue, JointValue> MotionCheck { get; set; }
    }
    public class SinglePathTaskBase : ISingleTask
    {
        /// <summary>
        /// 目标路径点
        /// </summary>
        public List<JointValue> TargetJoints { get; set; }
        public JointValue MaxHardLimit { get; set; }
        public JointValue MinHardLimit { get; set; }
        public int MaxIterationPerPath { get; set; } = 40000;
        public TimeSpan MaxComputeTimePerPath { get; set; }
        /// <summary>
        /// 轴值碰撞检测。软限位作碰撞处理。这个输入是必须的。
        /// </summary>
        Func<JointValue, bool> StateCheck { get; set; }
        /// <summary>
        /// 暂停计算信号.设置null则不启用
        /// </summary>
        Func<bool> StopSignal { get; set; }
        /// <summary>
        /// 焊枪轴值正方向为开口。在UseGunAxis为True，UseConstantGunAxis为null时，该变量将影响规划成功的效率。
        /// </summary>
        public bool GunPlusOpen { get; set; }
        /// <summary>
        /// 使用焊枪轴。设置false则规划时不考虑焊枪轴（第七轴），目标路径点使用6个double。
        /// </summary>
        public bool UseGunAxis { get; set; }
        /// <summary>
        /// 使用固定焊枪轴值。如果不为null，将使用你设置的焊枪轴值进行规划。
        /// </summary>
        public double? UseConstantGunAxis { get; set; }
        /// <summary>
        /// int PathID目前规划到第几个路径（从0开始），int Iteration目前路径迭代次数，string msg消息提示。
        /// </summary>
        public Action<int, int, string> OnLog { get; set; }
    }
}