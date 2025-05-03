using System;
using System.Collections.Generic;
using System.Linq;

namespace MotionPlanStandard.Models
{
    public class JointValue
    {
        public double[] values;

        public JointValue(double[] values)
        {
            this.values = values;
        }
        public JointValue(IEnumerable<double> values)
        {
            this.values = values.ToArray();
        }

        public JointValue Clone()
        {
            return new JointValue(values.ToArray());
        }

        public JointValue(int jointCount)
        {
            values=new double[jointCount];
        }
        public double this[int i] => values[i];
        public double Magnitude()
        {
            double sum = 0;
            foreach (var item in values)
            {
                sum += item * item;
            }
            return Math.Sqrt(sum);
        }
        
        public double MagnitudeTake(int count,double factor)
        {
            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += values[i] * values[i];
            }

            for (int i = count; i < values.Length; i++)
            {
                sum += values[i] * values[i]*factor;
            }
            return Math.Sqrt(sum);
        }
        public static double Distance(JointValue argJoints, JointValue startNodeJoints)
        {
            double sum = 0;
            for (int i = 0; i < argJoints.values.Length; i++)
            {
                // sum += Math.Pow(argJoints.values[i] - startNodeJoints.values[i], 2);
                sum += (argJoints.values[i] - startNodeJoints.values[i])*
                       (argJoints.values[i] - startNodeJoints.values[i]);
            }
            return Math.Sqrt(sum);
        }

        public double Product()
        {
            return values.Aggregate((a, b) => a * b);
        }
        public static JointValue operator -(JointValue a, JointValue b)
        {
            return new JointValue(
                a.values.Zip(b.values, (aa, bb) => aa - bb).ToArray());
        }
        public static JointValue operator +(JointValue a, JointValue b)
        {
            return new JointValue(
                a.values.Zip(b.values, (aa, bb) => aa + bb).ToArray());
        }
        public static JointValue operator *(JointValue a, double b)
        {
            return new JointValue(
                a.values.Select(x => x * b).ToArray());
        }
        public static JointValue operator /(JointValue a, JointValue b)
        {
            return new JointValue(
                Enumerable.Range(0, a.values.Length)
                    .Select(i => a.values[i] / b.values[i]));
        }
        public static JointValue operator *(JointValue a, JointValue b)
        {
            return new JointValue(
                Enumerable.Range(0, a.values.Length)
                    .Select(i => a.values[i] * b.values[i]));
        }

        public override bool Equals(object obj)
        {
            if (obj is JointValue jv)
            {
                if (ReferenceEquals(this, jv))
                    return true;
                if (jv.values==null&&values==null)
                {
                    return true;
                }else if (jv==null||values==null)
                {
                    return false;
                }
                if (values.Length != jv.values.Length)
                    return false;
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] != jv.values[i])
                        return false;
                }
                return true;
            }
            return base.Equals(obj);
        }

        public JointValue Normalized()
        {
            double len = Magnitude();
            return new JointValue(
                values.Select(x => x / len).ToArray());
        }
    }
}