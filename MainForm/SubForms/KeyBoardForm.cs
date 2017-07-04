using System.Windows.Forms;

namespace MainForm.SubForms {
    public partial class KeyBoardForm : Form {
        private Kinect.clsControl2D control;
        private Models.Texture tex;
        private Models.TestShape test;

        public KeyBoardForm() {
            InitializeComponent();
            control = new Kinect.clsControl2D();
            control.drawGameEventHandler += Control_DrawGame;
            tex = new Models.Texture(@"../../../大软键盘.bmp");
            Height = tex.ImageHeight;
            Width = tex.ImageWidth;
            test = new Models.TestShape();
            panel2D1.Draw();
        }

        private void Control_DrawGame() {
            panel2D1.Draw();
        }

        private void Canvas2D_DrawGame() {
            if (tex != null)
                tex.Draw2D();
            test.Draw2D();
            if (control == null) {
                control = new Kinect.clsControl2D();
                return;
            }
            control.Draw();
        }
    }
}
