namespace SheetIndex
{
    partial class PDFResults
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFResults));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sheetDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAccept = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.revisionDescriptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.excludeArch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.myFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TempDocument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originalNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extractedNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oSheetNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oSheetTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eSheetNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eSheetTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sheetNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sheetTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentFolderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disciplineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disciplineCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disciplineSubCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSelectedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSelected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.revisionDescriptionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.excludeArch,
            this.myFile,
            this.Pages,
            this.FilePath,
            this.FileName,
            this.FileExtension,
            this.FileDirectory,
            this.TempDocument,
            this.originalNameDataGridViewTextBoxColumn,
            this.extractedNameDataGridViewTextBoxColumn,
            this.customNameDataGridViewTextBoxColumn,
            this.oSheetNumberDataGridViewTextBoxColumn,
            this.oSheetTitleDataGridViewTextBoxColumn,
            this.eSheetNumberDataGridViewTextBoxColumn,
            this.eSheetTitleDataGridViewTextBoxColumn,
            this.sheetNumberDataGridViewTextBoxColumn,
            this.sheetTitleDataGridViewTextBoxColumn,
            this.parentFolderDataGridViewTextBoxColumn,
            this.disciplineDataGridViewTextBoxColumn,
            this.disciplineCodeDataGridViewTextBoxColumn,
            this.disciplineSubCodeDataGridViewTextBoxColumn,
            this.columnSelectedDataGridViewTextBoxColumn,
            this.ColumnSelected,
            this.ID});
            this.dataGridView1.DataSource = this.sheetDataBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(873, 468);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // sheetDataBindingSource
            // 
            this.sheetDataBindingSource.DataSource = typeof(SheetIndex.SheetData);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(798, 13);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(87, 48);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Add to Sheet Index";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.revisionDescriptionBindingSource;
            this.comboBox1.DisplayMember = "DateAndDescription";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(452, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(323, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // revisionDescriptionBindingSource
            // 
            this.revisionDescriptionBindingSource.DataSource = typeof(SheetIndex.RevisionDescription);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Revision to use in this Issue.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.MaximumSize = new System.Drawing.Size(400, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // excludeArch
            // 
            this.excludeArch.DataPropertyName = "excludeArch";
            this.excludeArch.HeaderText = "excludeArch";
            this.excludeArch.Name = "excludeArch";
            this.excludeArch.Visible = false;
            // 
            // myFile
            // 
            this.myFile.DataPropertyName = "myFile";
            this.myFile.HeaderText = "myFile";
            this.myFile.Name = "myFile";
            this.myFile.Visible = false;
            // 
            // Pages
            // 
            this.Pages.DataPropertyName = "Pages";
            this.Pages.HeaderText = "Pages";
            this.Pages.Name = "Pages";
            this.Pages.Visible = false;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.Visible = false;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.Visible = false;
            // 
            // FileExtension
            // 
            this.FileExtension.DataPropertyName = "FileExtension";
            this.FileExtension.HeaderText = "FileExtension";
            this.FileExtension.Name = "FileExtension";
            this.FileExtension.Visible = false;
            // 
            // FileDirectory
            // 
            this.FileDirectory.DataPropertyName = "FileDirectory";
            this.FileDirectory.HeaderText = "FileDirectory";
            this.FileDirectory.Name = "FileDirectory";
            this.FileDirectory.Visible = false;
            // 
            // TempDocument
            // 
            this.TempDocument.DataPropertyName = "TempDocument";
            this.TempDocument.HeaderText = "TempDocument";
            this.TempDocument.Name = "TempDocument";
            this.TempDocument.Visible = false;
            // 
            // originalNameDataGridViewTextBoxColumn
            // 
            this.originalNameDataGridViewTextBoxColumn.DataPropertyName = "OriginalName";
            this.originalNameDataGridViewTextBoxColumn.HeaderText = "PDF File Name";
            this.originalNameDataGridViewTextBoxColumn.Name = "originalNameDataGridViewTextBoxColumn";
            this.originalNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // extractedNameDataGridViewTextBoxColumn
            // 
            this.extractedNameDataGridViewTextBoxColumn.DataPropertyName = "ExtractedName";
            this.extractedNameDataGridViewTextBoxColumn.HeaderText = "Extracted Name";
            this.extractedNameDataGridViewTextBoxColumn.Name = "extractedNameDataGridViewTextBoxColumn";
            this.extractedNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customNameDataGridViewTextBoxColumn
            // 
            this.customNameDataGridViewTextBoxColumn.DataPropertyName = "CustomName";
            this.customNameDataGridViewTextBoxColumn.HeaderText = "Custom Name";
            this.customNameDataGridViewTextBoxColumn.Name = "customNameDataGridViewTextBoxColumn";
            // 
            // oSheetNumberDataGridViewTextBoxColumn
            // 
            this.oSheetNumberDataGridViewTextBoxColumn.DataPropertyName = "oSheetNumber";
            this.oSheetNumberDataGridViewTextBoxColumn.HeaderText = "oSheetNumber";
            this.oSheetNumberDataGridViewTextBoxColumn.Name = "oSheetNumberDataGridViewTextBoxColumn";
            this.oSheetNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // oSheetTitleDataGridViewTextBoxColumn
            // 
            this.oSheetTitleDataGridViewTextBoxColumn.DataPropertyName = "oSheetTitle";
            this.oSheetTitleDataGridViewTextBoxColumn.HeaderText = "oSheetTitle";
            this.oSheetTitleDataGridViewTextBoxColumn.Name = "oSheetTitleDataGridViewTextBoxColumn";
            this.oSheetTitleDataGridViewTextBoxColumn.Visible = false;
            // 
            // eSheetNumberDataGridViewTextBoxColumn
            // 
            this.eSheetNumberDataGridViewTextBoxColumn.DataPropertyName = "eSheetNumber";
            this.eSheetNumberDataGridViewTextBoxColumn.HeaderText = "eSheetNumber";
            this.eSheetNumberDataGridViewTextBoxColumn.Name = "eSheetNumberDataGridViewTextBoxColumn";
            this.eSheetNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // eSheetTitleDataGridViewTextBoxColumn
            // 
            this.eSheetTitleDataGridViewTextBoxColumn.DataPropertyName = "eSheetTitle";
            this.eSheetTitleDataGridViewTextBoxColumn.HeaderText = "eSheetTitle";
            this.eSheetTitleDataGridViewTextBoxColumn.Name = "eSheetTitleDataGridViewTextBoxColumn";
            this.eSheetTitleDataGridViewTextBoxColumn.Visible = false;
            // 
            // sheetNumberDataGridViewTextBoxColumn
            // 
            this.sheetNumberDataGridViewTextBoxColumn.DataPropertyName = "SheetNumber";
            this.sheetNumberDataGridViewTextBoxColumn.HeaderText = "SheetNumber";
            this.sheetNumberDataGridViewTextBoxColumn.Name = "sheetNumberDataGridViewTextBoxColumn";
            this.sheetNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // sheetTitleDataGridViewTextBoxColumn
            // 
            this.sheetTitleDataGridViewTextBoxColumn.DataPropertyName = "SheetTitle";
            this.sheetTitleDataGridViewTextBoxColumn.HeaderText = "SheetTitle";
            this.sheetTitleDataGridViewTextBoxColumn.Name = "sheetTitleDataGridViewTextBoxColumn";
            this.sheetTitleDataGridViewTextBoxColumn.Visible = false;
            // 
            // parentFolderDataGridViewTextBoxColumn
            // 
            this.parentFolderDataGridViewTextBoxColumn.DataPropertyName = "ParentFolder";
            this.parentFolderDataGridViewTextBoxColumn.HeaderText = "ParentFolder";
            this.parentFolderDataGridViewTextBoxColumn.Name = "parentFolderDataGridViewTextBoxColumn";
            this.parentFolderDataGridViewTextBoxColumn.Visible = false;
            // 
            // disciplineDataGridViewTextBoxColumn
            // 
            this.disciplineDataGridViewTextBoxColumn.DataPropertyName = "Discipline";
            this.disciplineDataGridViewTextBoxColumn.HeaderText = "Discipline";
            this.disciplineDataGridViewTextBoxColumn.Name = "disciplineDataGridViewTextBoxColumn";
            this.disciplineDataGridViewTextBoxColumn.Visible = false;
            // 
            // disciplineCodeDataGridViewTextBoxColumn
            // 
            this.disciplineCodeDataGridViewTextBoxColumn.DataPropertyName = "DisciplineCode";
            this.disciplineCodeDataGridViewTextBoxColumn.HeaderText = "DisciplineCode";
            this.disciplineCodeDataGridViewTextBoxColumn.Name = "disciplineCodeDataGridViewTextBoxColumn";
            this.disciplineCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // disciplineSubCodeDataGridViewTextBoxColumn
            // 
            this.disciplineSubCodeDataGridViewTextBoxColumn.DataPropertyName = "DisciplineSubCode";
            this.disciplineSubCodeDataGridViewTextBoxColumn.HeaderText = "DisciplineSubCode";
            this.disciplineSubCodeDataGridViewTextBoxColumn.Name = "disciplineSubCodeDataGridViewTextBoxColumn";
            this.disciplineSubCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // columnSelectedDataGridViewTextBoxColumn
            // 
            this.columnSelectedDataGridViewTextBoxColumn.DataPropertyName = "ColumnSelected";
            this.columnSelectedDataGridViewTextBoxColumn.HeaderText = "ColumnSelected";
            this.columnSelectedDataGridViewTextBoxColumn.Name = "columnSelectedDataGridViewTextBoxColumn";
            this.columnSelectedDataGridViewTextBoxColumn.Visible = false;
            // 
            // ColumnSelected
            // 
            this.ColumnSelected.DataPropertyName = "ColumnSelected";
            this.ColumnSelected.HeaderText = "ColumnSelected";
            this.ColumnSelected.Name = "ColumnSelected";
            this.ColumnSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSelected.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.Visible = false;
            // 
            // PDFResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 563);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PDFResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pdf -> Placeholder Sheets";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.revisionDescriptionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource sheetDataBindingSource;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource revisionDescriptionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn excludeArch;
        private System.Windows.Forms.DataGridViewTextBoxColumn myFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pages;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileDirectory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TempDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn originalNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extractedNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oSheetNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oSheetTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eSheetNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eSheetTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sheetNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sheetTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentFolderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disciplineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disciplineCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disciplineSubCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSelectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}