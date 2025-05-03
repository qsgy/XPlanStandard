using System;
using System.ComponentModel;

namespace MotionPlanStandard
{
    public class DebugModel
    {
        public static DebugModel instance=new DebugModel();
        [Description("规划每帧等待时间")]
        public int waitTime { set; get; } = 0;
        [Description("碰撞时停止")]
        public bool StopOnCollision { get; set; } = false;

        public int MaxPlanIteration { get; set; } = 50000;//每条路径最多迭代次数 
        [Description("rrt最大步长")]
        public double rrtMaxV { get; set; } = 6;

        [Description("碰撞检测插值密度因子")]
        public float Interpolation { get; set; } = 1;

        [Description("焊枪轴值加速倍数")]
        public double gunMoveFactor { get; set; } = 15;

        [Description("终起最大碰撞次数")]
        public int MaxCollisionCountOnStartEnd { get; set; } = 3000;
        [Description("启用软限")]
        public bool SoftLimit { get; set; } = true;

        [Description("优化时使用安全距离")] public bool NearMissOnOptimize { get; set; } = true;
        [Description("使用固定焊枪开口轴值测试")] public bool ConstantGunAxis { get; set; } = false;
        [Description("焊接咬合时间")]
        public double WeldTime { get; set; } = 0.78;
        [Description("清除扫掠体")]
        public bool DeleteVols { get; set; } = true;

        [Description("多机测试集索引")]
        public int testMultiIndex { get; set; } = 0;


        public bool continuCollision = false;
        [Description("计算时显示UI更新")]
        public bool ShowUIUpdate=false;

        public bool AutoSetHomeJoint = false;
        public bool Authorized = false;//是否授权

        [Description("多机算法最大消耗时间")] 
        public float W2wCalcuWaitTimeMIN { get; set; } = 30;
        [Description("多机算法有解后继续计算时长")] 
        public float W2wSolvedWaitTime { get; set; } = 2;

        public bool DevMode { get; set; } = false;
        public string LogFilePath { get; set; } = "E:/XLog/log.txt";

        [Description("扫掠体计算轨迹干涉")] 
        public bool UseSwepVolume { get; set; } = false;

        [Description("固定apf频率，而不是通过时才apf")] 
        public bool FixedApf { get; set; }=true;
        [Description("apf排斥力的距离")] 
        public double ApfNearDis { get; set; } = 200;

        [Description("规划器")] public PlanType planType { get; set; } = PlanType.RrtApf;
        [Description("apf牵引速度。恒定斥力使用")] 
        public double ApfVelocity { get; set; } = 0.6f;
        [Description("规划过程可视化start树")] 
        public bool DisplayStart { get; set; }=false;
        [Description("rrt随机次数.目前仅CApfRrt使用")] 
        public int rrtRandCount { get; set; } = 10;
        [Description("CApfRrt滑行次数")] 
        public int SlideCount { get; set; } = 20;

        //多机
        public bool Runing;//todo 统一使用一个开关

        // public DebugModel()
        // {
        //     instance = this;
        // }
        public enum PlanType
        {
            RrtApf,//历史碰撞点建立的排斥力
            CApfRrt,//3维空间映射C空间恒定排斥力
            VsampleRrt,//体采样的rrt
        }
    }
}