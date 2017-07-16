using Commons;
using Microsoft.Kinect;
using System.Collections.Generic;

namespace Canvas2D.Gesture {
    class RightHandLocation : NodeLocation {
        private Models.Point point;
        private JointVector jointVector;
        private GlobalMaterials globalMaterial;
        public float X { get => jointVector.X; set => jointVector.X = value; }
        public float Y { get => jointVector.Y; set => jointVector.Y = value; }
        public float Z { get => jointVector.Z; set => jointVector.Z = value; }

        public Joint Joint;

        public RightHandLocation(Body body) {
            IReadOnlyDictionary<JointType, Joint> joints
                = body.Joints;
            jointVector = new JointVector(
                  joints[JointType.HandRight].Position);
            globalMaterial = new GlobalMaterials();
            point = new Models.Point(jointVector, globalMaterial);
        }

        public RightHandLocation(Body body, GlobalMaterials materials) {
            IReadOnlyDictionary<JointType, Joint> joints
                = body.Joints;
            jointVector = new JointVector(
                joints[JointType.HandRight].Position);
            globalMaterial = materials;
        }

        public RightHandLocation(Body[] bodys, GlobalMaterials materials) {
            if (bodys != null) {
                IReadOnlyDictionary<JointType, Joint> joints =
                    bodys[0].Joints;
                jointVector = new JointVector(
                    joints[JointType.HandRight].Position);
            } else {
                jointVector = new JointVector();
            }
            globalMaterial = materials;
            point = new Models.Point(jointVector, globalMaterial);
        }

        public RightHandLocation() { }

        public override void Draw() {
            jointVector.CoordinateTransform();
            jointVector.Draw();
        }

        public override void Draw2D() {
            point.X = 100 * Joint.Position.X;
            point.Y = 100 * Joint.Position.Y;
            point.Z = 100 * Joint.Position.Z;
            jointVector.X = 100 * Joint.Position.X;
            jointVector.Y = 100 * Joint.Position.Y;
            jointVector.Z = 100 * Joint.Position.Z;
            point.Draw2D();
        }
    }
}
