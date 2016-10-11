namespace SheetIndex
{
    partial class MainInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProcessing1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the folder of PDF from consultants for this issue.";
            // 
            // btnSelFolder
            // 
            this.btnSelFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelFolder.Location = new System.Drawing.Point(301, 9);
            this.btnSelFolder.Name = "btnSelFolder";
            this.btnSelFolder.Size = new System.Drawing.Size(86, 23);
            this.btnSelFolder.TabIndex = 1;
            this.btnSelFolder.Text = "Select Folder";
            this.btnSelFolder.UseVisualStyleBackColor = true;
            this.btnSelFolder.Click += new System.EventHandler(this.btnSelFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(15, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(453, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(393, 9);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "OK";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 69);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(453, 23);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // lblProcessing1
            // 
            this.lblProcessing1.AutoSize = true;
            this.lblProcessing1.Location = new System.Drawing.Point(15, 107);
            this.lblProcessing1.Name = "lblProcessing1";
            this.lblProcessing1.Size = new System.Drawing.Size(35, 13);
            this.lblProcessing1.TabIndex = 5;
            this.lblProcessing1.Text = "label2";
            this.lblProcessing1.Visible = false;
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 132);
            this.Controls.Add(this.lblProcessing1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSelFolder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainInterface";
            this.Text = "Sheet Index Wizard";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProcessing1;
    }
}