namespace SheetIndex
{
    partial class ImprovedInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImprovedInterface));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_ProcessPDF = new System.Windows.Forms.Button();
            this.rdoExcludeArch = new System.Windows.Forms.RadioButton();
            this.rdoIncludeArch = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnRemoveFiles = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 448);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(141, 52);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 110);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(590, 329);
            this.listBox1.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::SheetIndex.Properties.Resources.Drag_and_Drop;
            this.pictureBox1.Location = new System.Drawing.Point(85, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(446, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(156, 453);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(35, 13);
            this.progressLabel.TabIndex = 22;
            this.progressLabel.Text = "label2";
            this.progressLabel.Visible = false;
            this.progressLabel.Click += new System.EventHandler(this.lblProcessing1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(159, 477);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(443, 23);
            this.progressBar1.TabIndex = 21;
            this.progressBar1.Visible = false;
            // 
            // btn_ProcessPDF
            // 
            this.btn_ProcessPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProcessPDF.Location = new System.Drawing.Point(405, 448);
            this.btn_ProcessPDF.Name = "btn_ProcessPDF";
            this.btn_ProcessPDF.Size = new System.Drawing.Size(116, 23);
            this.btn_ProcessPDF.TabIndex = 23;
            this.btn_ProcessPDF.Text = "Process PDFs";
            this.btn_ProcessPDF.UseVisualStyleBackColor = true;
            this.btn_ProcessPDF.Click += new System.EventHandler(this.btn_ProcessPDF_Click);
            // 
            // rdoExcludeArch
            // 
            this.rdoExcludeArch.AutoSize = true;
            this.rdoExcludeArch.Checked = true;
            this.rdoExcludeArch.Location = new System.Drawing.Point(6, 23);
            this.rdoExcludeArch.Name = "rdoExcludeArch";
            this.rdoExcludeArch.Size = new System.Drawing.Size(161, 17);
            this.rdoExcludeArch.TabIndex = 24;
            this.rdoExcludeArch.TabStop = true;
            this.rdoExcludeArch.Text = "Exclude Architectural Sheets";
            this.rdoExcludeArch.UseVisualStyleBackColor = true;
            // 
            // rdoIncludeArch
            // 
            this.rdoIncludeArch.AutoSize = true;
            this.rdoIncludeArch.Location = new System.Drawing.Point(6, 50);
            this.rdoIncludeArch.Name = "rdoIncludeArch";
            this.rdoIncludeArch.Size = new System.Drawing.Size(158, 17);
            this.rdoIncludeArch.TabIndex = 25;
            this.rdoIncludeArch.Text = "Include Architectural Sheets";
            this.rdoIncludeArch.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoExcludeArch);
            this.groupBox1.Controls.Add(this.rdoIncludeArch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 82);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "External Architectural Sheets";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFolder.Location = new System.Drawing.Point(482, 42);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(120, 23);
            this.btnAddFolder.TabIndex = 28;
            this.btnAddFolder.Text = "Add Folder";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnRemoveFiles
            // 
            this.btnRemoveFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFiles.Location = new System.Drawing.Point(482, 71);
            this.btnRemoveFiles.Name = "btnRemoveFiles";
            this.btnRemoveFiles.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveFiles.TabIndex = 27;
            this.btnRemoveFiles.Text = "Remove Files";
            this.btnRemoveFiles.UseVisualStyleBackColor = true;
            this.btnRemoveFiles.Click += new System.EventHandler(this.btnRemoveFiles_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFiles.Location = new System.Drawing.Point(482, 12);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(120, 23);
            this.btnAddFiles.TabIndex = 26;
            this.btnAddFiles.Text = "Add Files";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(527, 448);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ImprovedInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 512);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemoveFiles);
            this.Controls.Add(this.btn_ProcessPDF);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(630, 550);
            this.Name = "ImprovedInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select External Drawings";
            this.Load += new System.EventHandler(this.ImprovedInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_ProcessPDF;
        private System.Windows.Forms.RadioButton rdoExcludeArch;
        private System.Windows.Forms.RadioButton rdoIncludeArch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnRemoveFiles;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnCancel;
    }
}