using XPlanStandard.Models.Planner.Multi;

namespace MotionPlanStandard.Servies
{
    /// <summary>
    /// 多机器人路径规划接口
    /// </summary>
    public interface IMultiRobotPlanner
    {
        IMultiPlanResult Solve(IMultiTask task);
    }

}