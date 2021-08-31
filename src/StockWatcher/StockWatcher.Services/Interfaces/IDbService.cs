using StockWatcher.Models.Models.DbResponse;
using System.Threading.Tasks;

namespace StockWatcher.Services.Interfaces
{
    public interface IDbService
    {
        Task<IDbResponse> ExecuteAsync<T>(string storedProcedure, T parameters);

        Task<IDbResponse> QueryAsync<T, U>(string storedProcedure, U parameters);
    }
}
