using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetIndex
{
    public class RevisionDescription
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string DateAndDescription { get; set; }

        public RevisionDescription(int id, string description, string date)
        {
            this.ID = id;
            this.Description = description;
            this.Date = date;
            this.DateAndDescription = Description + "\t" + Date;
        }
    }
}
