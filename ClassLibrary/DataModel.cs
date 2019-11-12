using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Table(Name = "DataModel")]
    public class DataModel
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Id")]
        public int Id { get; set; }
        [Column(Name = "FirstName")]
        public string FirstName { get; set; }
        [Column(Name = "SecondName")]
        public string SecondName { get; set; }
        [Column(Name = "MiddleName")]
        public string MiddleName { get; set; }
        [Column(Name = "Sum")]
        public int? Sum { get; set; }
        [Column(Name = "Date")]
        public DateTime Date { get; set; }
        [Column(Name = "IsPaid")]
        public bool? IsPaid { get; set; }

    }
}
