namespace EmlToMsg
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.Button btnSelectTarget;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblTarget;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.btnSelectTarget = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.Location = new System.Drawing.Point(30, 30);
            this.btnSelectSource.Size = new System.Drawing.Size(180, 30);
            this.btnSelectSource.Text = "Select EML Folder";
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(220, 30);
            this.lblSource.Size = new System.Drawing.Size(520, 30);
            // 
            // btnSelectTarget
            // 
            this.btnSelectTarget.Location = new System.Drawing.Point(30, 70);
            this.btnSelectTarget.Size = new System.Drawing.Size(180, 30);
            this.btnSelectTarget.Text = "Select MSG Output Folder";
            this.btnSelectTarget.Click += new System.EventHandler(this.btnSelectTarget_Click);
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(220, 70);
            this.lblTarget.Size = new System.Drawing.Size(520, 30);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(30, 120);
            this.btnConvert.Size = new System.Drawing.Size(180, 40);
            this.btnConvert.Text = "Convert .eml → .msg";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 200);
            this.Controls.Add(this.btnSelectSource);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.btnSelectTarget);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.btnConvert);
            this.Text = "EML to MSG Converter";
            this.ResumeLayout(false);
        }
    }
}