namespace ConsoleProcess {
    partial class TestForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.panel3D1 = new Canvas3D.Panel3D();
            this.SuspendLayout();
            // 
            // panel3D1
            // 
            this.panel3D1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3D1.Location = new System.Drawing.Point(0, 0);
            this.panel3D1.Name = "panel3D1";
            this.panel3D1.Size = new System.Drawing.Size(564, 520);
            this.panel3D1.TabIndex = 0;
            this.panel3D1.DrawGame += new Canvas3D.Panel3D.DrawGameHandler(this.Canvas3D_DrawGame);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 520);
            this.Controls.Add(this.panel3D1);
            this.Name = "TestForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Canvas3D.Panel3D panel3D1;
    }
}

