# 🛒 Aplicativo Minhas Compras — .NET MAUI & SQLite

Repositório contínuo desenvolvido para as atividades práticas da disciplina de **Desenvolvimento de Sistemas III** (3º Semestre - Curso Técnico Etec).

---

## 📚 Divisão e Evolução das Agendas

### 📌 Agenda 1: Modelagem de Dados (Models)
* **Objetivo:** Estruturação da base do projeto e criação da classe principal de domínio.
* **Arquivos:** `Modelos/Produto.cs`
* **Implementação:** Definição da estrutura do produto com as propriedades de identificação (`Id`), descrição (`Descrição`), quantidade (`Quantidade`) e valor (`Preço`), mapeando os atributos primários para o SQLite.

### 📌 Agenda 2: Camada de Persistência (Helpers)
* **Objetivo:** Construção da classe de manipulação direta da base de dados local.
* **Arquivos:** `Ajudantes/SQLiteDatabaseHelper.cs`
* **Implementação:** Criação da classe auxiliar responsável por abrir a conexão com a biblioteca `SQLite-net-pcl` e gerenciar as operações assíncronas de inserção e consulta no banco.

### 📌 Agenda 3: Conexão e Interface Gráfica (Etapa Atual)
* **Objetivo:** Configuração da rota inicial do banco de dados e construção da View de cadastro.
* **Arquivos:** `App.xaml.cs`, `Vistas/NovoProduto.xaml` e `Vistas/NovoProduto.xaml.cs`
* **Implementação:** Definido o caminho do arquivo de persistência (`banco_sqlite_compras.db3`) no ciclo de vida global da aplicação e desenvolvida a interface gráfica para captação dos dados e efetivação do salvamento do primeiro registro.

### 📌 Agenda 4: Manipulação de Interface e Busca Dinâmica (Etapa Atual)

* **Objetivo:** Implementação de busca dinâmica em tempo real utilizando a memória do aplicativo, sem sobrecarregar o banco de dados.
* **Arquivos:** `Vistas/ListaProduto.xaml` e `Vistas/ListaProduto.xaml.cs`
* **Implementação:** Criação da interface com o elemento `SearchBar` e uso do evento `TextChanged` para filtrar dados dinamicamente. Aplicação de `ObservableCollection` e expressões LINQ para realizar as buscas na memória, blindando o código contra falhas de compatibilidade do sistema operacional.

### 📌 Agenda 5: Menus de Contexto, Navegação e Tratamento de Exceções (Etapa Atual)

* **Objetivo:** Aprimorar a interatividade, robustez e confiabilidade do aplicativo móvel com navegação baseada em seleção e ações rápidas.
* **Arquivos:** `Views/ListaProduto.xaml`, `Views/ListaProduto.xaml.cs`, `Views/EditarProduto.xaml.cs` e `Helpers/SQLiteDatabaseHelper.cs`
* **Implementação:** 
  * Estruturação de `ListView` com suporte a `ContextActions` para menus de contexto rápidos (como a exclusão de registros).
  * Tratamento preventivo de falhas utilizando blocos `try-catch` combinados com `DisplayAlert` para mensagens amigáveis ao usuário.
  * Configuração do evento `ItemSelected` e do método `EditarProduto` utilizando `BindingContext` para garantir que as alterações sejam salvas no registro correto via SQLite.
---

## 🛠️ Tecnologias Utilizadas
* C# / XAML
* .NET MAUI
* SQLite-net-pcl

---
