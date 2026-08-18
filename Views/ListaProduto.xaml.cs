using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListaProduto : ContentPage
    {
        // Criado o construtor que inicializa os componentes da tela de listagem.
        public ListaProduto()
        {
            InitializeComponent();
        }

        // Criado o evento executado sempre que a tela aparece em foco para atualizar os dados do banco.
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                // Buscado todos os registros gravados no banco e convertidos em lista para o CollectionView.
                List<Produto> produtos = await App.Database.GetAll();
                lst_produtos.ItemsSource = produtos;
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Ops", ex.Message, "OK");
            }
        }

        // Criado o evento do botão Novo para redirecionar o usuário para a tela de cadastro.
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new NovoProduto());
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Ops", ex.Message, "OK");
            }
        }

        // Criado o evento de seleção de um item do CollectionView para abrir a tela de edição ou exclusão.
        private async void lst_produtos_ItemSelected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Captura o produto selecionado na lista moderna
                Produto? p = e.CurrentSelection.FirstOrDefault() as Produto;
                if (p == null) return;

                /* COMENTADO TEMPORARIAMENTE PARA A AGENDA 3:
           O bloco abaixo exibia o menu de Editar e Excluir. 
           Como a Agenda 3 foca apenas na inserção, isolamos esta função.
                // Exibida uma caixa de opções para o usuário escolher entre Editar ou Excluir o item selecionado.
                string opcao = await DisplayActionSheetAsync("Ação:", "Cancelar", null, "Editar", "Excluir");

                if (opcao == "Editar")
                {
                    // Direcionado para a tela de edição passando o produto selecionado.
                    await Navigation.PushAsync(new EditarProduto
                    {
                        BindingContext = p
                    });
                }
                else if (opcao == "Excluir")
                {
                    // Confirmada a exclusão e removido o registro do banco de dados pelo ID.
                    bool confirmar = await DisplayAlertAsync("Confirmação", "Deseja realmente excluir este produto?", "Sim", "Não");
                    if (confirmar)
                    {
                        await App.Database.Delete(p.Id);
                        // Atualizada a lista exibida na tela.
                        lst_produtos.ItemsSource = await App.Database.GetAll();
                    }
                }
                */
                
                // Limpa a seleção para permitir re-cliques no mesmo item
                ((CollectionView)sender).SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Ops", ex.Message, "OK");
            }
        }

        // Criado o evento de alteração de texto na barra de busca para filtrar os produtos em tempo real.
        private async void search_bar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string q = e.NewTextValue;
                List<Produto> produtos = await App.Database.Search(q);
                lst_produtos.ItemsSource = produtos;
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Ops", ex.Message, "OK");
            }
        }
    }
}