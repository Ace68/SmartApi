using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Threading.Tasks;
using SmartApi.Persistence.Abstracts;
using SmartApi.Persistence.Facade;
using SmartApi.Shared.Dtos;

namespace SmartApi.Persistence.Repositories
{
    public class SmartApiUnitOfWork : ISmartApiUnitOfWork, IDisposable
    {
        private readonly SmartApiFacade _smartApiFacade;

        public SmartApiUnitOfWork()
        {
            this._smartApiFacade = new SmartApiFacade();
        }

        #region Repositories
        private ISmartApiRepository<ArticoliDto> _articoliRepository;

        public ISmartApiRepository<ArticoliDto> ArticoliRepository
        {
            get
            {
                return this._articoliRepository ??
                       (this._articoliRepository = new SmartApiRepository<ArticoliDto>(this._smartApiFacade));
            }
        }
        #endregion

        #region Commit
        public async Task CommitAsync()
        {
            using (var suiteContextTransaction = this._smartApiFacade.Database.BeginTransaction())
            {
                try
                {
                    await this._smartApiFacade.SaveChangesAsync();
                    suiteContextTransaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    var sb = new StringBuilder();
                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());

                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }
                    suiteContextTransaction.Rollback();
                    throw new Exception("SmartApiUnitOfWork.Commit", ex);
                }
                catch (Exception ex)
                {
                    suiteContextTransaction.Rollback();
                    throw new Exception("SmartApiUnitOfWork.Commit", ex);
                }
            }
        }
        #endregion

        #region Dispose
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._smartApiFacade.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}