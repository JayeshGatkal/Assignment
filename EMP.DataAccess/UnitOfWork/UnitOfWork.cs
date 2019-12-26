using EMP.DataAccess.GenericRepository;
using EMP.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace EMP.DataAccess.UnitOfWork
{
    public class UnitOfWork<T> : IDisposable where T : class
    {
        private EmployeeDataContext _context = null;
        private GenericRepository<T> _repository;
        private bool disposed = false;

        public UnitOfWork()
        {
            _context = new EmployeeDataContext();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public GenericRepository<T> Repository
        {
            get
            {
                if (this._repository == null)
                    this._repository = new GenericRepository<T>(_context);
                return _repository;
            }
        }


        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
