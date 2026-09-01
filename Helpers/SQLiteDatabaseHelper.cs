using SQLite;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Helpers
{
   public class SQLiteDatabaseHelper
   {
      // Criado o cabo de conexão seguro e de leitura única que trabalha em segundo plano.
      readonly SQLiteAsyncConnection _conn;

      // Criado o construtor que é acionado na partida, liga o endereço do banco e cria a tabela aguardando a finalização.
      public SQLiteDatabaseHelper(string path)
      {
         _conn = new SQLiteAsyncConnection(path);
         _conn.CreateTableAsync<Produto>().Wait();
      }

      // Criada a função de Inserir que recebe um produto e salva uma nova linha no banco de dados.
      public Task<int> Insert(Produto p)
      {
         return _conn.InsertAsync(p);
      }

      // Criada a função de Atualizar que corrige a descrição, quantidade ou preço baseando-se no ID do produto.
      public Task<List<Produto>> Update(Produto p)
      {
         string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";
         return _conn.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
      }

      // Criada a função de Excluir que remove permanentemente um item da tabela utilizando o número de ID.
      public Task<int> Delete(int id)
      {
         return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
      }

      // Criada a função de leitura que busca todos os registros gravados e os converte em uma lista para exibição.
      public Task<List<Produto>> GetAll()
      {
         return _conn.Table<Produto>().ToListAsync();
      }

      // Criada a função de busca corrigida (adicionado o 'FROM' que faltava na instrução SQL)
      public Task<List<Produto>> Search(string q)
      {
         string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%" + q + "%'";
         return _conn.QueryAsync<Produto>(sql);
      }
   }
}