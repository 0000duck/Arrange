using OpenTK;
using System.Windows.Forms;

namespace MainForm.SubForms {
    public partial class KeyBoardForm : Form {
        private Kinect.clsControl2D control;
        private Models.Texture tex;
        private Models.TestShape test;
        private Models.Point point;

        public KeyBoardForm() {
            InitializeComponent();
            control = new Kinect.clsControl2D();
            control.drawGameEventHandler += Control_DrawGame;
            tex = new Models.Texture(@"../../../大软键盘.bmp");
            Height = tex.ImageHeight;
            Width = tex.ImageWidth;
            test = new Models.TestShape();
            point = new Models.Point(new Vector2(0, 0));
            panel2D1.Draw();
            control.Start();
        }

        ~KeyBoardForm() {
            control.Close();
        }

        private void Control_DrawGame() {
            panel2D1.Draw();
            toolStripStatusLabel1.Text = control.DataInfo;
        }

        private void Canvas2D_DrawGame() {
            point.X = panel2D1.MouseLocation.X - Width / 2 + 8;
            point.Y = -(panel2D1.MouseLocation.Y - Height / 2) - 24;
            point.X /= 4.6f;
            point.Y /= 1.2f;

            Text = "(" + point.X + "," + point.Y
                + ")窗口宽度" + Width + "，窗口长度" + Height;

            if (tex != null)
                tex.Draw2D();
            point.Draw2D();

            if (control == null) {
                control = new Kinect.clsControl2D();
                return;
            }
            control.Draw();
        }
    }
}
