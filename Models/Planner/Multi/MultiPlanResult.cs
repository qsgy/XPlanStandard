using System.Collections.Generic;
using MotionPlanStandard.Models;

namespace XPlanStandard.Models.Planner.Multi
{
    public class MultiPlanResult : IMultiPlanResult
    {
        //机器人索引，焊点分段，路径点. 第一个和最后一个是home点。每段的最后一个是焊点（除了最后一段）
        public List<JointValue>[][] Paths { get; set; }
        //等待关系. 路径需要等待目标路径完成。
        public List<(int robTarget, int segTargetIndex, int robWaiter, int segWaiterIndex)> WaitRelations;
        public List<(string failMsg, int robIndex, int weldIndex, int weldSegIndex)> FailMsgs
             = new List<(string failMsg, int robIndex, int weldIndex, int weldSegIndex)>();
    }

}