using Commons;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace Canvas2D.Models {
    public class Point : Frame {
        private int R;
        Vector3 point;
        GlobalMaterials globalMaterial;

        public float X { get => point.X; set => point.X = value; }
        public float Y { get => point.Y; set => point.Y = value; }
        public float Z { get => point.Z; set => point.Z = value; }

        public Vector3 Location { get => point; set => point = value; }

        public override void Draw() {
            IntPtr pObj = OpenTK.Graphics.Glu.NewQuadric();
            double _SphereRadius = 1;
            GL.Flush();
            GL.PushMatrix();
            GL.Translate(point.X, point.Y, point.Z);
            OpenTK.Graphics.Glu.Sphere(pObj, _SphereRadius, 10, 10);
            GL.PopMatrix();
            pObj = IntPtr.Zero;
        }

        public override void Draw2D() {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.DepthTest);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GlobalMaterials.SetMaterial(MaterialType.AxisY);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(X - 3, Y);
            GL.Vertex2(X + 3, Y);
            GL.End();
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(X, Y + 10);
            GL.Vertex2(X, Y - 10);
            GL.End();
        }

        public Point(Vector3 p) {
            point = p;
            R = 5;
        }

        public Point(Vector2 p) {
            point = new Vector3(p.X, p.Y, 0);
            R = 5;
        }

        public Point(float x, float y) {
            point = new Vector3(x, y, 0);
        }

        public Point(Gesture.JointVector p) {
            point = new Vector3(p.X, p.Y, p.Z);
            R = 5;
        }
    }
}
