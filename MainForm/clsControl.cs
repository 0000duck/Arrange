using System.Collections.Generic;
using Microsoft.Kinect;
using Controls;
using System.Diagnostics;
using System.IO;

namespace MainForm {
    class clsControl {
        private clsKinect device = clsKinect.Device;
        private clsBodies bodies;
        private Body[] tmps;

        private int index = 0;
        public event UcCanvas3D.DrawGameEventHandler drawGameEventHandler;

        public clsControl() {
            bodies = new clsBodies();
            device.FrameArrivedHandler += Frame_Arrived;
        }

        public void start() {
            device.Start();
        }

        public void close() {
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
                    bodies.Append(joints);
                    drawGameEventHandler();
                    Draw();
                    index += 1;
                    //
                }
            }


        }
        public void Draw() {
            Debug.WriteLine("6");
            bodies.Draw(index);
        }

        public void writeData(StreamWriter swa) {
            swa.Write(bodies.ToString());
        }
    }
}
