using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views
{
    public partial class NovoProduto : ContentPage
    {
        // Criado o construtor que inicializa os elementos visuais da tela de cadastro de produtos.
        public NovoProduto()
        {
            InitializeComponent();
        }

        // Criado o evento de clique no botão da barra superior para processar e salvar o novo produto.
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Criado um novo objeto Produto recolhendo os dados informados nos campos visuais da tela.
                Produto p = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text)
                };

                // Enviado o produto para o banco de dados global, emitido o alerta de sucesso e disparado o retorno de tela.
                await App.Database.Insert(p);
                await DisplayAlertAsync("Sucesso!", "Registro inserido com sucesso!", "OK");
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