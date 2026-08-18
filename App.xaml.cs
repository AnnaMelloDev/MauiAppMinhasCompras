using MauiAppMinhasCompras.Helpers;
using MauiAppMinhasCompras.Views; // Adicionamos a visão das telas

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        // Criado o campo privado que armazena a instância única do nosso ajudante de banco de dados.
        static SQLiteDatabaseHelper? _database;

        // Criada a propriedade global Database que localiza o caminho seguro no celular e instancia o SQLite.
        public static SQLiteDatabaseHelper Database
        {
            get
            {
                if (_database == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "banco_sqlite_compras.db3");
                    _database = new SQLiteDatabaseHelper(path);
                }
                return _database;
            }
        }

        public App()
        {
        }

        // Criada a janela principal avisando que o app deve começar pela Lista de Produtos com sistema de navegação ativado.
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new ListaProduto()));
        }
    }
}