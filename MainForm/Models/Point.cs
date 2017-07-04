using Commons;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace MainForm.Models {
    public class Point : Frame {
        private int R;
        Vector3 point;
        clsMaterials globalMaterial;
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
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            globalMaterial.SetMaterial(MaterialType.ActiveBox);
            GL.Begin(PrimitiveType.Points);
            for (int i = 0; i < 6; ++i) {
                GL.Vertex2(5 * Math.Cos(2 * Math.PI / 6 * i), R *
                    Math.Sin(2 * Math.PI / 6 * i));
            }
            GL.End();
            GL.Flush();
        }

        public Point(Vector3 p, clsMaterials material) {
            point = p;
            globalMaterial = material;
            R = 5;
        }

        public Point(Vector2 p, clsMaterials material) {
            point = new Vector3(p.X, p.Y, 0);
            R = 5;
        }

        public Point(JointVector p, clsMaterials material) {
            point = new Vector3(p.X, p.Y, p.Z);
            R = 5;
        }
    }
}
