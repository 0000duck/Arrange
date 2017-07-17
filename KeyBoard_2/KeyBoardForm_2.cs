using OpenTK;
using System.Windows.Forms;

namespace KeyBoard_2 {
    public partial class KeyBoardForm_2 : Form {
        private Canvas2D.Controls.Control_9Key control;
        private Canvas2D.Models.Texture tex;
        private Canvas2D.Models.Point mouseLocation;
        private Canvas2D.Models.Point kiLocation;

        public KeyBoardForm_2() {
            InitializeComponent();
            control = new Canvas2D.Controls.Control_9Key(
                @"D:\RecentHomework\2017大创\temp\Innovation-of-college\MainForm\SubForms\9KeyPosition.xml");
            control.drawGameEventHandler += Control_DrawGame;
            tex = new Canvas2D.Models.Texture(@"D:\RecentHomework\2017大创\temp\Innovation-of-college\新9格键盘.bmp");
            Height = tex.ImageHeight;
            Width = tex.ImageWidth;
            mouseLocation = new Canvas2D.Models.Point(new Vector2(0, 0));
            kiLocation = new Canvas2D.Models.Point(new Vector2(0, 0));
            control.Start();
        }

        ~KeyBoardForm_2() {
            control.Close();
        }

        private void Control_DrawGame() {
            panel2D1.Draw();
            toolStripStatusLabel1.Text = control.DataInfo;
        }

        private void Canvas2D_DrawGame() {
            mouseLocation.X = panel2D1.MouseLocation.X - Width / 2 + 8;
            mouseLocation.Y = -(panel2D1.MouseLocation.Y - Height / 2) - 24;
            mouseLocation.X /= 4.6f;
            mouseLocation.Y /= 1.2f;

            kiLocation.Location = control.NoticePoint;

            Text = "(" + mouseLocation.X + "," + mouseLocation.Y
                + ")窗口宽度" + Width + "，窗口长度" + Height;
            tex.Draw2D();
            kiLocation.Draw2D();
            mouseLocation.Draw2D();
            control.Draw();
        }
    }
}
