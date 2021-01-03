// Type: UnityEngine.Vector3d
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll
using System;
using System.Runtime.CompilerServices;

namespace UnityEngine {
    public struct Vector3d {
        public const float kEpsilon = 1E-05f;
        public double x;
        public double y;
        public double z;

        public double this[int index] {
            get {
                switch (index) {
                    case 0:
                        return this.x;
                    case 1:
                        return this.y;
                    case 2:
                        return this.z;
                    default:
                        throw new IndexOutOfRangeException("Invalid index!");
                }
            }
            set {
                switch (index) {
                    case 0:
                        this.x = value;
                        break;
                    case 1:
                        this.y = value;
                        break;
                    case 2:
                        this.z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3d index!");
                }
            }
        }

        public Vector3d normalized {
            get {
                return Vector3d.Normalize(this);
            }
        }

        public double magnitude {
            get {
                return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
            }
        }

        public double sqrMagnitude {
            get {
                return this.x * this.x + this.y * this.y + this.z * this.z;
            }
        }

        public static Vector3d zero {
            get {
                return new Vector3d(0d, 0d, 0d);
            }
        }

        public static Vector3d one {
            get {
                return new Vector3d(1d, 1d, 1d);
            }
        }

        public static Vector3d forward {
            get {
                return new Vector3d(0d, 0d, 1d);
            }
        }

        public static Vector3d back {
            get {
                return new Vector3d(0d, 0d, -1d);
            }
        }

        public static Vector3d up {
            get {
                return new Vector3d(0d, 1d, 0d);
            }
        }

        public static Vector3d down {
            get {
                return new Vector3d(0d, -1d, 0d);
            }
        }

        public static Vector3d left {
            get {
                return new Vector3d(-1d, 0d, 0d);
            }
        }

        public static Vector3d right {
            get {
                return new Vector3d(1d, 0d, 0d);
            }
        }

        [Obsolete("Use Vector3d.forward instead.")]
        public static Vector3d fwd {
            get {
                return new Vector3d(0d, 0d, 1d);
            }
        }

