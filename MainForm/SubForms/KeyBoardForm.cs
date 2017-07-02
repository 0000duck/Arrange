using System.Windows.Forms;

namespace MainForm.SubForms {
    public partial class KeyBoardForm : Form {
        private clsControl control;
        Models.Pixel pix;

        public KeyBoardForm() {
            InitializeComponent();
            control = new clsControl();
            control.drawGameEventHandler += Control_DrawGame;

            pix = new Models.Pixel(
                @"C:\Users\Siyu\Pictures\1.bmp",
                panel2D1.Materials);
            //throw new Exception("尚未确定键盘图案");
            pix.Draw();
            panel2D1.Draw();
        }

        private void Control_DrawGame() {
            panel2D1.Draw();
        }

        private void Canvas2D_DrawGame() {
            if (pix != null)
                pix.Draw();
            if (control == null) {
                control = new clsControl();
                return;
            }
            control.Draw();
        }
    }
}
