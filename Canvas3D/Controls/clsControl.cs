using Microsoft.Kinect;
using System;
using System.Collections.Generic;

namespace Canvas3D.Controls {
    /// <summary>
    /// 整个Kinect影像
    /// </summary>
    public class clsControl {
        private clsKinect device = clsKinect.Device;
        private clsBodies bodies;
        private Body[] bodiesAmount;

        /// <summary>
        /// 数据对外接口
        /// </summary>
        public List<clsBody> BodiesDataQueue { get => bodies.BodiesDataQueue; }

        private int index = 0;

        public event Canvas3D.Panel3D.DrawGameHandler DrawGame;

        public clsControl() {
            bodies = new clsBodies();
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
            using (BodyFrame bodyframe = e.FrameReference.AcquireFrame()) {
                if (bodyframe != null) {
                    if (bodiesAmount == null) {
                        bodiesAmount = new Body[bodyframe.BodyCount];
                    }
                    bodyframe.GetAndRefreshBodyData(bodiesAmount);
                    dataReceived = true;

                }
            }

            if (!dataReceived)
                return;

            foreach (var _body in bodiesAmount) {
                if (_body.IsTracked) {
                    IReadOnlyDictionary<JointType, Joint> joints = _body.Joints;
                    bodies.Append(ref joints);
                    DrawGame();
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
                IReadOnlyDictionary<JointType, Joint> joints = bodiesAmount[0].Joints;
                temp.Append(ref joints);
                return temp.GetSingleBodyFrame(0);
            } catch {
                throw new Exception("尚未捕捉到0号身体的骨骼数据");
            }
        }
    }
}
