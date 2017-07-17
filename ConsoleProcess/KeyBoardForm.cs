using OpenTK;
using System.Windows.Forms;

namespace ConsoleProcess {
    public partial class KeyBoardForm : Form {
        private Canvas2D.Controls.Control2D control;
        private Canvas2D.Models.Point point;
        private Canvas2D.Models.Texture texture;

        public KeyBoardForm() {
            InitializeComponent();
            control = new Canvas2D.Controls.Control2D();
            control.drawGameEventHandler += Control_DrawGame;
            point = new Canvas2D.Models.Point(new Vector2(0, 0));
            texture = new Canvas2D.Models.Texture(@"../../../大软键盘.bmp");
            control.Start();
            Height = texture.ImageHeight;
            Width = texture.ImageWidth;
        }

        ~KeyBoardForm() {
            control.Close();
        }

        private void Canvas2D_DrawGame() {
            point.X = panel2D1.MouseLocation.X - Width / 2 + 8;
            point.Y = -(panel2D1.MouseLocation.Y - Height / 2) - 24;
            point.X /= 4.6f;
            point.Y /= 1.2f;
            Text = string.Concat("(", point.X, ",", point.Y
                , ")窗口宽度", Width, "，窗口长度", Height);

            texture.Draw2D();
            point.Draw2D();
            control.Draw();
        }

        private void Control_DrawGame() {
            panel2D1.Draw();
            toolStripStatusLabel1.Text = control.DataInfo;
        }
    }
}
