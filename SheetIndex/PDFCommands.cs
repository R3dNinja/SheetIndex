using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using iTextSharp.text;
using iTextSharp.text.exceptions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.xtra.iTextSharp.text.pdf.pdfcleanup;

using Syncfusion.OCRProcessor;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace SheetIndex
{
    class PDFCommands
    {
        iTextSharp.text.Rectangle ARCH_E1 = new iTextSharp.text.Rectangle(3024f, 2160f);

        private static System.util.RectangleJ title;
        private static System.util.RectangleJ number;
        private static System.util.RectangleJ ARCH_DRect_Title = new System.util.RectangleJ(2299f, 138f, 236f, 88f);
        private static System.util.RectangleJ ARCH_DRect_Number = new System.util.RectangleJ(2299f, 51f, 236f, 49f);
        private static System.util.RectangleJ ARCH_E1Rect_Title = new System.util.RectangleJ(2733f, 138f, 236f, 88f);
        private static System.util.RectangleJ ARCH_E1Rect_Number = new System.util.RectangleJ(2733f, 51f, 236f, 49f);
        private static System.util.RectangleJ ARCH_ERect_Title = new System.util.RectangleJ(3164f, 138f, 236f, 88f);
        private static System.util.RectangleJ ARCH_ERect_Number = new System.util.RectangleJ(3164f, 51f, 236f, 49f);

        private static RenderFilter[] filterT;
        private static RenderFilter[] filterN;
        private static RenderFilter[] filterDT = { new RegionTextRenderFilter(ARCH_DRect_Title) };
        private static RenderFilter[] filterDN = { new RegionTextRenderFilter(ARCH_DRect_Number) };
        private static RenderFilter[] filterE1T = { new RegionTextRenderFilter(ARCH_E1Rect_Title) };
        private static RenderFilter[] filterE1N = { new RegionTextRenderFilter(ARCH_E1Rect_Number) };
        private static RenderFilter[] filterET = { new RegionTextRenderFilter(ARCH_ERect_Title) };
        private static RenderFilter[] filterEN = { new RegionTextRenderFilter(ARCH_ERect_Number) };

        public int getPageQuantity(string pdfFile)
        {
            PdfReader reader = new PdfReader(pdfFile);
            int pageCount = reader.NumberOfPages;
            reader.Close();
            reader.Dispose();
            return pageCount;
        }

        public List<FileInfo> extractPages(FileInfo fileName)
        {
            List<FileInfo> PDFFiles = new List<FileInfo>();
            string filePath = getFilePath(fileName);
            int pageCount = getPageQuantity(filePath);

            var savePath = System.IO.Path.GetDirectoryName(fileName.FullName) + @"\";
            var saveName = System.IO.Path.GetFileNameWithoutExtension(fileName.ToString());
            var fullFilePath = savePath + saveName + ".pdf";

            for (int pageIndex = 1; pageIndex <= pageCount; pageIndex++)
            {
                PdfReader reader = new PdfReader(fullFilePath);
                string pdfName = string.Format(saveName + " - page{0}", pageIndex);
                string outputPDFPath = savePath + pdfName + ".pdf";
                Document document = new Document(reader.GetPageSizeWithRotation(pageIndex));
                PdfCopy pdfCopyProvider = new PdfCopy(document, new System.IO.FileStream(outputPDFPath, System.IO.FileMode.Create));
                document.Open();
                PdfImportedPage importedPage = pdfCopyProvider.GetImportedPage(reader, pageIndex);
                pdfCopyProvider.AddPage(importedPage);
                pdfCopyProvider.Close();
                pdfCopyProvider.Dispose();
                document.Close();
                document.Dispose();
                reader.Close();
                reader.Dispose();
                FileInfo newPDF = new FileInfo(outputPDFPath);
                PDFFiles.Add(newPDF);
            }
            return PDFFiles;
        }

        public string getEmbededFileName(FileInfo file, string tempFile)
        {
            string filePath = getFilePath(file);
            bool textBased = checkForText(filePath);
            if (textBased == true)
            {
                //extract sheet number and name from text based pdf
                //try first with 270
                string newFileName = textBasedExtraction(file, 270, tempFile);
                if (newFileName.Length > 1)
                {
                    return newFileName;
                }
                else
                {
                    newFileName = textBasedExtraction(file, 90, tempFile);
                    return newFileName;
                }
            }
            else
            {
                //extract sheet number and name from text based pdf
                //try first with 270
                string newFileName = imageBasedExtraction(file, 270, tempFile);
                if (newFileName.Length > 1)
                {
                    return newFileName;
                }
                else
                {
                    newFileName = imageBasedExtraction(file, 90, tempFile);
                    return newFileName;
                }
            }
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

        private string getTempFilePath(FileInfo file)
        {
            string filePath;
            var Path = System.IO.Path.GetDirectoryName(file.FullName) + @"\";
            var Name = System.IO.Path.GetFileNameWithoutExtension(file.ToString());
            var Extension = System.IO.Path.GetExtension(file.ToString());
            filePath = Path + Name + "temp" + Extension;
            return filePath;
        }

        private bool checkForText(string filePath)
        {
            PdfReader reader = new PdfReader(filePath);
            ITextExtractionStrategy simpleSearch = new SimpleTextExtractionStrategy();
            var currentText = PdfTextExtractor.GetTextFromPage(reader, 1, simpleSearch);
            reader.Close();
            reader.Dispose();
            currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
            if (currentText.Length < 1)
            {
                //text extraction via image and OCR
                return false;
            }
            else
            {
                //extract text via region and iTextSharp
                return true;
            }
        }

        private string textBasedExtraction(FileInfo file, int rotation, string tempFile)
        {
            string pdfToRead = saveTempFixedRotation(file, rotation, tempFile);
            string newFileName = extractText(pdfToRead);
            File.Delete(pdfToRead);
            return newFileName;
        }

        private string imageBasedExtraction(FileInfo file, int rotation, string tempFile)
        {
            string pdfToRead = saveTempFixedRotation(file, rotation, tempFile);
            //string newFileName = syncfusionOCR(pdfToRead);

            string newFileName = extractImage(pdfToRead);
            File.Delete(pdfToRead);
            return newFileName;
        }

        private string saveTempFixedRotation(FileInfo file, int PageRotation, string tempFile)
        {
            string fullFilePath = getFilePath(file);
            string tempSavePath = tempFile;//getTempFilePath(file);

            StringBuilder extractedName = new StringBuilder();

            using (FileStream fs = new FileStream(tempSavePath, FileMode.Create, FileAccess.ReadWrite))
            {
                PdfReader reader = new PdfReader(fullFilePath);
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                PdfContentByte contentByte = writer.DirectContent;
                var rotation = reader.GetPageRotation(1);
                var pageWidth = reader.GetPageSizeWithRotation(1).Width;
                var pageHeight = reader.GetPageSizeWithRotation(1).Height;
                var setPageSize = new iTextSharp.text.Rectangle(0f, 0f);

                if (pageHeight / pageWidth > 1)
                {
                    var temp = pageHeight;
                    pageHeight = pageWidth;
                    pageWidth = temp;
                    rotation = PageRotation;
                }

                //CONVERT PAGE hEIGHT AND WIDTH TO INCHES
                float pageHeightInchF = (pageHeight/72);
                float pageWidthInchF = (pageWidth / 72);

                var pageHeightInch = Math.Round((Decimal)pageHeightInchF, 0, MidpointRounding.AwayFromZero);
                var pageWidthInch = Math.Round((Decimal)pageWidthInchF, 0, MidpointRounding.AwayFromZero);

                switch (pageWidth.ToString())
                {
                    case "2592":
                        setPageSize = new iTextSharp.text.Rectangle(2592f, 1728f);
                        filterT = filterDT;
                        filterN = filterDN;
                        title = ARCH_DRect_Title;
                        number = ARCH_DRect_Number;
                        break;

                    case "3024":
                        setPageSize = new iTextSharp.text.Rectangle(3024f, 2160f);
                        filterT = filterE1T;
                        filterN = filterE1N;
                        title = ARCH_E1Rect_Title;
                        number = ARCH_E1Rect_Number;
                        break;

                    case "3456":
                        setPageSize = new iTextSharp.text.Rectangle(3456f, 2592f);
                        filterT = filterET;
                        filterN = filterEN;
                        title = ARCH_ERect_Title;
                        number = ARCH_ERect_Number;
                        break;

                    default:
                        switch (pageWidthInch.ToString())
                        {
                            case "36":
                                setPageSize = new iTextSharp.text.Rectangle(2592f, 1728f);
                                filterT = filterDT;
                                filterN = filterDN;
                                title = ARCH_DRect_Title;
                                number = ARCH_DRect_Number;
                                break;
                            case "42":
                                setPageSize = new iTextSharp.text.Rectangle(3024f, 2160f);
                                filterT = filterE1T;
                                filterN = filterE1N;
                                title = ARCH_E1Rect_Title;
                                number = ARCH_E1Rect_Number;
                                break;
                            case "48":
                                setPageSize = new iTextSharp.text.Rectangle(3456f, 2592f);
                                filterT = filterET;
                                filterN = filterEN;
                                title = ARCH_ERect_Title;
                                number = ARCH_ERect_Number;
                                break;
                            default:
                                setPageSize = new iTextSharp.text.Rectangle(3456f, 2592f);
                                filterT = filterET;
                                filterN = filterEN;
                                title = ARCH_ERect_Title;
                                number = ARCH_ERect_Number;
                                break;
                        }
                        break;
                }

                document.SetPageSize(setPageSize);
                document.NewPage();
                PdfImportedPage page = writer.GetImportedPage(reader, 1);

                switch (rotation)
                {
                    case 0:
                        contentByte.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        break;

                    case 90:
                        contentByte.AddTemplate(page, 0, -1f, 1f, 0, 0, pageHeight);
                        break;

                    case 180:
                        contentByte.AddTemplate(page, -1f, 0, 0, -1f, pageWidth, pageHeight);
                        break;

                    case 270:
                        contentByte.AddTemplate(page, 0, 1f, -1f, 0, pageWidth, 0);
                        break;

                    default:
                        throw new InvalidOperationException(string.Format("Unexpected page rotation: [{0}].", rotation));
                }

                try
                {
                    document.Close();
                    document.Dispose();
                }
                catch { }
                reader.Close();
                reader.Dispose();
            }
            return tempSavePath;
        }

        private string extractText(string pdfToRead)
        {
            PdfReader reader = new PdfReader(pdfToRead);

            //extract sheet number
            ITextExtractionStrategy strategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), filterN);
            var sheetNumber = PdfTextExtractor.GetTextFromPage(reader, 1, strategy);
            string replacement = Regex.Replace(sheetNumber, @"\t|\n|\r", "");
            sheetNumber = replacement;

            //extract sheet title
            strategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), filterT);
            var sheetTitle = PdfTextExtractor.GetTextFromPage(reader, 1, strategy);

            reader.Close();
            reader.Dispose();

            replacement = Regex.Replace(sheetTitle, @"\t|\n|\r", " ");
            sheetTitle = replacement;
            replacement = Regex.Replace(sheetTitle, "  ", " ");
            sheetTitle = replacement;
            StringBuilder newName = new StringBuilder();
            newName.Append(sheetNumber.ToUpper());
            newName.Append(" ");
            newName.Append(sheetTitle.ToUpper());
            //newName.Append(".pdf");
            replacement = Regex.Replace(newName.ToString(), @" .pdf|  .pdf", ".pdf");
            string NewFileName = CleanFileName(replacement);
            return NewFileName;
        }

        private string extractImage(string pdfToRead)
        {
            FileInfo fileName = new FileInfo(pdfToRead);
            var savePath = System.IO.Path.GetDirectoryName(fileName.FullName) + @"\";
            var saveName = System.IO.Path.GetFileNameWithoutExtension(fileName.ToString());
            var saveExtension = System.IO.Path.GetExtension(fileName.ToString());
            var fullFilePath = savePath + saveName + saveExtension;
            var tempSavePath = savePath + saveName + "temp" + saveExtension;

            //var sheetTitle = cropPDF(tempSavePath, savePath, title, "sheetTitle");
            //var sheetNumber = cropPDF(tempSavePath, savePath, number, "sheetNumber");
            var sheetTitle = cropPDF(fullFilePath, savePath, title, "sheetTitle");
            var sheetNumber = cropPDF(fullFilePath, savePath, number, "sheetNumber");
            StringBuilder newName = new StringBuilder();
            newName.Append(sheetNumber.ToUpper());
            newName.Append(" ");
            newName.Append(sheetTitle.ToUpper());
            //newName.Append(".pdf");
            string replacement = Regex.Replace(newName.ToString(), @" .pdf|  .pdf", ".pdf");
            string NewFileName = CleanFileName(replacement);
            return NewFileName;

        }

        public bool getPaperSize(FileInfo file)
        {
            bool skip = false;
            string filePath = getFilePath(file);
            PdfReader reader = new PdfReader(filePath);
            iTextSharp.text.Rectangle mediabox = reader.GetPageSize(1);
            float pagewidth = mediabox.Width;
            float pageheight = mediabox.Height;

            string pagewidthS = pagewidth.ToString();

            switch (pagewidthS)
            {
                case "612":
                    skip = true;
                    break;
                case "792":
                    skip = true;
                    break;
                case "1008":
                    skip = true;
                    break;
                case "1224":
                    skip = true;
                    break;

                default:
                    skip = false;
                    break;
            }
            return skip;
        }

        public string cropPDF(string fileName, string savePath, System.util.RectangleJ box, string sheetType)
        {
            var left = box.X;
            var right = box.X + box.Width;
            var bottom = box.Y;
            var top = box.Y + box.Height;
            PdfReader reader = new PdfReader(fileName);
            string tempFile;
            string sheetTitle = "";
            using (FileStream output = new FileStream(savePath + sheetType + ".pdf", FileMode.Create, FileAccess.Write))
            {
                using (PdfStamper pdfStamper = new PdfStamper(reader, output))
                {
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        iTextSharp.text.Rectangle cropBox = reader.GetCropBox(page);
                        cropBox.Left = left; //3164f;
                        cropBox.Right = right; //3400;
                        cropBox.Bottom = bottom; //138f;
                        cropBox.Top = top; //226f;
                        reader.GetPageN(page).Put(PdfName.CROPBOX, new iTextSharp.text.pdf.PdfRectangle(cropBox));
                    }
                }
                tempFile = output.Name;
            }
            sheetTitle = syncfusionOCR(tempFile);

            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
            reader.Close();
            reader.Dispose();
            return sheetTitle;
        }

        private string syncfusionOCR(string pdfFile)
        {
            string text;
            using (OCRProcessor processor = new OCRProcessor(@"C:\ProgramData\Autodesk\REVIT\Addins\2015\kirksey\OCRProcessor\"))
            {
                PdfLoadedDocument lDoc = new PdfLoadedDocument(pdfFile);

                Bitmap img = lDoc.ExportAsImage(0);
                text = processor.PerformOCR(img, @"C:\ProgramData\Autodesk\REVIT\Addins\2015\Kirksey\OCRProcessor\Tessdata\");
                lDoc.Close(true);
            }
            return text;
        }

        private static string CleanFileName(string fileName)
        {
            return System.IO.Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        public iTextSharp.text.Rectangle getPageSize(FileInfo drawing)
        {
            string filePath = getFilePath(drawing);
            PdfReader reader = new PdfReader(filePath);
            iTextSharp.text.Rectangle mediabox = reader.GetPageSize(1);
            reader.Close();
            reader.Dispose();
            return mediabox;
        }

        public void uprightPDF(string pdfFile)
        {
            //string fullFilePath = getFilePath(file);
            //string tempSavePath = getTempFilePath(file);

            var tempSavePath = System.IO.Path.GetTempFileName();
            FileInfo file = new FileInfo(tempSavePath);

            using (FileStream fs = new FileStream(tempSavePath, FileMode.Create, FileAccess.ReadWrite))
            {
                PdfReader reader = new PdfReader(pdfFile);
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                PdfContentByte contentByte = writer.DirectContent;
                var rotation = reader.GetPageRotation(1);
                var pageWidth = reader.GetPageSizeWithRotation(1).Width;
                var pageHeight = reader.GetPageSizeWithRotation(1).Height;
                var setPageSize = new iTextSharp.text.Rectangle(0f, 0f);

                if (pageHeight / pageWidth > 1)
                {
                    var temp = pageHeight;
                    pageHeight = pageWidth;
                    pageWidth = temp;
                    //rotation = PageRotation;
                }

                switch (pageWidth.ToString())
                {
                    case "2592":
                        setPageSize = new iTextSharp.text.Rectangle(2592f, 1728f);
                        break;

                    case "3024":
                        setPageSize = new iTextSharp.text.Rectangle(3024f, 2160f);
                        break;

                    case "3456":
                        setPageSize = new iTextSharp.text.Rectangle(3456f, 2592f);
                        break;

                    default:
                        //need to look into different default behavior
                        setPageSize = new iTextSharp.text.Rectangle(3456f, 2592f);
                        break;
                }
                document.SetPageSize(setPageSize);
                document.NewPage();
                PdfImportedPage page = writer.GetImportedPage(reader, 1);

                switch (rotation)
                {
                    case 0:
                        contentByte.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        break;

                    case 90:
                        contentByte.AddTemplate(page, 0, -1f, 1f, 0, 0, pageHeight);
                        break;

                    case 180:
                        contentByte.AddTemplate(page, -1f, 0, 0, -1f, pageWidth, pageHeight);
                        break;

                    case 270:
                        contentByte.AddTemplate(page, 0, 1f, -1f, 0, pageWidth, 0);
                        break;

                    default:
                        throw new InvalidOperationException(string.Format("Unexpected page rotation: [{0}].", rotation));
                }

                try
                {
                    document.Close();
                    document.Dispose();
                }
                catch { }
                reader.Close();
                reader.Dispose();
            }
            if (File.Exists(pdfFile))
            {
                File.Delete(pdfFile);
            }
            File.Move(tempSavePath, pdfFile);
        }
    }
}
