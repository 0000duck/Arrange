using Commons;
using OpenTK.Graphics.OpenGL;
using System;

namespace MainForm.Models {
    class TestShape : Frame {
        clsMaterials material;
        public override void Draw() {
            throw new NotImplementedException();
        }

        public override void Draw2D() {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.DepthTest);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            material.SetMaterial(MaterialType.ActiveBox);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(11, 11);
            GL.Vertex2(21, 11);
            GL.Vertex2(21, 0);
            GL.Vertex2(-11, 1);
            GL.End();
        }

        public TestShape(clsMaterials material) {
            this.material = material;
        }

        public TestShape() {
            material = new clsMaterials();
        }
    }
}
