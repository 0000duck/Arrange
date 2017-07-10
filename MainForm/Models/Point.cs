using Commons;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace MainForm.Models {
    public class Point : Frame {
        private int R;
        Vector3 point;
        clsMaterials globalMaterial;

        public float X { get => point.X; set => point.X = value; }
        public float Y { get => point.Y; set => point.Y = value; }
        public float Z { get => point.Z; set => point.Z = value; }

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
            globalMaterial.SetMaterial(MaterialType.AxisY);
            //GL.Begin(PrimitiveType.TriangleStrip);
            //for (int i = 0; i < 30; ++i) {
            //    GL.Vertex2(R * Math.Cos(2 * Math.PI / 6 * i) + X / 4, R *
            //        Math.Sin(2 * Math.PI / 6 * i) + Y / 4);
            //}
            //GL.End();
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(X - 3, Y);
            GL.Vertex2(X + 3, Y);
            GL.End();
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(X, Y + 10);
            GL.Vertex2(X, Y - 10);
            GL.End();
        }

        public Point(Vector3 p, clsMaterials material) {
            point = p;
            globalMaterial = material;
            R = 5;
        }

        public Point(Vector2 p, clsMaterials material) {
            point = new Vector3(p.X, p.Y, 0);
            globalMaterial = material;
            R = 5;
        }

        public Point(Vector2 p) {
            point = new Vector3(p.X, p.Y, 0);
            globalMaterial = new clsMaterials();
            R = 5;
        }

        public Point(JointVector p, clsMaterials material) {
            point = new Vector3(p.X, p.Y, p.Z);
            globalMaterial = material;
            R = 5;
        }
    }
}
