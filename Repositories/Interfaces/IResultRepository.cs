
using System.Runtime.CompilerServices;
using tetris_api.Models;

namespace tetris_api.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<IEnumerable<ResultModel>> findAll();
        Task<ResultModel> findOne(int id);
        void save(ResultModel resultModel);
        void update(ResultModel resultModel);
        void delete(ResultModel resultModel);

        Task<bool> SaveChangesAsync();
    }
}