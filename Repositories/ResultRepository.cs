using tetris_api.Models;
using tetris_api.Data;

namespace tetris_api.Repositories
{
    public class ResultRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void save(ResultModel resultModel)
        {
            _context.Results.Add(resultModel);
            _context.SaveChanges();
        }

        public List<ResultModel> GetAll()
        {
            return _context.Results.ToList();
        }
    }
}