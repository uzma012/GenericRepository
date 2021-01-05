using Autofac.Util;
using GenericRepoExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepoExample.Models
{
    public class UnitOfWork : IDisposable,IUnitOfWork
    {
         private SchoolContext context = new SchoolContext();
         private GenericRepository<Course> CourseRepository;
        private GenericRepository<Student> StudentRepository;
       
    public IGenericRepository<Course> generic_repo_course
        {
            get
            {

                if (this.CourseRepository == null)
                {
                    this.CourseRepository = new GenericRepository<Course>(context);
                }
                return CourseRepository;

            }
        }

        public IGenericRepository<Student> generic_repo_student 
        {
            get
            {

                if (this.StudentRepository == null)
                {
                    this.StudentRepository = new GenericRepository<Student>(context);
                }
                return StudentRepository;
            }
        
        }

        private bool disposed = false;

        public void Dispose(bool dispose)
        {
            if (!this.disposed)
            {
                if (dispose)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

 

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
