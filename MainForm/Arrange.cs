using System;
using System.Windows.Forms;
using Models;
using System.IO;


namespace MainForm {
    public partial class Arrange : Form {
        clsModel Model;
        private clsControl control;


        public Arrange() {
            InitializeComponent();
            control = new clsControl();
            control.drawGameEventHandler += Control_DrawGame;
        }

        /// <summary>
        /// 添加选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_Models_Adding(object sender, EventArgs e) {
            Model = new clsModel();
            ucCanvas3D1.Draw();
        }

        private void Canvas3D_DrawGame() {
            if (Model != null)//添加模型
                Model.Draw(ucCanvas3D1.Materials);
            if (control == null) {
                control = new clsControl();
                return;
            }
            control.Draw();//添加Kinect
        }

        private void Control_DrawGame() {
            ucCanvas3D1.Draw();
        }

        /// <summary>
        /// 开始选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_Control_Adding(object sender, EventArgs e) {
            control.Start();
        }

        private void OnRecord(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();

            StreamWriter streamwriter;
            sfd.InitialDirectory = "E:\\";
            sfd.Filter = "dat文件(*.dat)|*.dat";
            if (sfd.ShowDialog() == DialogResult.OK) {
                streamwriter = new StreamWriter(sfd.FileName);
                var recorder = control.GetSingleBodyFrame();
                foreach (var i in recorder) {
                    streamwriter.WriteLine(i.Item1.getX().ToString() +
                        "," + i.Item1.getY().ToString() +
                        "," + i.Item1.getZ().ToString() +
                        " " + i.Item2.getX().ToString() +
                        "," + i.Item2.getY().ToString() +
                        "," + i.Item2.getZ().ToString());
                }
                streamwriter.Close();
            }
        }

        private void OnQuit(object sender, FormClosingEventArgs e) {
            control.Close();
        }
    }
}
