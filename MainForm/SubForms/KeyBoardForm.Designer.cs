namespace MainForm.SubForms {
    partial class KeyBoardForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel2D1 = new UcCanvas2D.Panel2D();
            this.SuspendLayout();
            // 
            // panel2D1
            // 
            this.panel2D1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2D1.Location = new System.Drawing.Point(0, 0);
            this.panel2D1.Name = "panel2D1";
            this.panel2D1.Size = new System.Drawing.Size(490, 354);
            this.panel2D1.TabIndex = 0;
            this.panel2D1.DrawGame += new UcCanvas2D.Panel2D.DrawGameEventHandler(this.Canvas2D_DrawGame);
            // 
            // KeyBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 354);
            this.Controls.Add(this.panel2D1);
            this.Name = "KeyBoardForm";
            this.Text = "KeyBoardForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UcCanvas2D.Panel2D panel2D1;
    }
}
