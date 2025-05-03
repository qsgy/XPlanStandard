using System;
using System.Collections.Generic;
using MotionPlanStandard.Models;

namespace XPlanStandard.Models.Planner.Multi
{
    public class MultiWeldTask : IMultiTask
    {
        public List<JointValue>[] Paths { get; set; }
        public (JointValue min, JointValue max)[] MinMaxJoints { get; set; }
        //JointValue设置为null时不调整pose。
        public Func<(int robA, int robB)[]> GetCollisionStatus;
        public Action<JointValue[]> SetJoints;
        public bool UseNearMiss { get; set; } = false;
        public TimeSpan MaxComputeTime { get; set; }
        public int MaxIterations { get; set; } = 3000000;
        public int robotJointCount { get; set; } = 6;
        /// <summary>
        /// int机器人索引，JoinValue from,JointValue to,MotionCheckType type，double steptime
        /// return 
        /// </summary>
        public Func<int, JointValue, JointValue, MotionCheckPhase, double, (JointValue[] interpoJoints, double cosTime)>
            MotionCheck
        { get; set; }
        //机器人干涉的焊点位置。 机器人i ，int 本体所在焊点索引，干涉机器人索引，干涉机器人焊点索引。
        public HashSet<(int, int, int)>[] CollisionWeldLocations { get; set; }
        public double WeldingTime = 2;
        public bool OpenAxisGun { get; set; } = true;//使用动态轴值，开口轴值方向为正

        public Action<string> OnLog { get; set; }
        public Action<int> WaitFrames { get; set; }
    }

}