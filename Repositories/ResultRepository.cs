

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

        public async Task<ResultModel>? findOne(int id)
        {
            var response = await _context.Results.Where(i => i.id == id).FirstOrDefaultAsync();
            return response;
        }

        public void save(ResultModel resultModel)
        {
            _context.Add(resultModel);
        }

        public void update(ResultModel resultModel)
        {
            throw new NotImplementedException();
        }
        public void delete(ResultModel resultModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}