using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointD = System.Windows.Point;

using iTextSharp.text;

namespace SheetIndex
{
    class ArchitecturalDrawing
    {
        public FileInfo DrawingFile { get; set; }
        public int Pages { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string ExtractedFileName { get; set; }
        public string UserFileName { get; set; }
        public string FileDirectory { get; set; }
        public string FileExtension { get; set; }
        public string TempDocument { get; set; }
        public float pageWidth { get; set; }
        public float pageHeight { get; set; }
        public string pageSize { get; set; }
        public string pageOrientation { get; set; }
        public string SheetType { get; set; }
        public string SheetNumber { get; set; }
        public string SheetTitle { get; set; }
        public string Discipline { get; set; }
        public string DisciplineCode { get; set; }

        public ArchitecturalDrawing(FileInfo file)
        {
            this.DrawingFile = file;
            this.FilePath = getFilePath(file);
            this.FileName = getFileName(file);
            this.Pages = getPages();
            this.FileExtension = getFileExtension(file);
            this.TempDocument = Path.GetTempFileName();
            //this.BackupLocation = setBackupLocation(file);
            //bool backupExist = false;
        }

        public void deleteTempFile()
        {
            var tempFile = this.TempDocument;
            if (File.Exists(tempFile))
            {
                //Delete File
                File.Delete(tempFile);
            }
            this.TempDocument = null;
        }


        private string getFileName(FileInfo file)
        {
            var Name = System.IO.Path.GetFileNameWithoutExtension(file.ToString());
            return Name;
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

        private int getPages()
        {
            PDFCommands pCommand = new PDFCommands();
            int pages = pCommand.getPageQuantity(this.FilePath);
            return pages;
        }

        private string getFileExtension(FileInfo file)
        {
            var Extension = System.IO.Path.GetExtension(file.ToString());
            return Extension;
        }

        private void getPageSize()
        {
            PDFCommands pCommand = new PDFCommands();
            iTextSharp.text.Rectangle mediaBox = pCommand.getPageSize(DrawingFile);
            this.pageWidth = mediaBox.Width;
            this.pageHeight = mediaBox.Height;

            if ((int)pageWidth == 612)
            {
                //Letter Page
                this.pageSize = "Letter";
                this.pageOrientation = "Portrait";
            }
            else
            {
                //Not Letter
                if (pageWidth / pageHeight > 1)
                {
                    //landscape page
                    switch ((int)pageWidth)
                    {
                        case 792:
                            this.pageSize = "Letter";
                            this.pageOrientation = "Landscape";
                            break;
                        case 1224:
                            this.pageSize = "Tabloid";
                            this.pageOrientation = "Landscape";
                            break;
                        case 2592:
                            this.pageSize = "D";
                            this.pageOrientation = "Landscape";
                            break;
                        case 3024:
                            this.pageSize = "E1";
                            this.pageOrientation = "Landscape";
                            break;
                        case 3456:
                            this.pageSize = "E";
                            this.pageOrientation = "Landscape";
                            break;
                        default:
                            this.pageSize = "UNKNOWN";
                            break;
                    }
                }
                else
                {
                    //rotate page
                    pCommand.uprightPDF(FilePath);
                    mediaBox = pCommand.getPageSize(DrawingFile);
                    this.pageWidth = mediaBox.Width;
                    this.pageHeight = mediaBox.Height;

                    switch ((int)pageWidth)
                    {
                        case 2592:
                            this.pageSize = "D";
                            this.pageOrientation = "Landscape";
                            break;
                        case 3024:
                            this.pageSize = "E1";
                            this.pageOrientation = "Landscape";
                            break;
                        case 3456:
                            this.pageSize = "E";
                            this.pageOrientation = "Landscape";
                            break;
                        default:
                            this.pageSize = "UNKNOWN";
                            break;
                    }
                }
            }


        }

        private void getPageOrinetation()
        {
            //deterimine orientation
            if (pageWidth / pageHeight > 1)
            {
                //Landscape page
            }
            else
            {
                //Potrait page
            }
        }
    }
}
