using System.Collections.Generic;
using MotionPlanStandard.Models;

namespace XPlanStandard.Models.Planner.Multi
{
    public interface IMultiPlanResult
    {
        List<JointValue>[][] Paths { get; set; }
    }
}