using System;
using System.Collections.Generic;
using Canvas3D.Controls;
using Microsoft.Kinect;
using OpenTK;
using System.Windows.Forms;
using System.Diagnostics;

namespace Canvas2D.Controls {
    public class Control_9Key {
        private clsKinect device = clsKinect.Device;
        private Body[] tmps;
        Gesture.RightHandLocation rightHand;
        private int index = 0;
        public event Canvas3D.Panel3D.DrawGameHandler drawGameEventHandler;
        private string dataInfo;
        private int hitTimes, counter, sensitivity;
        private Queue<float> track;
        private Queue<float> Xtrack;
        private Queue<float> Ytrack;
        private Function.BoardData_9Key keyBoard;
        private string keyText;
        private Vector3 noticePoint;
        private string Direction;
        private int SingleWave;
        private int i_pos, j_pos;
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

        public string KeyText { get => keyText; }

        public Vector3 NoticePoint { get => noticePoint; set => noticePoint = value; }

        public Control_9Key() {
            device.FrameArrivedHandler += Frame_Arrived;
            Commons.GlobalMaterials material = new Commons.GlobalMaterials();
            rightHand = new Gesture.RightHandLocation(tmps, material);
            track = new Queue<float>();
            Xtrack = new Queue<float>();
            Ytrack = new Queue<float>();
            sensitivity = 20;
            //            leftUp= new JointVector();
            keyBoard = new Function.BoardData_9Key(
                @"D:\RecentHomework\2017大创\temp\Innovation-of-college\MainForm\SubForms\9KeyPosition.xml");
            SingleWave = 0;
            i_pos = j_pos = 0;
            noticePoint.X = (keyBoard.keys[i_pos][j_pos].LeftUp.X + keyBoard.keys[i_pos][j_pos].RightDown.X) / 2;
            noticePoint.Y = (keyBoard.keys[i_pos][j_pos].LeftUp.Y + keyBoard.keys[i_pos][j_pos].RightDown.Y) / 2;
            noticePoint.Z = 0;
            Direction = string.Empty;
        }

        public Control_9Key(string path) {
            device.FrameArrivedHandler += Frame_Arrived;
            Commons.GlobalMaterials material = new Commons.GlobalMaterials();
            rightHand = new Gesture.RightHandLocation(tmps, material);
            track = new Queue<float>();
            Xtrack = new Queue<float>();
            Ytrack = new Queue<float>();
            sensitivity = 20;
            //            leftUp= new JointVector();
            keyBoard = new Function.BoardData_9Key(path);
            SingleWave = 0;
            i_pos = j_pos = 0;
            noticePoint.X = (keyBoard.keys[i_pos][j_pos].LeftUp.X + keyBoard.keys[i_pos][j_pos].RightDown.X) / 2;
            noticePoint.Y = (keyBoard.keys[i_pos][j_pos].LeftUp.Y + keyBoard.keys[i_pos][j_pos].RightDown.Y) / 2;
            noticePoint.Z = 0;
            Direction = string.Empty;
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
        ~Control_9Key() {
            device.Close();
        }

        private void Frame_Arrived(object sender, BodyFrameArrivedEventArgs e) {
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
                    drawGameEventHandler();
                    index += 1;
                }
            }
        }

        private void SendSingleKey() {
            keyText = keyBoard.keys[i_pos][j_pos].Character;
            switch (keyText) {
                // TODO:功能键区
                case "isChinese": break;
                case "clear": break;
                case "delete": break;
                case "number": break;
                case "send": break;
                case "space": break;
                default: SendKeys.Send(keyText); break;
            }
        }

        /// <summary>
        /// 记录轨迹数组
        /// </summary>
        private void GetTrack() {
            if (track.Count <= 10) {
                track.Enqueue(rightHand.Z);
                Xtrack.Enqueue(rightHand.X);
                Ytrack.Enqueue(rightHand.Y);
            } else {
                track.Enqueue(rightHand.Z);
                Xtrack.Enqueue(rightHand.X);
                Ytrack.Enqueue(rightHand.Y);
                track.Dequeue();
                Xtrack.Dequeue();
                Ytrack.Dequeue();
            }

            float tmp = GetVariance(track);
            float xtmp = GetVariance(Xtrack);
            float ytmp = GetVariance(Ytrack);
            // Debug.WriteLine(tmp);
            // 点击条件
            if (Xtrack.Count > 1) {
                if (xtmp > sensitivity) {
                    if (Direction.Equals("Small") && SingleWave < 1) {
                        if (j_pos > 0)
                            j_pos--;
                    } else if (SingleWave < 1) {
                        if (j_pos < 3)
                            j_pos++;
                    }
                    track.Clear();
                    Xtrack.Clear();
                    Ytrack.Clear();
                    SingleWave++;
                } else if (ytmp > sensitivity) {
                    if (Direction.Equals("Small") && SingleWave < 1) {
                        if (i_pos < 3)
                            i_pos++;
                    } else if (SingleWave < 1) {
                        if (i_pos > 0)
                            i_pos--;
                    }

                    track.Clear();
                    Xtrack.Clear();
                    Ytrack.Clear();
                    SingleWave++;

                } else if (tmp > sensitivity) {
                    if (Direction.Equals("Small") && SingleWave < 1) {
                        track.Clear();
                        Xtrack.Clear();
                        Ytrack.Clear();
                        SingleWave++;
                        SendSingleKey();//Search函数需要改变
                        Debug.WriteLine("点击次数" + hitTimes);
                    } else if (SingleWave < 1) {
                        track.Clear();
                        Xtrack.Clear();
                        Ytrack.Clear();
                    }
                }
                NoticePoint = new Vector3((keyBoard.keys[i_pos][j_pos].LeftUp.X + keyBoard.keys[i_pos][j_pos].RightDown.X) / 2, (keyBoard.keys[i_pos][j_pos].LeftUp.Y + keyBoard.keys[i_pos][j_pos].RightDown.Y) / 2, 0);
            }
        }

        /// <summary>
        /// 计算轨迹数组的方差
        /// </summary>
        /// <returns></returns>
        private float GetVariance(Queue<float> track) {
            float ave = 0, variance = 0;
            float bef = 0;
            int count = track.Count;
            if (track.Count == 1)
                bef = track.Peek();
            else
                foreach (float i in track) {
                    ave += i;
                    count--;
                    if (count == 2)
                        bef = ave;
                    if (count == 1) {
                        if (bef < ave) {
                            if (Direction.Equals("Small"))
                                SingleWave = 0;
                            Direction = "Big";
                        } else {
                            if (Direction.Equals("Big"))
                                SingleWave = 0;
                            Direction = "Small";
                        }
                    }
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
