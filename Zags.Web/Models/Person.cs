using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zags.Web.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string PIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
