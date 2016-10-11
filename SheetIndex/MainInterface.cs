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
    public partial class MainInterface : Form
    {
        private List<FileInfo> PDFFiles { get; set; }
        private List<FileInfo[]> scannedFiles { get; set; }
        //public static SortableBindingList<SheetData> listSheet = new SortableBindingList<SheetData>();
        public DialogResult DialogResult { get; set; }

        public MainInterface()
        {
            InitializeComponent();
            PDFFiles = new List<FileInfo>();
            //listSheet = new SortableBindingList<SheetData>();
        }

        private void btnSelFolder_Click(object sender, EventArgs e)
        {
            List<FileInfo[]> listOfFiles = new List<FileInfo[]>();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo rootDir = new DirectoryInfo(fbd.SelectedPath);
                textBox1.Text = rootDir.ToString();
                //listOfFiles.Add(rootDir.GetFiles("*.pdf"));

                List<DirectoryInfo> dirList = new List<DirectoryInfo>(rootDir.GetDirectories("*", SearchOption.AllDirectories));
                dirList.Add(rootDir);
                foreach (DirectoryInfo dir in dirList)
                {
                    listOfFiles.Add(dir.GetFiles("*.pdf"));
                }
            }
            scannedFiles = listOfFiles;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            btnSelFolder.Enabled = false;
            btnProcess.Enabled = false;
            //Create list of actual PDF Files

            //Leave out Specs

            //Leave out Arch
            List<FileInfo[]> listOfFiles = scannedFiles;
            foreach (FileInfo[] files in listOfFiles)
            {
                foreach (FileInfo file in files)
                {
                    //get page quantity from file
                    int pageQuantity = getPageQuantity(file);
                    if (pageQuantity == 1)
                    {
                        //check folder file is in
                        string parentFolder = getParentFolder(file);
                        bool ignore = checkAgainstFolder(parentFolder);
                        if (ignore == false)
                        {
                            //check file dimensions
                            PDFCommands pdfCheckSize = new PDFCommands();
                            bool skip = pdfCheckSize.getPaperSize(file);
                            if (skip == false)
                            {
                                PDFFiles.Add(file);
                            }
                        }
                    }
                    else
                    {
                        //Extract pages to OrginialName - Page#.pdf
                        List<FileInfo> extractedFiles = extractMultiPageFiles(file);
                        foreach (FileInfo extracedFile in extractedFiles)
                        {
                            PDFFiles.Add(extracedFile);
                        }
                    }
                }
            }
            int totalFiles = PDFFiles.Count;
            SetupProgress(totalFiles, "Examining PDF Files");
            int id = 0;
            foreach (FileInfo file in PDFFiles)
            {
                Command.listSheet.Add(new SheetData(file, id, false));
                IncrementProgress();
                id++;
                //update progress bar on collecting informaton
            }
            this.DialogResult = DialogResult.OK;
            //return DialogResult.OK;
            this.Close();
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

        public void SetupProgress(int max, string info)
        {
            MethodInvoker mi = delegate
            {
                lblProcessing1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = max;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                lblProcessing1.Text = info;
                this.Refresh();
            };
            if (InvokeRequired)
            {
                this.Invoke(mi);
            }
            else
            {
                lblProcessing1.Visible = true;

                progressBar1.Minimum = 0;
                progressBar1.Maximum = max;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                lblProcessing1.Text = info;
                this.Refresh();
            }
        }

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

        private string getParentFolder(FileInfo file)
        {
            return file.Directory.Name;
        }

        private bool checkAgainstFolder(string parentFolder)
        {
            bool ignoreFolder = false;
            var searchString = parentFolder.ToUpper();
            switch (searchString)
            {
                case "ARCH":
                    ignoreFolder = true;
                    break;
                case "ARCHITECTURE":
                    ignoreFolder = true;
                    break;
                case "A":
                    ignoreFolder = true;
                    break;

                case "IA":
                    ignoreFolder = true;
                    break;
                case "INTERIORS":
                    ignoreFolder = true;
                    break;
                case "INTERIOR":
                    ignoreFolder = true;
                    break;

                case "SPEC":
                    ignoreFolder = true;
                    break;
                case "SPECS":
                    ignoreFolder = true;
                    break;
                case "SPECIFICATION":
                    ignoreFolder = true;
                    break;
                case "SPECIFICATIONS":
                    ignoreFolder = true;
                    break;

                default:
                    ignoreFolder = false;
                    break;
            }
            return ignoreFolder;
        }
    }
}
