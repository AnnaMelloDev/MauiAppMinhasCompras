using System.Collections.ObjectModel;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    // Variável global que mantém a lista original de produtos na memória
    ObservableCollection<Produto> _todosOsProdutos = new ObservableCollection<Produto>();

    // Criado o construtor que inicializa os componentes da tela de listagem.
    public ListaProduto()
    {
        InitializeComponent();
    }

#pragma warning disable CA1416 // Escudo protetor para compatibilidade de plataforma no Windows
    // Criado o evento executado sempre que a tela aparece em foco para atualizar os dados do banco.
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            // Buscado todos os registros gravados no banco.
            List<Produto> produtos = await App.Database.GetAll();
            
            // Convertidos em ObservableCollection para notificar automaticamente a interface do usuário.
            _todosOsProdutos = new ObservableCollection<Produto>(produtos);
            AtualizarLista(_todosOsProdutos);
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    // Criado o evento do botão Novo para redirecionar o usuário para a tela de cadastro.
    private async void ToolbarItem_Clicked(object? sender, EventArgs e)
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

    // Criado o evento de seleção de um item da ListView (Agenda 5)
    private async void lst_produtos_ItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            // Captura o produto selecionado na ListView
            Produto? p = e.SelectedItem as Produto;
            if (p == null) return;

            // Exibida uma caixa de opções para o usuário escolher entre Editar ou Excluir.
            string opcao = await DisplayActionSheetAsync("Ação:", "Cancelar", null, "Editar", "Excluir");

            if (opcao == "Editar")
            {
                // Direcionado para a tela de edição passando o produto selecionado via BindingContext.
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
                    
                    // Atualizada a lista exibida na tela requisitando o banco novamente.
                    List<Produto> produtos = await App.Database.GetAll();
                    _todosOsProdutos = new ObservableCollection<Produto>(produtos);
                    AtualizarLista(_todosOsProdutos);
                }
            }
            
            // Limpa a seleção para permitir re-cliques no mesmo item
            if (sender is ListView lv)
            {
                lv.SelectedItem = null;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    // Evento acionado ao clicar no Menu de Contexto (ContextActions - Excluir rápido) exigido na Agenda 5
    private async void MenuItem_Clicked(object? sender, EventArgs e)
    {
        try
        {
            if (sender is MenuItem menuItem && menuItem.BindingContext is Produto p)
            {
                bool confirmar = await DisplayAlertAsync("Confirmação", $"Deseja realmente excluir '{p.Descricao}'?", "Sim", "Não");
                if (confirmar)
                {
                    await App.Database.Delete(p.Id);
                    
                    // Atualiza a lista após a exclusão via menu rápido
                    List<Produto> produtos = await App.Database.GetAll();
                    _todosOsProdutos = new ObservableCollection<Produto>(produtos);
                    AtualizarLista(_todosOsProdutos);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
#pragma warning restore CA1416

    // Método centralizado para atualizar a lista garantindo compatibilidade com o Windows
    private void AtualizarLista(IEnumerable<Produto> produtos)
    {
        if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17763))
        {
            lst_produtos.ItemsSource = new ObservableCollection<Produto>(produtos);
        }
    }

    // Evento acionado quando o texto na SearchBar muda, realizando a pesquisa dinâmica
    private void search_bar_TextChanged(object? sender, TextChangedEventArgs e)
    {
        try
        {
            string q = string.Empty;
            if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17763))
            {
                q = e.NewTextValue?.ToLower() ?? string.Empty;
            }

            // Verifica se a barra de pesquisa foi completamente limpa
            if (string.IsNullOrWhiteSpace(q))
            {
                AtualizarLista(_todosOsProdutos);
            }
            else
            {
                // Filtra os dados localizando a palavra e protege contra produtos nulos
                var filtrados = _todosOsProdutos.Where(p => p.Descricao?.ToLower().Contains(q) ?? false);
                AtualizarLista(filtrados);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}