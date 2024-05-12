using Dapper;
using LojaCD.Domain.Entity;
using LojaCD.Domain.Interfaces;
using System.Data;

namespace LojaCD.Repository
{

    public class GeneroMusicalRepository : IGeneroMusicalRepository
    {
        private readonly IDbConnection _dbConnection;

        public GeneroMusicalRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
          
        }

        public async Task<GeneroMusical> GetById(int id)
        {
            string sql = "SELECT Id, Nome FROM GeneroMusical" +
                " WHERE Id = @id";

            var param = new DynamicParameters();
            param.Add("id", id);

            var generoMusical = await _dbConnection.QueryFirstOrDefaultAsync<GeneroMusical>(sql, param);

            return generoMusical;
             
        }

        public async Task<IEnumerable<GeneroMusical>> GetAll()
        {
            string sql = "SELECT Id, Nome FROM GeneroMusical";

            return await _dbConnection.QueryAsync<GeneroMusical>(sql);
        }

        public async Task Insert(GeneroMusical generoMusical)
        {
            string sql = "INSERT INTO GeneroMusical ( Nome ) " +
                " VALUES ( @nome ) ";
            
            var param = new DynamicParameters();
            param.Add("nome", generoMusical.Nome);

            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task Update(int id, GeneroMusical generoMusical)
        {
            string sql = "UPDATE GeneroMusical set Nome = @nome WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("nome", generoMusical.Nome);
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM GeneroMusical WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);

        }
    }

}