        public Vector3d(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3d(float x, float y, float z) {
            this.x = (double)x;
            this.y = (double)y;
            this.z = (double)z;
        }

        public Vector3d(Vector3 v3) {
            this.x = (double)v3.x;
            this.y = (double)v3.y;
            this.z = (double)v3.z;
        }

        public Vector3d(double x, double y) {
            this.x = x;
            this.y = y;
            this.z = 0d;
        }

        public static Vector3d operator +(Vector3d a, Vector3d b) {
            return new Vector3d(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3d operator -(Vector3d a, Vector3d b) {
            return new Vector3d(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3d operator -(Vector3d a) {
            return new Vector3d(-a.x, -a.y, -a.z);
        }

        public static Vector3d operator *(Vector3d a, double d) {
            return new Vector3d(a.x * d, a.y * d, a.z * d);
        }

        public static Vector3d operator *(double d, Vector3d a) {
            return new Vector3d(a.x * d, a.y * d, a.z * d);
        }

        public static Vector3d operator /(Vector3d a, double d) {
            return new Vector3d(a.x / d, a.y / d, a.z / d);
        }

        public static bool operator ==(Vector3d lhs, Vector3d rhs) {
            return (double)Vector3d.SqrMagnitude(lhs - rhs) < 0.0 / 1.0;
        }

        public static bool operator !=(Vector3d lhs, Vector3d rhs) {
            return (double)Vector3d.SqrMagnitude(lhs - rhs) >= 0.0 / 1.0;
        }

        public static explicit operator Vector3(Vector3d vector3d) {
            return new Vector3((float)vector3d.x, (float)vector3d.y, (float)vector3d.z);
        }

        public static Vector3d Lerp(Vector3d from, Vector3d to, double t) {
            t = Mathd.Clamp01(t);
            return new Vector3d(from.x + (to.x - from.x) * t, from.y + (to.y - from.y) * t, from.z + (to.z - from.z) * t);
        }

        public static Vector3d Slerp(Vector3d from, Vector3d to, double t) {
            Vector3 v3 = Vector3.Slerp((Vector3)from, (Vector3)to, (float)t);
            return new Vector3d(v3);
        }

        public static void OrthoNormalize(ref Vector3d normal, ref Vector3d tangent) {
            Vector3 v3normal = new Vector3();
            Vector3 v3tangent = new Vector3();
            v3normal = (Vector3)normal;
            v3tangent = (Vector3)tangent;
            Vector3.OrthoNormalize(ref v3normal, ref v3tangent);
            normal = new Vector3d(v3normal);
            tangent = new Vector3d(v3tangent);
        }

        public static void OrthoNormalize(ref Vector3d normal, ref Vector3d tangent, ref Vector3d binormal) {
            Vector3 v3normal = new Vector3();
            Vector3 v3tangent = new Vector3();
            Vector3 v3binormal = new Vector3();
            v3normal = (Vector3)normal;
            v3tangent = (Vector3)tangent;
            v3binormal = (Vector3)binormal;
            Vector3.OrthoNormalize(ref v3normal, ref v3tangent, ref v3binormal);
            normal = new Vector3d(v3normal);
            tangent = new Vector3d(v3tangent);
            binormal = new Vector3d(v3binormal);
        }

        public static Vector3d MoveTowards(Vector3d current, Vector3d target, double maxDistanceDelta) {
            Vector3d vector3 = target - current;
            double magnitude = vector3.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == 0.0d)
                return target;
            else
                return current + vector3 / magnitude * maxDistanceDelta;
        }

        public static Vector3d RotateTowards(Vector3d current, Vector3d target, double maxRadiansDelta, double maxMagnitudeDelta) {
            Vector3 v3 = Vector3.RotateTowards((Vector3)current, (Vector3)target, (float)maxRadiansDelta, (float)maxMagnitudeDelta);
            return new Vector3d(v3);
        }

        public static Vector3d SmoothDamp(Vector3d current, Vector3d target, ref Vector3d currentVelocity, double smoothTime, double maxSpeed) {
            double deltaTime = (double)Time.deltaTime;
            return Vector3d.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        public static Vector3d SmoothDamp(Vector3d current, Vector3d target, ref Vector3d currentVelocity, double smoothTime) {
            double deltaTime = (double)Time.deltaTime;
            double maxSpeed = double.PositiveInfinity;
            return Vector3d.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        public static Vector3d SmoothDamp(Vector3d current, Vector3d target, ref Vector3d currentVelocity, double smoothTime, double maxSpeed, double deltaTime) {
            smoothTime = Mathd.Max(0.0001d, smoothTime);
            double num1 = 2d / smoothTime;
            double num2 = num1 * deltaTime;
            double num3 = (1.0d / (1.0d + num2 + 0.479999989271164d * num2 * num2 + 0.234999999403954d * num2 * num2 * num2));
            Vector3d vector = current - target;
            Vector3d vector3_1 = target;
            double maxLength = maxSpeed * smoothTime;
            Vector3d vector3_2 = Vector3d.ClampMagnitude(vector, maxLength);
            target = current - vector3_2;
            Vector3d vector3_3 = (currentVelocity + num1 * vector3_2) * deltaTime;
            currentVelocity = (currentVelocity - num1 * vector3_3) * num3;
            Vector3d vector3_4 = target + (vector3_2 + vector3_3) * num3;
            if (Vector3d.Dot(vector3_1 - current, vector3_4 - vector3_1) > 0.0) {
                vector3_4 = vector3_1;
                currentVelocity = (vector3_4 - vector3_1) / deltaTime;
            }
            return vector3_4;
        }

        public void Set(double new_x, double new_y, double new_z) {
            this.x = new_x;
            this.y = new_y;
            this.z = new_z;
        }

        public static Vector3d Scale(Vector3d a, Vector3d b) {
            return new Vector3d(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public void Scale(Vector3d scale) {
            this.x *= scale.x;
            this.y *= scale.y;
            this.z *= scale.z;
        }

        public static Vector3d Cross(Vector3d lhs, Vector3d rhs) {
            return new Vector3d(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
        }

        public override int GetHashCode() {
            return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2;
        }

        public override bool Equals(object other) {
            if (!(other is Vector3d))
                return false;
            Vector3d vector3d = (Vector3d)other;
            if (this.x.Equals(vector3d.x) && this.y.Equals(vector3d.y))
                return this.z.Equals(vector3d.z);
            else
                return false;
        }

        public static Vector3d Reflect(Vector3d inDirection, Vector3d inNormal) {
            return -2d * Vector3d.Dot(inNormal, inDirection) * inNormal + inDirection;
        }

        public static Vector3d Normalize(Vector3d value) {
            double num = Vector3d.Magnitude(value);
            if (num > 9.99999974737875E-06)
                return value / num;
            else
                return Vector3d.zero;
        }

        public void Normalize() {
            double num = Vector3d.Magnitude(this);
            if (num > 9.99999974737875E-06)
                this = this / num;
            else
                this = Vector3d.zero;
        }
        public override string ToString() {
            return "(" + this.x + ", " + this.y + ", " + this.z + ")";
        }

        public static double Dot(Vector3d lhs, Vector3d rhs) {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }

        public static Vector3d Project(Vector3d vector, Vector3d onNormal) {
            double num = Vector3d.Dot(onNormal, onNormal);
            if (num < 1.40129846432482E-45d)
                return Vector3d.zero;
            else
                return onNormal * Vector3d.Dot(vector, onNormal) / num;
        }

        public static Vector3d Exclude(Vector3d excludeThis, Vector3d fromThat) {
            return fromThat - Vector3d.Project(fromThat, excludeThis);
        }

        public static double Angle(Vector3d from, Vector3d to) {
            return Mathd.Acos(Mathd.Clamp(Vector3d.Dot(from.normalized, to.normalized), -1d, 1d)) * 57.29578d;
        }

        public static double Distance(Vector3d a, Vector3d b) {
            Vector3d vector3d = new Vector3d(a.x - b.x, a.y - b.y, a.z - b.z);
            return Math.Sqrt(vector3d.x * vector3d.x + vector3d.y * vector3d.y + vector3d.z * vector3d.z);
        }

        public static Vector3d ClampMagnitude(Vector3d vector, double maxLength) {
            if (vector.sqrMagnitude > maxLength * maxLength)
                return vector.normalized * maxLength;
            else
                return vector;
        }

        public static double Magnitude(Vector3d a) {
            return Math.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
        }

        public static double SqrMagnitude(Vector3d a) {
            return a.x * a.x + a.y * a.y + a.z * a.z;
        }

        public static Vector3d Min(Vector3d lhs, Vector3d rhs) {
            return new Vector3d(Mathd.Min(lhs.x, rhs.x), Mathd.Min(lhs.y, rhs.y), Mathd.Min(lhs.z, rhs.z));
        }

        public static Vector3d Max(Vector3d lhs, Vector3d rhs) {
            return new Vector3d(Mathd.Max(lhs.x, rhs.x), Mathd.Max(lhs.y, rhs.y), Mathd.Max(lhs.z, rhs.z));
        }

        [Obsolete("Use Vector3d.Angle instead. AngleBetween uses radians instead of degrees and was deprecated for this reason")]
        public static double AngleBetween(Vector3d from, Vector3d to) {
            return Mathd.Acos(Mathd.Clamp(Vector3d.Dot(from.normalized, to.normalized), -1d, 1d));
        }
    }
}
