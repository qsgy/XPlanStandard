using System.Collections.Generic;

namespace MotionPlanStandard.Models
{
    public class PlanResult
    {
        /// <summary>
        /// 路径
        /// </summary>
        public List<JointValue> Path { get; set; }
        public List<JointValue> OriginPath { get; set; }
        public bool Success { get; set; }
        public int Iteration { get; set; }
        public string Message { get; set; }

    }
}


