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
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
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
                await DisplayAlertAsync("Sucesso!", "Registro atualizado com sucesso!", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                // Interceptado qualquer erro imprevisto exibindo uma mensagem de alerta para o usuário.
                await DisplayAlertAsync("Ops", ex.Message, "OK");
            }
        }
    }
}