using Dapper;
using LojaCD.Domain.Entity;
using LojaCD.Domain.Interfaces;
using System.Data;

namespace LojaCD.Repository
{

    public class CDRepository : ICDRepository
    {
        private readonly IDbConnection _dbConnection;

        public CDRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
          
        }

        public async Task<CD> GetById(int id)
        {

            string sql = @"SELECT c.Id, c.Titulo, c.ArtistaId, GeneroMusicalId
                 FROM CD c
                 WHERE c.Id = @id;
                 SELECT Id, CDId, Nome, Tempo FROM Musicas WHERE CDId = @id;";

            var cds = await _dbConnection.QueryMultipleAsync(sql, new { id = id });

            var cd = await cds.ReadFirstAsync<CD>();
            cd.Musicas = (await cds.ReadAsync<Musica>()).ToList();

            return cd;

        }

        public async Task<Musica> GetMusicaById(int id)
        {
            string sql = @"SELECT Id, CDId, Nome, Tempo
                 FROM Musicas
                 WHERE Id = @id";

            var musica = await _dbConnection.QuerySingleAsync<Musica>(sql, new { id = id });

            return musica;
        }


        public async Task<IEnumerable<CD>> GetAll()
        {
            string sql = @"SELECT c.Id, c.Titulo,
                 a.Id, a.Nome,
                 gm.Id, gm.Nome
                 FROM CD c INNER JOIN Artista a on c.ArtistaId = a.Id 
                 INNER JOIN GeneroMusical gm ON c.GeneroMusicalId = gm.Id";

            var cds = await _dbConnection.QueryAsync<CD, Artista, GeneroMusical, CD>(sql,
                (cd, artista, generoMusical) =>
                {
                    cd.Artista = artista;
                    cd.GeneroMusical = generoMusical;
                    return cd;
                },
                splitOn: "Id,Id,Id");

            return cds;
        }
        
        public async Task<IEnumerable<CD>> GetCDFitlrados(string titulo, int? artistaId, int? generoMusicalId, string nomeMusica)
        {
            bool onde = false;

            string sql = @"SELECT c.Id, c.Titulo,
                 a.Id, a.Nome,
                 gm.Id, gm.Nome
                 FROM CD c INNER JOIN Artista a on c.ArtistaId = a.Id 
                 INNER JOIN GeneroMusical gm ON c.GeneroMusicalId = gm.Id";

            if(!string.IsNullOrEmpty(titulo))
            {
                sql += onde ? " AND " : " WHERE ";
                onde = true;
                sql += $" c.Titulo like '%{titulo}%'";
            }

            if (artistaId > 0)
            {
                sql += onde ? " AND " : " WHERE ";
                onde = true;
                sql += $" c.ArtistaId = {artistaId}";
            }

            if (generoMusicalId > 0)
            {
                sql += onde ? " AND " : " WHERE ";
                onde = true;
                sql += $" c.generoMusicalId = {generoMusicalId}";
            }

            if (!string.IsNullOrEmpty(nomeMusica))
            {
                sql += onde ? " AND " : " WHERE ";
                onde = true;
                sql += $@" c.Id IN (
                SELECT CDId from Musicas WHERE Nome like '%{nomeMusica}%')";
            }

            var cds = await _dbConnection.QueryAsync<CD, Artista, GeneroMusical, CD>(sql,
                (cd, artista, generoMusical) =>
                {
                    cd.Artista = artista;
                    cd.GeneroMusical = generoMusical;
                    return cd;
                },
                splitOn: "Id,Id,Id");

            return cds;
        }


        public async Task<CD> Insert(CD cd)
        {
            string sql = @"INSERT INTO CD ( Titulo, ArtistaId, GeneroMusicalId) OUTPUT INSERTED.Id 
                 VALUES ( @titulo, @artistaId, @generoMusicalId)";

            cd.Id = await _dbConnection.QuerySingleAsync<int>(sql, cd);

            return cd;
        }

        public async Task InsertMusica(Musica musica)
        {
            string sql = @"INSERT INTO Musicas ( CDId, Nome, Tempo) OUTPUT INSERTED.Id 
                 VALUES ( @CDId, @nome, @tempo)";

            musica.Id = await _dbConnection.QuerySingleAsync<int>(sql, musica);
        }


        public async Task Update(CD cd)
        {
            string sql = "UPDATE CD set Titulo = @titulo, ArtistaId = @artistaId, GeneroMusicalId = @generoMusicalId WHERE Id = @id ";

            await _dbConnection.ExecuteAsync(sql, cd);
        }

        public async Task UpdateMusica(Musica musica)
        {
            string sql = "UPDATE Musicas set Nome = @nome, Tempo = @tempo WHERE Id = @id ";

            await _dbConnection.ExecuteAsync(sql, musica);
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM CD WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);

        }

        public async Task DeleteMusica(int id)
        {
            string sql = "DELETE FROM Musicas WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);

        }

    }

}
