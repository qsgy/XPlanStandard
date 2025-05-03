namespace MotionPlanStandard.Models
{
    public enum MotionCheckType:byte
    {
        Line=0, //线性插补
        XPlan=1,//X插补
        PdpsMOP=2,//PS默认MOP插补
        CukaRCS=3,
        FanucRCS=4,
        AbbRCS=5,
    }
    /// <summary>
    /// motion check的阶段。算法有规划阶段和优化阶段
    /// </summary>
    public enum MotionCheckPhase
    {
        /// <summary>
        /// 规划阶段.建议使用Line插补
        /// </summary>
        Plan,
        /// <summary>
        /// 轨迹优化阶段.建议使用RCS插补或Default MOP，或梯形图、S形插补算法。
        /// </summary>
        Optimize,
    }
}