using System;
using System.Collections.Generic;
using System.Text;
using XPlanStandard.Models.Planner.Multi;
using XPlanStandard.Models.Planner.Single;

namespace XPlanStandard.Services
{
    public interface ISingleRobotPlanner
    {
        ISinglePlanResult Solve(ISingleTask task);
    }
}
