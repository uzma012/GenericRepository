using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepoExample.Models
{
    public class Course
    {
        public string course_name { get; set; }
        [Key]
        public int course_id { get; set; }
        public object StudentID { get; internal set; }
    }
}
