using Commons;
using Microsoft.Kinect;
using System.Collections.Generic;

namespace MainForm.Gesture {
    class RightHandLocation : NodeLocation {
        private JointVector jointVector;
        private clsMaterials globalMaterial;
        public float X { get => jointVector.X; set => jointVector.X = value; }
        public float Y { get => jointVector.Y; set => jointVector.Y = value; }
        public float Z { get => jointVector.Z; set => jointVector.Z = value; }

        public RightHandLocation(Body body) {
            IReadOnlyDictionary<JointType, Joint> joints
                = body.Joints;
            jointVector = new JointVector(
                  joints[JointType.HandRight].Position);
            globalMaterial = new clsMaterials();
        }

        public RightHandLocation(Body body, clsMaterials materials) {
            IReadOnlyDictionary<JointType, Joint> joints
                = body.Joints;
            jointVector = new JointVector(
                joints[JointType.HandRight].Position);
            globalMaterial = materials;
        }

        public RightHandLocation(Body[] bodys, clsMaterials materials) {
            if (bodys != null) {
                IReadOnlyDictionary<JointType, Joint> joints =
                    bodys[0].Joints;
                jointVector = new JointVector(
                    joints[JointType.HandRight].Position);
            }
            globalMaterial = materials;
        }

        public RightHandLocation() { }

        public override void Draw() {
            jointVector.CoordinateTransform();
            jointVector.Draw();
        }

        public override void Draw2D() {
            if (jointVector == null) { return; }
            Models.Point point = new Models.Point(jointVector, globalMaterial);
            point.Draw2D();
        }
    }
}
