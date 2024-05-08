using DogsSpaCRMSystem.Server.Intefrace;
using DogsSpaCRMSystem.Server.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DogsSpaCRMSystem.Server.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            bool exists = await DoesTableExist(entity.GetType().Name);
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public  List<T> ExecSP(object[] parameters,string SPscript)
        {
            return _context.Set<T>().FromSqlRaw(SPscript, parameters).ToList();
        }
        public async Task<bool> DoesTableExist(string tableName)
        {
            bool TableExists = false;
            try
            {
                // Use information_schema.tables to check for the table
                var sql = $"SELECT * FROM information_schema.tables WHERE table_name = '{tableName}'";
                TableExists = await _context.Set<T>().FromSqlRaw(sql).AnyAsync();

            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            return TableExists;
        }



    }

}
