using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepoExample.Models
{
    public class Student
    {
        public string  name { get; set; }

        [Key]
        public int student_id { get; set; }
    

    }
}
