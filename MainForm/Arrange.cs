using System;
using System.Windows.Forms;
using Models;


namespace MainForm {
    public partial class Arrange : Form {
        clsModel Model;



        public Arrange() {
            InitializeComponent();
        }

        private void On_Models_Adding(object sender, EventArgs e) {
            Model = new clsModel();
            ucCanvas3D1.Draw();
        }

        private void Canvas3D_DrawGame() {
            if (Model != null)
                Model.Draw(ucCanvas3D1.Materials);
        }
    }
}
