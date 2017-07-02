using Microsoft.Kinect;
using System;
using System.Collections.Generic;

namespace MainForm {
    /// <summary>
    /// 整个Kinect影像
    /// </summary>
    class clsControl {
        private clsKinect device = clsKinect.Device;
        private clsBodies bodies;
        private List<clsBody> copycat;
        private Body[] tmps;

        private int index = 0;
        public event UcCanvas3D.Panel3D.DrawGameEventHandler drawGameEventHandler;

        public clsControl() {
            bodies = new clsBodies();
            copycat = new List<clsBody>();
            device.FrameArrivedHandler += Frame_Arrived;
        }

        public void Start() {
            device.Start();
        }

        public void Close() {
            device.Close();
        }

        public void Frame_Arrived(object sender, BodyFrameArrivedEventArgs e) {
            bool dataReceived = false;
            using (BodyFrame _bodyframe = e.FrameReference.AcquireFrame()) {
                if (_bodyframe != null) {
                    if (tmps == null) {
                        tmps = new Body[_bodyframe.BodyCount];
                    }
                    _bodyframe.GetAndRefreshBodyData(tmps);
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
