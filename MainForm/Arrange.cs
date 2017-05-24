using System;
using System.Windows.Forms;
using Models;


namespace MainForm {
    public partial class Arrange : Form {
        clsModel Model;
        private clsControl control;
        private int n = 0;


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
            control.start();
        }


    }
}
