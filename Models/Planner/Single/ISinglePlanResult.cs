using System.Collections.Generic;
using MotionPlanStandard.Models;

namespace XPlanStandard.Models.Planner.Single
{
    public interface ISinglePlanResult
    {
        /// <summary>
        /// 最终规划路径。每两个输入路径点之间的过度点。
        /// </summary>
        List<JointValue>[] Path { get; set; }
        /// <summary>
        /// 全部路径成功
        /// </summary>
        bool AllSuccess { get; set; }
        /// <summary>
        /// 每条路径是否成功
        /// </summary>
        bool[] SuccessStatus { get; set; }
        /// <summary>
        /// 总共迭代次数
        /// </summary>
        int AllIteration { get; set; }
        /// <summary>
        /// 每条路径的迭代次数
        /// </summary>
        int[] Iterations { get; set; }
        /// <summary>
        /// 每条路径的消息。失败原因。
        /// </summary>
        string[] Message { get; set; }
    }
    public class SinglePlanResult: ISinglePlanResult
    {
        public List<JointValue>[] Path { get; set; }
        public bool AllSuccess { get; set; }
        public int Iteration { get; set; }
        public bool[] SuccessStatus { get; set; }
        public int AllIteration { get; set; }
        public int[] Iterations { get; set; }
        public string[] Message { get; set; }
    }
}