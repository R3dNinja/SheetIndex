using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SheetIndex
{
    public partial class ImprovedInterface : Form
    {
        private List<SheetData> drawings = new List<SheetData>();
        public static List<FileInfo> skippedFiles = new List<FileInfo>();
        public static List<FileInfo> processedFiles = new List<FileInfo>();
        private static bool excludeArch = false;

        public ImprovedInterface()
        {
            InitializeComponent();
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox1.Visible = false;
            foreach (var path in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (Directory.Exists(path))
                {
                    DirectoryInfo rootDir = new DirectoryInfo(path);

                    List<DirectoryInfo> dirList = new List<DirectoryInfo>(rootDir.GetDirectories("*", SearchOption.AllDirectories));
                    dirList.Add(rootDir);

                    List<FileInfo> fileList = new List<FileInfo>();

                    foreach (DirectoryInfo dir in dirList)
                    {
                        fileList.AddRange(dir.GetFiles("*.pdf", SearchOption.TopDirectoryOnly));
                    }
                    foreach (FileInfo file in fileList)
                    {
                        var check = IsFileInUse(file);
                        if (check == false)
                        {
                            listBox1.Items.Add(file.FullName);
                            processedFiles.Add(file);
                        }
                        else
                        {
                            skippedFiles.Add(file);
                        }
                    }
                }
                else
                {
                    if (Path.GetExtension(path).Equals(".pdf", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var check = IsFileInUsePath(path);
                        if (check == false)
                        {
                            listBox1.Items.Add(path);
                            processedFiles.Add(new FileInfo(path.ToString()));
                        }
                        else
                        {
                            skippedFiles.Add(new FileInfo(path.ToString()));
                        }
                    }


                }
            }
        }

        private bool IsFileInUse(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        private bool IsFileInUsePath(string path)
        {
            //string filePath = path.ToString();
            FileStream stream = null;

            try
            {
                stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                //stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        private void GetFileList()
        {
            if (rdoExcludeArch.Checked)
            {
                excludeArch = true;
            }
            setupProgressBar(listBox1.Items.Count, "Analyzing Drawings (Phase 1 of 2)");
            int id = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                FileInfo file = new FileInfo(listBox1.Items[i].ToString());
                int pageQuantity = getPageQuantity(file);
                if (pageQuantity == 1)
                {
                    Command.listSheet.Add(new SheetData(file, id, excludeArch));
                    id++;
                    IncrementProgress();
                }
                else
                {
                    //Extract pages to OrginialName - Page#.pdf
                    List<FileInfo> extractedFiles = extractMultiPageFiles(file);
                    foreach (FileInfo extracedFile in extractedFiles)
                    {
                        Command.listSheet.Add(new SheetData(extracedFile, id, excludeArch));
                        id++;
                    }
                    IncrementProgress();

                }
            }
        }

        private int getPageQuantity(FileInfo file)
        {
            PDFCommands pdfCommand = new PDFCommands();
            var pdfFile = getFilePath(file);
            int pageCount = pdfCommand.getPageQuantity(pdfFile);
            return pageCount;
        }

        private string getFilePath(FileInfo file)
        {
            string filePath;
            var Path = System.IO.Path.GetDirectoryName(file.FullName) + @"\";
            var Name = System.IO.Path.GetFileNameWithoutExtension(file.ToString());
            var Extension = System.IO.Path.GetExtension(file.ToString());
            filePath = Path + Name + Extension;
            return filePath;
        }

        private List<FileInfo> extractMultiPageFiles(FileInfo file)
        {

            PDFCommands pdfCommand = new PDFCommands();
            List<FileInfo> pdfFiles = pdfCommand.extractPages(file);
            return pdfFiles;
        }



        private void setupProgressBar(int max, string info)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = max;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            progressLabel.Text = info;
            progressLabel.Visible = true;
            this.Refresh();
        }

        /*public void SetupProgress(int max, string info)
        {
            MethodInvoker mi = delegate
            {
                progressLabel.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = max;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                progressLabel.Text = info;
                this.Refresh();
            };
            if (InvokeRequired)
            {
                this.Invoke(mi);
            }
            else
            {
                progressLabel.Visible = true;

                progressBar1.Minimum = 0;
                progressBar1.Maximum = max;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                progressLabel.Text = info;
                this.Refresh();
            }
        }*/

        public void IncrementProgress()
        {
            MethodInvoker mi = delegate
            {
                ++progressBar1.Value;
                this.Refresh();
            };
            if (InvokeRequired)
            {
                this.Invoke(mi);
            }
            else
            {
                ++progressBar1.Value;
                this.Refresh();
            }
            System.Windows.Forms.Application.DoEvents();
        }


        private void lblProcessing1_Click(object sender, EventArgs e)
        {

        }

        private void ImprovedInterface_Load(object sender, EventArgs e)
        {

        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*>*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo[] files = ofd.FileNames.Select(f => new FileInfo(f)).ToArray();
                foreach (FileInfo file in files)
                {
                    var check = IsFileInUse(file);
                    if (check == false)
                    {
                        listBox1.Items.Add(file.FullName);
                        processedFiles.Add(file);
                    }
                    else
                    {
                        string fileString = file.ToString();
                        MessageBox.Show(string.Format("File not added!\n {0}\n It is in use by someone else.", fileString), "Results", MessageBoxButtons.OK);
                        skippedFiles.Add(file);
                    }
                }
                pictureBox1.Visible = false;
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);

                DirectoryInfo rootDir = new DirectoryInfo(fbd.SelectedPath);

                List<DirectoryInfo> dirList = new List<DirectoryInfo>(rootDir.GetDirectories("*", SearchOption.AllDirectories));
                dirList.Add(rootDir);

                List<FileInfo> fileList = new List<FileInfo>();

                foreach (DirectoryInfo dir in dirList)
                {
                    fileList.AddRange(dir.GetFiles("*.pdf", SearchOption.TopDirectoryOnly));
                }
                foreach (FileInfo file in fileList)
                {
                    var check = IsFileInUse(file);
                    if (check == false)
                    {
                        listBox1.Items.Add(file.FullName);
                        processedFiles.Add(file);
                    }
                    else
                    {
                        skippedFiles.Add(file);
                    }
                }
                pictureBox1.Visible = false;
            }
        }

        private void btnRemoveFiles_Click(object sender, EventArgs e)
        {
            for (int x = listBox1.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = listBox1.SelectedIndices[x];
                listBox1.Items.RemoveAt(idx);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ProcessPDF_Click(object sender, EventArgs e)
        {
            btnAddFiles.Enabled = false;
            btnAddFolder.Enabled = false;
            btnRemoveFiles.Enabled = false;
            GetFileList();
            this.DialogResult = DialogResult.OK;
            //return DialogResult.OK;
            this.Close();
        }
    }
}
