

using Microsoft.EntityFrameworkCore;
using sistem_supplier.DAL.DContext;
using sistem_supplier.DAL.Repository.Interfaces;
using System.Linq.Expressions;

namespace sistem_supplier.DAL.Repository
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly TekusDbContext _dbContext;

        public GenericRepository(TekusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModel>Get(Expression<Func<TModel, bool>> filtro)
        {
            try
            {
                TModel Modelo = await _dbContext.Set<TModel>().Where(filtro).FirstOrDefaultAsync();
                return Modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel>Create(TModel Model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(Model);
                await _dbContext.SaveChangesAsync();

                return Model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool>Update(TModel Model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(Model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(TModel Model)
        {
            try
            {

                _dbContext.Set<TModel>().Remove(Model);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch { throw; }
        }

        public async Task<IQueryable<TModel>>GetAll(Expression<Func<TModel, bool>> filtro)
        {
            try
            {

                IQueryable<TModel> queryModel = filtro == null ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filtro);
                return queryModel;
            }
            catch { throw; }
        }

        public async Task<bool>Add(TModel Models)
        {
            try
            {

                _dbContext.Set<TModel>().Add(Models);

                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch { throw; }
        }
    }
}
