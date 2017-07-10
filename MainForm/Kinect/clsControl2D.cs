using Commons;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        private int hitTimes, counter, sensitivity;
        private Queue<float> track;

        /// <summary>
        /// 坐标信息
        /// </summary>
        public string DataInfo { get => dataInfo; }

        /// <summary>
        /// 点击次数
        /// </summary>
        public int HitTimes { get => hitTimes; }

        /// <summary>
        /// 右手5个轨迹点
        /// </summary>
        public Queue<float> Track { get => track; }

        /// <summary>
        /// 触键灵敏度
        /// </summary>
        public int Sensitivity { get => sensitivity; set => sensitivity = value; }

        public clsControl2D() {
            bodies = new clsBodies();
            device.FrameArrivedHandler += Frame_Arrived;
            material = new clsMaterials();
            rightHand = new Gesture.RightHandLocation(tmps, material);
            track = new Queue<float>();
            sensitivity = 20;
        }

        /// <summary>
        /// 打开设备
        /// </summary>
        public void Start() {
            device.Start();
        }

        /// <summary>
        /// 关闭设备
        /// </summary>
        public void Close() {
            device.Close();
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~clsControl2D() {
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

        /// <summary>
        /// 记录轨迹数组
        /// </summary>
        private void GetTrack() {
            if (track.Count <= 5)
                track.Enqueue(rightHand.Z);
            else {
                track.Enqueue(rightHand.Z);
                track.Dequeue();
            }
            float tmp = GetVariance();
            // Debug.WriteLine(tmp);
            if (tmp > sensitivity) {
                counter += 1;
                if (counter >= 2) {
                    hitTimes += 1;
                    counter = 0;
                }
                Debug.WriteLine("点击次数" + hitTimes);
                for (int i = 0; i < track.Count; i++) {
                    track.Dequeue();
                }
            }
        }

        /// <summary>
        /// 计算轨迹数组的方差
        /// </summary>
        /// <returns></returns>
        private float GetVariance() {
            float ave = 0, variance = 0;
            foreach (float i in track) {
                ave += i;
            }
            ave /= track.Count;
            foreach (float i in track) {
                variance += (i - ave) * (i - ave) / track.Count;
            }
            return variance;
        }

        /// <summary>
        /// 绘制函数
        /// </summary>
        public void Draw() {
            if (tmps != null) {
                rightHand.Joint = tmps[0].Joints[JointType.HandRight];
                dataInfo = "右手位置：(" + rightHand.X + "," + rightHand.Y + ")";
                GetTrack();
                rightHand.Draw2D();
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
