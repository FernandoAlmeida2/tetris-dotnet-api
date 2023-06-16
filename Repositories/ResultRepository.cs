

using Microsoft.EntityFrameworkCore;
using tetris_api.Data;
using tetris_api.Models;
using tetris_api.Repositories.Interfaces;

namespace tetris_api.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly ResultContext _context;

        public ResultRepository(ResultContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<ResultModel>> findAll()
        {
            return await _context.Results.OrderByDescending(i => i.score)
                .ThenByDescending(i => i.speed)
                .ToListAsync();
        }

        public async Task<ResultModel> findOne(int id)
        {
            return await _context.Results.Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public void save(ResultModel resultModel)
        {
            _context.Add(resultModel);
        }

        public void update(ResultModel resultModel)
        {
            _context.Update(resultModel);
        }
        public void delete(ResultModel resultModel)
        {
            _context.Remove(resultModel);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}