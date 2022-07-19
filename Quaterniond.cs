// Type: UnityEngine.Quaterniond
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll
using System;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
    public struct Quaterniond
    {
        public const float kEpsilon = 1E-05f;
        public double w;
        public double x;
        public double y;
        public double z;

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.w;
                    case 1:
                        return this.x;
                    case 2:
                        return this.y;
                    case 3:
                        return this.z;
                    default:
                        throw new IndexOutOfRangeException("Invalid index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.w = value;
                        break;
                    case 1:
                        this.x = value;
                        break;
                    case 2:
                        this.y = value;
                        break;
                    case 3:
                        this.z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaterniond index!");
                }
            }
        }

        public Quaterniond normalized
        {
            get
            {
                return Quaterniond.Normalize(this);
            }
        }

        public double magnitude
        {
            get
            {
                return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
            }
        }

        public double sqrMagnitude
        {
            get
            {
                return this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w;
            }
        }

        public static Quaterniond zero
        {
            get
            {
                return new Quaterniond(0d, 0d, 0d, 0d);
            }
        }

        public static Quaterniond one
        {
            get
            {
                return new Quaterniond(1d, 1d, 1d, 1d);
            }
        }

        public Quaterniond(double w, double x, double y, double z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Quaterniond(float w, float x, float y, float z)
        {
            this.w = (double)w;
            this.x = (double)x;
            this.y = (double)y;
            this.z = (double)z;
        }

        public Quaterniond(Quaternion q)
        {
            this.w = (double)q.w;
            this.x = (double)q.x;
            this.y = (double)q.y;
            this.z = (double)q.z;
        }

        public Quaterniond(float w, Vector3 v)
        {
            this.w = (double)w;
            this.x = (double)v.x;
            this.y = (double)v.y;
            this.z = (double)v.z;
        }

        public Quaterniond(double w, Vector3d v)
        {
            this.w = w;
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public static Quaterniond operator +(Quaterniond a, Quaterniond b)
        {
            return new Quaterniond(a.w + b.w, a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Quaterniond operator -(Quaterniond a, Quaterniond b)
        {
            return new Quaterniond(a.w - b.w, a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Quaterniond operator -(Quaterniond a)
        {
            return new Quaterniond(-a.w, - a.x, -a.y, -a.z);
        }

        public static Quaterniond operator *(Quaterniond a, double d)
        {
            return new Quaterniond(a.w * d, a.x * d, a.y * d, a.z * d);
        }

        public static Quaterniond operator *(double d, Quaterniond a)
        {
            return new Quaterniond(a.w * d, a.x * d, a.y * d, a.z * d);
        }

        public static Quaterniond operator *(Quaterniond a, Quaterniond b)
        {
            return new Quaterniond(
            a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z,
            a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y,
            a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x,
            a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w);
        }

        public static Vector3d operator *(Quaterniond q, Vector3d v)
        {
            Vector3d u = new Vector3d(q.x, q.y, q.z);
            double s = q.w;
            var new_v = 2.0d * Vector3d.Dot(u, v) * u + (s * s - Vector3d.Dot(u, u)) * v + 2.0d * s * Vector3d.Cross(u, v);
            return new_v;
        }

        public static Quaterniond operator /(Quaterniond a, double d)
        {
            return new Quaterniond(a.w / d, a.x / d, a.y / d, a.z / d);
        }

        public void Set(double new_x, double new_y, double new_z, double new_w)
        {
            this.x = new_x;
            this.y = new_y;
            this.z = new_z;
            this.w = new_w;
        }

        public static Quaterniond Normalize(Quaterniond value)
        {
            double num = Quaterniond.Magnitude(value);
            if (num > 9.99999974737875E-06)
                return value / num;
            else
                return Quaterniond.zero;
        }

        public void Normalize()
        {
            double num = Quaterniond.Magnitude(this);
            if (num > 9.99999974737875E-06)
                this = this / num;
            else
                this = Quaterniond.zero;
        }

        public override string ToString()
        {
            return "(" + this.w + "," + this.x + ", " + this.y + ", " + this.z + ")";
        }

        public static double Magnitude(Quaterniond a)
        {
            return Math.Sqrt(a.w * a.w + a.x * a.x + a.y * a.y + a.z * a.z);
        }

        public static double SqrMagnitude(Quaterniond a)
        {
            return a.x * a.x + a.y * a.y + a.z * a.z + a.w * a.w;
        }

    }

}