using SQLite;

namespace MauiAppMinhasCompras.Models
{
   public class Produto
   {
      // Criado o identificador único do produto e a contagem matemática automática de soma.
      [PrimaryKey, AutoIncrement]
      public int Id { get; set; }

      // Criada a variável de texto que guarda o nome que o usuário vai digitar.
      public string? Descricao { get; set; }

      // Criada a variável decimal que guarda o peso ou volume e aceita números quebrados.
      public double Quantidade { get; set; }

      // Criada a variável decimal que guarda o valor financeiro do item.
      public double Preco { get; set; }
   }
}