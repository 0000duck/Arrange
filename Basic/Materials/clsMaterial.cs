using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;
using System.Threading.Tasks;

namespace Commons {
    class clsMaterial {
        private string ambient;// 设置环境光反射材质
        private string diffuse;//设置漫反射材质
        private string specular;//设置模型镜面光反射率属性
        private string emission;//材质的辐射颜色
        private string shininess;//镜面指数（光照度）
        private float[] A, D, S, E;
        private float SH;

        public clsMaterial(string sA, string sD, string sS, string sE,
            string sSH) {
            ambient = sA;
            diffuse = sD;
            specular = sS;
            emission = sE;
            shininess = sSH;
            if (ambient != "") A = SplitXML(ambient);
            if (diffuse != "") D = SplitXML(diffuse);
            if (specular != "") S = SplitXML(specular);
            if (emission != "") E = SplitXML(emission);
            if (shininess != "") SH = float.Parse(shininess);
        }

        public void SetMaterial() {
            if (ambient != "") GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Ambient, A);
            if (diffuse != "") GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Diffuse, D);
            if (specular != "") GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, S);
            if (emission != "") GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Emission, E);
            if (shininess != "") GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, SH);
        }

        private float[] SplitXML(string S) {
            string[] stmp = S.Split(',');
            float[] val = new float[4];
            for (int i = 0; i < 4; i++) {
                val[i] = float.Parse(stmp[i]) / 255f;
            }
            return val;
        }
    }
}
