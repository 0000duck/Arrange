using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Commons {
    public enum MaterialType {
        CommonBox,// 盒子
        ActiveBox,//盒子（选中）
        BoundingBox,//盒子的包围盒
        GameBoxFrame,
        GameBoxBed,
        AxisOrgin,
        AxisX,
        AxisY,
        AxisZ
    }
    public class clsMaterials {
        private XmlElement MaterialConfig;

        public clsMaterials() {
            XmlDocument XML = new XmlDocument();
            XML.LoadXml(Commons.Properties.Resources.ConfigMaterial);
            XmlElement node = (XmlElement)XML.SelectSingleNode("Materials");
            MaterialConfig = node;
        }

        public void SetMaterial(MaterialType mt) {
            string MType = "";
            switch (mt) {
                case MaterialType.CommonBox:
                    MType = "CommonBox"; break;
                case MaterialType.ActiveBox:
                    MType = "ActiveBox"; break;
                case MaterialType.BoundingBox:
                    MType = "BoundingBox"; break;
                case MaterialType.GameBoxFrame:
                    MType = "GameBoxFrame"; break;
                case MaterialType.GameBoxBed:
                    MType = "GameBoxBed"; break;
                case MaterialType.AxisX:
                    MType = "AxisX"; break;
                case MaterialType.AxisY:
                    MType = "AxisY"; break;
                case MaterialType.AxisZ:
                    MType = "AxisZ"; break;
                case MaterialType.AxisOrgin:
                    MType = "AxisOrgin"; break;
            }
            XmlElement node = (XmlElement)MaterialConfig.SelectSingleNode(MType);
            string ambient, diffuse, specular, emission, shininess;
            ambient = node.SelectSingleNode("ambient").InnerXml;
            diffuse = node.SelectSingleNode("diffuse").InnerXml;
            specular = node.SelectSingleNode("specular").InnerXml;
            emission = node.SelectSingleNode("emission").InnerXml;
            shininess = node.SelectSingleNode("shininess").InnerXml;

            clsMaterial objMT = new clsMaterial(ambient, diffuse, specular,
                emission, shininess);
            objMT.SetMaterial();
        }

    }
}
