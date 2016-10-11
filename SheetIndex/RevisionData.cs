using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace SheetIndex
{
    public class RevisionData
    {
        private Element _e;

        public Element Revision { get; set; }
        public int ID { get; set; }
        public string Desc { get; set; }
        public string Dt { get; set; }
        public string DateAndDescription { get; set; }

        /*public RevisionData(Element revision)
        {
            this.Revision = revision;
            //BuiltInParameter paraIndex = BuiltInParameter.PROJECT_REVISION_REVISION_DESCRIPTION;
            //Parameter parameter = revision.get_Parameter(paraIndex);
            //this.Description = parameter.AsValueString();
            //this.Date = revision.GetParameters("Revision Date").ToString();
            //var desc = revision;
            var dat = revision.GetParameters("Revision Date");
        }*/

        Parameter _p(string parameter_name)
        {
            return _e.LookupParameter(parameter_name);
        }

        /// <summary>
        /// Create a Revision parameter accessor 
        /// for the given BIM element.
        /// </summary>
        public RevisionData(Element e, int id)
        {
            _e = e;
            this.ID = id;
            this.Revision = e;
            this.Desc = Description;
            this.Dt = Date;
            this.DateAndDescription = Desc + "\t" + Dt;
        }

        public string Date
        {
            get { return _p("Revision Date").AsString(); }
            set { _p("Revision Date").Set(value); }
        }

        public string IssuedTo
        {
            get { return _p("Issued to").AsString(); }
            set { _p("Issued to").Set(value); }
        }

        public string Number
        {
            get { return _p("Revision Number").AsString(); }
            set { _p("Revision Number").Set(value); }
        }

        public int Issued
        {
            get { return _p("Issued").AsInteger(); }
            set { _p("Issued").Set(value); }
        }

        public int Numbering
        {
            get { return _p("Numbering").AsInteger(); }
            set { _p("Numbering").Set(value); }
        }

        public int Sequence
        {
            get { return _p("Revision Sequence").AsInteger(); }
            set { _p("Revision Sequence").Set(value); }
        }

        public string Description
        {
            get { return _p("Revision Description").AsString(); }
            set { _p("Revision Description").Set(value); }
        }

        public string IssuedBy
        {
            get { return _p("Issued by").AsString(); }
            set { _p("Issued by").Set(value); }
        }

    }
}

/*
 * {
  /// <summary>
  /// A Revision parameter wrapper class by Max.
  /// </summary>
  class JtRevision
  {
    /// <summary>
    /// The BIM element.
    /// </summary>
    Element _e;
 
    /// <summary>
    /// Internal access to the named parameter. 
    /// </summary>
    Parameter _p( string parameter_name )
    {
      return _e.get_Parameter( parameter_name );
    }
 
    /// <summary>
    /// Create a Revision parameter accessor 
    /// for the given BIM element.
    /// </summary>
    public JtRevision( Element e )
    {
      _e = e;
    }
 
    public string Date
    {
      get { return _p( "Revision Date" ).AsString(); }
      set { _p( "Revision Date" ).Set( value ); }
    }
 
    public string IssuedTo
    {
      get { return _p( "Issued to" ).AsString(); }
      set { _p( "Issued to" ).Set( value ); }
    }
 
    public string Number
    {
      get { return _p( "Revision Number" ).AsString(); }
      set { _p( "Revision Number" ).Set( value ); }
    }
 
    public int Issued
    {
      get { return _p( "Issued" ).AsInteger(); }
      set { _p( "Issued" ).Set( value ); }
    }
 
    public int Numbering
    {
      get { return _p( "Numbering" ).AsInteger(); }
      set { _p( "Numbering" ).Set( value ); }
    }
 
    public int Sequence
    {
      get { return _p( "Revision Sequence" ).AsInteger(); }
      set { _p( "Revision Sequence" ).Set( value ); }
    }
 
    public string Description
    {
      get { return _p( "Revision Description" ).AsString(); }
      set { _p( "Revision Description" ).Set( value ); }
    }
 
    public string IssuedBy
    {
      get { return _p( "Issued by" ).AsString(); }
      set { _p( "Issued by" ).Set( value ); }
    }
  }
}*/
