using GenericRepoExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepoExample.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Course> generic_repo_course { get; }
        public IGenericRepository<Student> generic_repo_student { get; }
        public void  Save();

        public void Dispose(bool dispose);
        void Dispose();
    }
}
