using System.Windows.Forms;

namespace TestForm {
    public partial class TestForm : Form {
        private Canvas3D.Controls.clsControl control;

        public TestForm() {
            InitializeComponent();
            control = new Canvas3D.Controls.clsControl();
            control.DrawGame += Control_DrawGame;
            control.Start();
        }

        private void Canvas3D_DrawGame() {
            control.Draw();
        }

        private void Control_DrawGame() {
            panel3D1.Draw();
        }
    }
}
