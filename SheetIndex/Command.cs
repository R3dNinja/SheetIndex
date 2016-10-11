#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace SheetIndex
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        //public MainInterface dialog;
        public ImprovedInterface dialog;
        public PDFResults dataview;
        public static SortableBindingList<SheetData> listSheet = new SortableBindingList<SheetData>();
        public static SortableBindingList<SheetData> filteredListSheet = new SortableBindingList<SheetData>();
        public List<RevisionData> listRevison = new List<RevisionData>();
        public static List<RevisionDescription> listRev = new List<RevisionDescription>();
        public int selectedRevision = 0;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            filteredListSheet = null;
            filteredListSheet = new SortableBindingList<SheetData>();
            listSheet = null;
            listSheet = new SortableBindingList<SheetData>();
            listRevison = null;
            listRevison = new List<RevisionData>();
            listRev = null;
            listRev = new List<RevisionDescription>();

            getRevisionList(uidoc, doc);

            var results = ShowForm();
            if (results == true)
            {
                CreatePlaceHolderSheet(doc);
            }
            return Result.Succeeded;
        }

        private void getRevisionList(UIDocument uidoc, Document doc)
        {
            FilteredElementCollector col = new FilteredElementCollector(doc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_Revisions);

            int count = 0;
            foreach (Element e in col)
            {
                //TaskDialog.Show("Revision", e.Name);
                listRevison.Add(new RevisionData(e, count));
                listRev.Add(new RevisionDescription(count, listRevison[count].Desc, listRevison[count].Dt));
                //TaskDialog.Show("Description", listRevison[count].Desc);
                //TaskDialog.Show("Date", listRevison[count].Dt);
                count++;
            }

        }

        private bool ShowForm()
        {
            //dialog = new MainInterface();
            dialog = new ImprovedInterface();

            dialog.ShowDialog();

            if (dialog.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                dataview = new PDFResults();
                var result = dataview.ShowDialog();
                if (dataview.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    selectedRevision = dataview.ID_Selected;
                    return true;
                }
                else
                {
                    selectedRevision = dataview.ID_Selected;
                    return false;
                }
            }
            return true;
        }

        public void CreatePlaceHolderSheet(Document doc)
        {
            Element TempRevision = listRevison[selectedRevision].Revision;
            ElementId TempRevisionID = TempRevision.Id;
            List<ElementId> tempIds = new List<ElementId>();
            tempIds.Add(TempRevisionID);
            bool exists = false;
            foreach (SheetData sheet in Command.filteredListSheet)
            {
                exists = false;
                ViewSheet existingSheet = null;
                //check if sheet alreadry exists
                FilteredElementCollector col = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet));
                foreach (ViewSheet vs in col)
                {
                    string number = vs.SheetNumber;
                    if (sheet.SheetNumber == number)
                    {
                        exists = true;
                        existingSheet = vs;
                    }
                }
                if (exists == true)
                {
                    using (Transaction tx = new Transaction(doc))
                    {
                        tx.Start("Update Existing Sheet");
                        existingSheet.SetAdditionalRevisionIds(tempIds);
                        tx.Commit();
                    }
                }
                else
                {
                    using (Transaction tx = new Transaction(doc))
                    {
                        tx.Start("Create Placeholder Sheet");
                        ViewSheet newViewSheet = ViewSheet.CreatePlaceholder(doc);
                        newViewSheet.Name = sheet.SheetTitle;
                        newViewSheet.SheetNumber = sheet.SheetNumber;
                    
                        newViewSheet.LookupParameter("*Discipline").Set(sheet.Discipline);
                        newViewSheet.LookupParameter("*Discipline Code").Set(sheet.DisciplineCode);
                        newViewSheet.LookupParameter("*Discipline Subcode").Set(sheet.DisciplineSubCode);

                        newViewSheet.SetAdditionalRevisionIds(tempIds);
                        sheet.deleteTempFile();
                        tx.Commit();
                    }
                }
            }
        }
    }
}
