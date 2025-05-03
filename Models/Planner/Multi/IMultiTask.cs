using System;

namespace XPlanStandard.Models.Planner.Multi
{
    public interface IMultiTask
    {
        /// <summary>
        /// 最大计算时长。设置Zero或负数不启用。默认不启用
        /// </summary>
        TimeSpan MaxComputeTime { get; set; }
        /// <summary>
        /// 最大迭代次数。设置0或负数，不启用.默认启用。
        /// </summary>
        int MaxIterations { get; set; }
    }
}