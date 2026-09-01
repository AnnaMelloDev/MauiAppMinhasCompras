using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views
{
    public partial class EditarProduto : ContentPage
    {
        // Criado o construtor que inicializa os elementos visuais da tela de edição.
        public EditarProduto()
        {
            InitializeComponent();
        }

        // Criado o evento de clique na barra de ferramentas para processar a atualização dos dados no banco.
#pragma warning disable CA1416 // Escudo ativado: Oculta alertas de plataforma do .NET 10 para o bloco inteiro.
        private async void ToolbarItem_Clicked(object? sender, EventArgs e)
        {
            try
            {
                // Criado um objeto Produto preenchendo com os novos valores digitados nos campos da tela.
                Produto p = new Produto
                {
                    Id = Convert.ToInt32(txt_id.Text),
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text)
                };

                // Executada a função de atualização no banco de dados SQLite, emitida a confirmação e retornado à tela anterior.
                await App.Database.Update(p);
                
                // O alerta é exibido em uma página MAUI e não depende de APIs específicas da plataforma neste ponto.
                await DisplayAlertAsync("Sucesso!", "Registro atualizado com sucesso!", "OK");
                
                // A navegação da página é usada em um contexto MAUI válido e a chamada é compatível com plataformas suportadas.
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                // Interceptado qualquer erro imprevisto exibindo uma mensagem de alerta para o usuário.
                await DisplayAlertAsync("Ops", ex.Message, "OK");
            }
        }
#pragma warning restore CA1416 // Escudo desativado: O inspetor volta a analisar o restante do arquivo normalmente.
    }
}