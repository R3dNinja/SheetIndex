using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using PointD = System.Windows.Point;

using iTextSharp.text;

namespace SheetIndex
{
    public class SheetData
    {
        public FileInfo myFile { get; set; }
        public int ID { get; set; }
        public string OriginalName { get; set; }
        public string ExtractedName { get; set; }
        public string CustomName { get; set; }
        public string oSheetNumber { get; set; }
        public string oSheetTitle { get; set; }
        public string eSheetNumber { get; set; }
        public string eSheetTitle { get; set; }
        public string SheetNumber { get; set; }
        public string SheetTitle { get; set; }
        public string ParentFolder { get; set; }
        public string Discipline { get; set; }
        public string DisciplineCode { get; set; }
        public string DisciplineSubCode { get; set; }
        public int ColumnSelected { get; set; }
        public int Pages { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FileDirectory { get; set; }
        public string TempDocument { get; set; }
        public bool excludeArch { get; set; }

        public SheetData(FileInfo file, int id, bool exclude)
        {
            this.excludeArch = exclude;
            this.myFile = file;
            this.ID = id;
            this.FilePath = getFilePath(file);
            this.FileName = getFileName(file);
            this.FileExtension = getFileExtension(file);
            this.FileDirectory = getFileDirectory(file);
            this.ParentFolder = file.Directory.Name;
            this.Pages = getPages();
            this.TempDocument = Path.GetTempFileName();
            this.OriginalName = extractOriginalName(file);
            splitFileNameOriginal(OriginalName);
            this.ExtractedName = extractConvertedName(file);
            splitFileNameExtracted(ExtractedName);
            this.CustomName = "";
            this.ColumnSelected = 3;
            extractDisciplineByFolderFirst(this.ParentFolder);


        }

        public void deleteTempFile()
        {
            string tempFile = this.TempDocument;
            if (File.Exists(tempFile))
            {
                //Delete File
                File.Delete(tempFile);
            }
            this.TempDocument = null;
        }

        private string extractConvertedName(FileInfo file)
        {
            PDFCommands pdfCommand = new PDFCommands();
            string convertedName = pdfCommand.getEmbededFileName(file, this.TempDocument);
            return convertedName;
        }

        private string extractOriginalName(FileInfo file)
        {
            string Name = System.IO.Path.GetFileNameWithoutExtension(file.ToString());
            return Name;
        }

        private void splitFileNameOriginal(string fileName)
        {
            string pattern = " ";
            Regex regx = new Regex(pattern);
            Match m = regx.Match(fileName);
            if (m.Success)
            {
                int startAt = m.Index;
                string[] result = regx.Split(fileName, 2, startAt);
                this.oSheetNumber = result[0];
                this.oSheetTitle = Regex.Replace(result[1], @"- | - ", "");
            }

        }

        private void splitFileNameExtracted(string fileName)
        {
            string pattern = " ";
            Regex regx = new Regex(pattern);
            Match m = regx.Match(fileName);
            if (m.Success)
            {
                int startAt = m.Index;
                string[] result = regx.Split(fileName, 2, startAt);
                this.eSheetNumber = result[0];
                //this.eSheetTitle = Regex.Replace(result[1], @"- | - ", "");
                this.eSheetTitle = result[1];
            }

        }

        private void splitFileNameCustom(string fileName)
        {
            string pattern = " ";
            Regex regx = new Regex(pattern);
            Match m = regx.Match(fileName);
            if (m.Success)
            {
                int startAt = m.Index;
                string[] result = regx.Split(fileName, 2, startAt);
                this.SheetNumber = result[0];
                this.SheetTitle = Regex.Replace(result[1], @"- | - ", "");
            }

        }

        private void extractDisciplineByFolderFirst(string parentFolder)
        {
            var searchString = parentFolder.ToUpper();
            switch (searchString)
            {
                case "CIVIL":
                    this.Discipline = "CIVIL";
                    this.excludeArch = false;
                    break;
                case "LANDSCAPE":
                    this.Discipline = "LANDSCAPE";
                    this.excludeArch = false;
                    break;
                case "LAND":
                    this.Discipline = "LANDSCAPE";
                    this.excludeArch = false;
                    break;
                case "L":
                    this.Discipline = "LANDSCAPE";
                    this.excludeArch = false;
                    break;
                case "ARCH":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "ARCHITECTURE":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "ARCHITECTURAL":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "INT":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "INTERIORS":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "INTERIOR":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "STRUCT":
                    this.Discipline = "STRUCTURAL";
                    this.excludeArch = false;
                    break;
                case "STRUCTURE":
                    this.Discipline = "STRUCTURAL";
                    this.excludeArch = false;
                    break;
                case "STRUCTURAL":
                    this.Discipline = "STRUCTURAL";
                    this.excludeArch = false;
                    break;
                case "MECH":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "M":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "MECHANICAL":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "ELEC":
                    this.Discipline = "ELECTRICAL";
                    this.excludeArch = false;
                    break;
                case "E":
                    this.Discipline = "ELECTRICAL";
                    this.excludeArch = false;
                    break;
                case "ELECTRICAL":
                    this.Discipline = "ELECTRICAL";
                    this.excludeArch = false;
                    break;
                case "PLUMB":
                    this.Discipline = "PLUMBING";
                    this.excludeArch = false;
                    break;
                case "P":
                    this.Discipline = "PLUMBING";
                    this.excludeArch = false;
                    break;
                case "PLUMBING":
                    this.Discipline = "PLUMBING";
                    this.excludeArch = false;
                    break;
                case "FIRE":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "FP":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "FIRE PROTECTION":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "FIREPROTECTION":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "PARK":
                    this.Discipline = "PARKING";
                    this.excludeArch = false;
                    break;
                case "PARKING":
                    this.Discipline = "PARKING";
                    this.excludeArch = false;
                    break;
                case "FS":
                    this.Discipline = "FOOD SERVICE";
                    this.excludeArch = false;
                    break;
                case "FOOD":
                    this.Discipline = "FOOD SERVICE";
                    this.excludeArch = false;
                    break;
                case "FOOD SERVICE":
                    this.Discipline = "FOOD SERVICE";
                    this.excludeArch = false;
                    break;
                case "AV":
                    this.Discipline = "AUDIO VISUAL";
                    this.excludeArch = false;
                    break;
                case "AUDIO VISUAL":
                    this.Discipline = "AUDIO VISUAL";
                    this.excludeArch = false;
                    break;
                case "AUDIO":
                    this.Discipline = "AUDIO VISUAL";
                    this.excludeArch = false;
                    break;
                case "DATA":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "DATA NETWORKS":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "TECH":
                    this.Discipline = "DATA NETWROKS";
                    this.excludeArch = false;
                    break;
                case "TECHNOLOGY":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "TELECOM":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "TELE":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "TEL":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "SECURITY":
                    this.Discipline = "SECURITY";
                    this.excludeArch = false;
                    break;
                case "SEC":
                    this.Discipline = "SECURITY";
                    this.excludeArch = false;
                    break;
                case "SECUR":
                    this.Discipline = "SECURTIY";
                    this.excludeArch = false;
                    break;
                case "FURN":
                    this.Discipline = "FURNITURE";
                    this.excludeArch = false;
                    break;
                case "FURNITURE":
                    this.Discipline = "FURNITURE";
                    this.excludeArch = false;
                    break;
                case "SIGN":
                    this.Discipline = "SIGNAGE";
                    this.excludeArch = false;
                    break;
                case "SIGNAGE":
                    this.Discipline = "SIGNAGE";
                    this.excludeArch = false;
                    break;
                case "G":
                    this.Discipline = "GARAGE";
                    this.excludeArch = false;
                    break;
                case "GAR":
                    this.Discipline = "GARAGE";
                    this.excludeArch = false;
                    break;
                case "GARAGE":
                    this.Discipline = "GARAGE";
                    this.excludeArch = false;
                    break;
                default:
                    extractDisciplineByNumberFirst();
                    break;
            }

        }

        private void extractDisciplineByNumberFirst()
        {
            string temp;
            if (this.oSheetNumber != null)
            {
                temp = Regex.Replace(this.oSheetNumber, @"[^\w\s]", "");
            }
            else
            {
                temp = Regex.Replace(this.eSheetNumber, @"[^\w\s]", "");
            }
            Match match = Regex.Match(temp, @"(?i)^[a-z]+");
            temp = match.ToString();
            switch (temp)
            {
                case "C":
                    this.Discipline = "CIVIL";
                    this.excludeArch = false;
                    break;
                case "TS":
                    this.Discipline = "CIVIL";
                    this.excludeArch = false;
                    break;
                case "L":
                    this.Discipline = "LANDSCAPE";
                    this.excludeArch = false;
                    break;
                case "A":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "IA":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "S":
                    this.Discipline = "STRUCTURAL";
                    this.excludeArch = false;
                    break;
                case "M":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "MEP":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "MP":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "E":
                    this.Discipline = "ELECTRICAL";
                    this.excludeArch = false;
                    break;
                case "P":
                    this.Discipline = "PLUMBING";
                    this.excludeArch = false;
                    break;
                case "FP":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "FA":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "PA":
                    this.Discipline = "PARKING";
                    this.excludeArch = false;
                    break;
                case "FS":
                    this.Discipline = "FOOD SERVICE";
                    this.excludeArch = false;
                    break;
                case "AV":
                    this.Discipline = "AUDIO VISUAL";
                    this.excludeArch = false;
                    break;
                case "TA":
                    this.Discipline = "AUDIO VISUAL";
                    this.excludeArch = false;
                    break;
                case "T":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "TY":
                    this.Discipline = "SECURITY";
                    this.excludeArch = false;
                    break;
                case "F":
                    this.Discipline = "FURNITURE";
                    this.excludeArch = false;
                    break;
                case "SG":
                    this.Discipline = "SIGNAGE";
                    this.excludeArch = false;
                    break;
                case "G":
                    this.Discipline = "GARAGE";
                    this.excludeArch = false;
                    break;
                default:
                    this.Discipline = "UNKNOWN";
                    this.excludeArch = false;
                    break;
            }
        }

        private void extractDisciplineByFolder(string parentFolder)
        {
            var searchString = parentFolder.ToUpper();
            switch (searchString)
            {
                case "CIVIL":
                    this.Discipline = "CIVIL";
                    this.excludeArch = false;
                    break;
                case "LANDSCAPE":
                    this.Discipline = "LANDSCAPE";
                    this.excludeArch = false;
                    break;
                case "LAND":
                    this.Discipline = "LANDSCAPE";
                    this.excludeArch = false;
                    break;
                case "L":
                    this.Discipline = "LANDSCAPE";
                    this.excludeArch = false;
                    break;
                case "ARCH":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "ARCHITECTURE":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "ARCHITECTURAL":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "INT":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "INTERIORS":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "INTERIOR":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "STRUCT":
                    this.Discipline = "STRUCTURAL";
                    this.excludeArch = false;
                    break;
                case "STRUCTURE":
                    this.Discipline = "STRUCTURAL";
                    this.excludeArch = false;
                    break;
                case "STRUCTURAL":
                    this.Discipline = "STRUCTURAL";
                    this.excludeArch = false;
                    break;
                case "MECH":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "M":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "MECHANICAL":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "ELEC":
                    this.Discipline = "ELECTRICAL";
                    this.excludeArch = false;
                    break;
                case "E":
                    this.Discipline = "ELECTRICAL";
                    this.excludeArch = false;
                    break;
                case "ELECTRICAL":
                    this.Discipline = "ELECTRICAL";
                    this.excludeArch = false;
                    break;
                case "PLUMB":
                    this.Discipline = "PLUMBING";
                    this.excludeArch = false;
                    break;
                case "P":
                    this.Discipline = "PLUMBING";
                    this.excludeArch = false;
                    break;
                case "PLUMBING":
                    this.Discipline = "PLUMBING";
                    this.excludeArch = false;
                    break;
                case "FIRE":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "FP":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "FIRE PROTECTION":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "FIREPROTECTION":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "PARK":
                    this.Discipline = "PARKING";
                    this.excludeArch = false;
                    break;
                case "PARKING":
                    this.Discipline = "PARKING";
                    this.excludeArch = false;
                    break;
                case "FS":
                    this.Discipline = "FOOD SERVICE";
                    this.excludeArch = false;
                    break;
                case "FOOD":
                    this.Discipline = "FOOD SERVICE";
                    this.excludeArch = false;
                    break;
                case "FOOD SERVICE":
                    this.Discipline = "FOOD SERVICE";
                    this.excludeArch = false;
                    break;
                case "AV":
                    this.Discipline = "AUDIO VISUAL";
                    this.excludeArch = false;
                    break;
                case "AUDIO VISUAL":
                    this.Discipline = "AUDIO VISUAL";
                    this.excludeArch = false;
                    break;
                case "AUDIO":
                    this.Discipline = "AUDIO VISUAL";
                    this.excludeArch = false;
                    break;
                case "DATA":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "DATA NETWORKS":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "TECH":
                    this.Discipline = "DATA NETWROKS";
                    this.excludeArch = false;
                    break;
                case "TECHNOLOGY":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "TELECOM":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "TELE":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "TEL":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "SECURITY":
                    this.Discipline = "SECURITY";
                    this.excludeArch = false;
                    break;
                case "SEC":
                    this.Discipline = "SECURITY";
                    this.excludeArch = false;
                    break;
                case "SECUR":
                    this.Discipline = "SECURTIY";
                    this.excludeArch = false;
                    break;
                case "FURN":
                    this.Discipline = "FURNITURE";
                    this.excludeArch = false;
                    break;
                case "FURNITURE":
                    this.Discipline = "FURNITURE";
                    this.excludeArch = false;
                    break;
                case "SIGN":
                    this.Discipline = "SIGNAGE";
                    this.excludeArch = false;
                    break;
                case "SIGNAGE":
                    this.Discipline = "SIGNAGE";
                    this.excludeArch = false;
                    break;
                case "G":
                    this.Discipline = "GARAGE";
                    this.excludeArch = false;
                    break;
                case "GAR":
                    this.Discipline = "GARAGE";
                    this.excludeArch = false;
                    break;
                case "GARAGE":
                    this.Discipline = "GARAGE";
                    this.excludeArch = false;
                    break;
                default:
                    //try another method
                    extractDisciplineByNumber();
                    break;
            }

        }

        private void extractDisciplineByNumber()
        {
            //string temp = Regex.Replace(SheetNumber, .+?(?=\d), "");
            string[] temp = Regex.Split(SheetNumber, @"\d");
            //string temp = new String(SheetNumber.Where(Char.IsLetter).ToArray());
            switch (temp[0])
            {
                case "C":
                    this.Discipline = "CIVIL";
                    this.excludeArch = false;
                    break;
                case "TS":
                    this.Discipline = "CIVIL";
                    this.excludeArch = false;
                    break;
                case "L":
                    this.Discipline = "LANDSCAPE";
                    this.excludeArch = false;
                    break;
                case "A":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "IA":
                    this.Discipline = "ARCHITECTURAL";
                    break;
                case "S":
                    this.Discipline = "STRUCTURAL";
                    this.excludeArch = false;
                    break;
                case "M":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "MEP":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "MP":
                    this.Discipline = "MECHANICAL";
                    this.excludeArch = false;
                    break;
                case "E":
                    this.Discipline = "ELECTRICAL";
                    this.excludeArch = false;
                    break;
                case "P":
                    this.Discipline = "PLUMBING";
                    this.excludeArch = false;
                    break;
                case "FP":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "FA":
                    this.Discipline = "FIRE PROTECTION";
                    this.excludeArch = false;
                    break;
                case "PA":
                    this.Discipline = "PARKING";
                    this.excludeArch = false;
                    break;
                case "FS":
                    this.Discipline = "FOOD SERVICE";
                    this.excludeArch = false;
                    break;
                case "AV":
                    this.Discipline = "AUDIO VISUAL";
                    this.excludeArch = false;
                    break;
                case "TA":
                    this.Discipline = "AUDIO VISUAL";
                    this.excludeArch = false;
                    break;
                case "T":
                    this.Discipline = "DATA NETWORKS";
                    this.excludeArch = false;
                    break;
                case "TY":
                    this.Discipline = "SECURITY";
                    this.excludeArch = false;
                    break;
                case "F":
                    this.Discipline = "FURNITURE";
                    this.excludeArch = false;
                    break;
                case "SG":
                    this.Discipline = "SIGNAGE";
                    this.excludeArch = false;
                    break;
                case "G":
                    this.Discipline = "GARAGE";
                    this.excludeArch = false;
                    break;
                default:
                    this.Discipline = "UNKNOWN";
                    this.excludeArch = false;
                    break;
            }
        }

        private void setDisciplineCode()
        {
            switch (Discipline)
            {
                case "CIVIL":
                    this.DisciplineCode = "10";
                    break;
                case "LANDSCAPE":
                    this.DisciplineCode = "20";
                    break;
                case "ARCHITECTURAL":
                    this.DisciplineCode = "30";
                    break;
                case "STRUCTURAL":
                    this.DisciplineCode = "40";
                    break;
                case "MECHANICAL":
                    this.DisciplineCode = "50";
                    break;
                case "ELECTRICAL":
                    this.DisciplineCode = "60";
                    break;
                case "PLUMBING":
                    this.DisciplineCode = "70";
                    break;
                case "FIRE PROTECTION":
                    this.DisciplineCode = "80";
                    break;
                case "PARKING":
                    this.DisciplineCode = "90";
                    break;
                case "FOOD SERVICE":
                    this.DisciplineCode = "100";
                    break;
                case "AUDIO VISUAL":
                    this.DisciplineCode = "110";
                    break;
                case "DATA NETWORKS":
                    this.DisciplineCode = "120";
                    break;
                case "SECURITY":
                    this.DisciplineCode = "130";
                    break;
                case "FURNITURE":
                    this.DisciplineCode = "140";
                    break;
                case "SIGNAGE":
                    this.DisciplineCode = "150";
                    break;
                case "GARAGE":
                    this.DisciplineCode = "160";
                    break;
                case "UNKNOWN":
                    this.DisciplineCode = "900";
                    break;
                default:
                    this.DisciplineCode = "900";
                    break;
            }
        }

        private void setDisciplineSubcode()
        {
            string extractedNumbers = new String(SheetNumber.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());
            //this.DisciplineSubCode = SheetNumber.Where(Char.IsDigit).ToString();
            //string resultString = Regex.Match(SheetNumber, @"\d+").Value;
            this.DisciplineSubCode = extractedNumbers;
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

        private string getFileExtension(FileInfo file)
        {
            var Extension = System.IO.Path.GetExtension(file.ToString());
            return Extension;
        }

        private string getFileDirectory(FileInfo file)
        {
            var Path = System.IO.Path.GetDirectoryName(file.FullName) + @"\";
            return Path;
        }

        private int getPages()
        {
            PDFCommands pCommand = new PDFCommands();
            int pages = pCommand.getPageQuantity(this.FilePath);
            return pages;
        }

        public void setSheetNumberAndName()
        {
            int selected = this.ColumnSelected;

            switch (selected)
            {
                case 2:
                    // Original Name
                    this.SheetNumber = this.oSheetNumber;
                    this.SheetTitle = this.oSheetTitle;

                    break;

                case 3:
                    //Extracted Name
                    this.SheetNumber = this.eSheetNumber;
                    this.SheetTitle = this.eSheetTitle;
                    break;

                case 4:
                    //Custom Name
                    splitFileNameCustom(this.CustomName);
                    break;

                default:
                    break;
            }

            extractDisciplineByFolder(this.ParentFolder);
            setDisciplineCode();
            //setDisciplineSubcode();
            renameSheet();
        }

        public void renameSheet()
        {
            string filePath;
            var Path = System.IO.Path.GetDirectoryName(this.myFile.FullName) + @"\";
            var Name = SheetNumber + " " + SheetTitle;
            var Extension = System.IO.Path.GetExtension(this.myFile.ToString());
            filePath = Path + Name + Extension;
            try
            {
                this.myFile.MoveTo(filePath);
            }
            catch
            {
            }
            //return filePath;   
        }
    }
}
