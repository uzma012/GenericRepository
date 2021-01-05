using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace GenericRepoExample.Models
{
    public class SchoolContext:DbContext
    {
        public SchoolContext() : base() // passed dotnetfiddle specific connction string
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=SampleDb;Integrated Security=True");
        }

       
    }
}
