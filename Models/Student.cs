using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Events.Models
{
    public class Student
    {
        public int Id { get; set; }
        public required  string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime DeletedOn { get; set; }

        public override string ToString()
        => $"Student Id ={Id}, FirstName={FirstName}";
    }
}
