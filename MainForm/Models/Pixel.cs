using Commons;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MainForm.Models {
    public class Pixel : Frame {
        int imagewidth, imageheight;
        string path;
        clsMaterials globalMaterial;
        List<byte> listOfBytes;

        public override void Draw() {
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Color3(Color.Red);
            GL.DrawPixels(1920, 1080, PixelFormat.Bgr,
                            PixelType.UnsignedByte, listOfBytes.ToArray());
        }

        public Pixel(string path, clsMaterials material) {
            this.path = path;
            globalMaterial = material;
            FileStream fileStream = new FileStream(path,
              FileMode.Open);
            fileStream.Seek(0x0012, SeekOrigin.Begin);
            /*imagewidth = fileStream.ReadByte() * 24 +
                 fileStream.ReadByte() * 16 +
                 fileStream.ReadByte() * 8 +
                 fileStream.ReadByte();
             imageheight = fileStream.ReadByte() * 24 +
                 fileStream.ReadByte() * 16 +
                 fileStream.ReadByte() * 8 +
                 fileStream.ReadByte();*/
            listOfBytes = new List<byte>();
            int bs;
            while ((bs = fileStream.ReadByte()) != -1) {
                listOfBytes.Add((byte)bs);
            }
            fileStream.Close();
        }

        public Pixel() {
            globalMaterial = new clsMaterials();
        }

        public Pixel(clsMaterials material) {
            globalMaterial = material;
        }
    }
}
