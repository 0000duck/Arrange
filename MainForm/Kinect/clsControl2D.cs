using Commons;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;

namespace MainForm.Kinect {
    class clsControl2D {
        private clsKinect device = clsKinect.Device;
        private clsBodies bodies;
        private Body[] tmps;
        clsMaterials material;
        Gesture.RightHandLocation rightHand;
        private int index = 0;
        public event UcCanvas3D.Panel3D.DrawGameEventHandler drawGameEventHandler;
        private string dataInfo;

        public string DataInfo { get => dataInfo; }

        public clsControl2D() {
            bodies = new clsBodies();
            device.FrameArrivedHandler += Frame_Arrived;
            material = new clsMaterials();
            rightHand = new Gesture.RightHandLocation(tmps, material);
        }

        public void Start() {
            device.Start();
        }

        public void Close() {
            device.Close();
        }

        public void Frame_Arrived(object sender, BodyFrameArrivedEventArgs e) {
            bool dataReceived = false;
            using (BodyFrame bodyframe = e.FrameReference.AcquireFrame()) {
                if (bodyframe != null) {
                    if (tmps == null) {
                        tmps = new Body[bodyframe.BodyCount];
                    }
                    bodyframe.GetAndRefreshBodyData(tmps);
                    dataReceived = true;
                }
            }

            if (!dataReceived)
                return;

            foreach (var _body in tmps) {
                if (_body.IsTracked) {
                    IReadOnlyDictionary<JointType, Joint> joints = _body.Joints;
                    bodies.Append(ref joints);
                    drawGameEventHandler();
                    index += 1;
                }
            }
        }

        public void Draw() {
            bodies.Draw(index);
            if (tmps != null) {
                rightHand.Joint = tmps[0].Joints[JointType.HandRight];
                dataInfo = "右手位置：(" + rightHand.X + "," + rightHand.Y + ")";
                rightHand.Draw2D();//TODO: 测试
            }
        }

        public List<Tuple<clsVector3, clsVector3>> GetSingleBodyFrame() {
            clsBodies temp = new clsBodies();
            try {
                IReadOnlyDictionary<JointType, Joint> joints = tmps[0].Joints;
                temp.Append(ref joints);
                return temp.GetSingleBodyFrame(0);
            } catch {
                throw new Exception("尚未捕捉到0号身体的骨骼数据");
            }
        }
    }
}
