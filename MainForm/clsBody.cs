using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using OpenTK;
using static OpenTK.Graphics.Glu;
using OpenTK.Graphics.OpenGL;
using static System.Math;

namespace MainForm {
    public class clsBody {
        private Dictionary<JointType, clsVector3> vectors;
        private constTuples tuples = constTuples.getTuples();
        private double scale;

        public clsBody() {
            vectors = new Dictionary<JointType, clsVector3>();
            scale = 10;
        }

        public void Draw() {
            foreach (var i in vectors) {
                i.Value.changeXYZ();
                i.Value.Draw();
            }

            clsVector3 x, y;
            Tuple<JointType, JointType> tempTuple;
            for (int i = 0; i < constTuples.count - 1; i++) {
                tempTuple = tuples.getTuple(i);
                x = vectors[tempTuple.Item1];
                y = vectors[tempTuple.Item2];

                DrawBone(x, y);
            }
        }

        private Vector3 mul(double a, Vector3 s) {
            s.X *= (float)a;
            s.Y *= (float)a;
            s.Z *= (float)a;
            return s;
        }

        private void DrawBone(clsVector3 x, clsVector3 y) {
            Vector3 a = x.getVec();
            Vector3 b = y.getVec();
            IntPtr pObj = NewQuadric();
            GL.PushMatrix();
            Vector3 o = new Vector3(0, 0, 1);
            Vector3 xy = new Vector3(b - a);
            double cosa = (o.X * xy.X + o.Y * xy.Y + o.Z * xy.Z)
                / (Sqrt(xy.X * xy.X + xy.Y * xy.Y + xy.Z * xy.Z));
            double acra = Atan(-cosa / Sqrt(-cosa * cosa + 1)) + 2 * Atan(1);
            acra = acra * 180 / PI;
            double length = Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) *
                (b.Y - a.Y) + (b.Z - a.Z) * (b.Z - a.Z));
            GL.PushMatrix();


            GL.Translate(mul(scale, a));
            Vector3 norm = Vector3.Cross(o, (b - a));
            norm.Normalize();

            GL.Rotate(acra, norm.X, norm.Y, norm.Z);
            Cylinder(pObj, 0.1, 0.1, length * 10, 10, 1);
            GL.PopMatrix();
            pObj = IntPtr.Zero;
            GL.PopMatrix();
            pObj = IntPtr.Zero;
        }

        public void Append(Joint j) {
            vectors.Add(j.JointType, new clsVector3(j.Position));
        }

        public override string ToString() {
            string str = "";

            foreach (var i in vectors) {
                str += i.Value.getX().ToString() + "," +
                    i.Value.getY().ToString() + "," +
                    i.Value.getZ().ToString();

            }

            return str;
        }
    }
}
