using Dapper;
using LojaCD.Domain.Entity;
using System.Data;
using LojaCD.Domain.Interfaces;

namespace LojaCD.Repository
{

    public class ArtistaRepository : IArtistaRepository
    {
        private readonly IDbConnection _dbConnection;

        public ArtistaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
          
        }

        public async Task<Artista> GetById(int id)
        {
            string sql = "SELECT Id, Nome FROM Artista" +
                " WHERE Id = @id";

            var param = new DynamicParameters();
            param.Add("id", id);

            var artista = await _dbConnection.QueryFirstOrDefaultAsync<Artista>(sql, param);

            return artista;
             
        }

        public async Task<IEnumerable<Artista>> GetAll()
        {
            string sql = "SELECT Id, Nome FROM Artista";

            return await _dbConnection.QueryAsync<Artista>(sql);
        }

        public async Task Insert(Artista artista)
        {
            string sql = "INSERT INTO Artista ( Nome ) " +
                " VALUES ( @nome ) ";
            
            var param = new DynamicParameters();
            param.Add("nome", artista.Nome);

            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task Update(int id, Artista artista)
        {
            string sql = "UPDATE Artista set Nome = @nome WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("nome", artista.Nome);
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM Artista WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);

        }
    }

}
